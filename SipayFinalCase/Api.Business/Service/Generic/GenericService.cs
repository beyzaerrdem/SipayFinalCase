using Api.Base.BaseResponse;
using Api.DataAccess.UnitOfWork;
using AutoMapper;

namespace Api.Business.Service.Generic
{
    public class GenericService<TEntity, TRequest, TResponse> : IGenericService<TEntity, TRequest, TResponse> where TEntity : class
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IMapper mapper, IUnitOfWork unitOfWork) 
        { 
            _mapper = mapper;
            _unitOfWork = unitOfWork;   
        }


        public virtual ApiResponse Delete(int id)
        {
            try
            {
                var entity = _unitOfWork.DynamicRepository<TEntity>().GetById(id);
                if(entity == null)
                {
                    return new ApiResponse("Kayıt bulunamadı.");
                }
                _unitOfWork.DynamicRepository<TEntity>().DeleteById(id);
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public virtual ApiResponse<List<TResponse>> GetAll()
        {
            try
            {                
                var entityList = _unitOfWork.DynamicRepository<TEntity>().GetAll();
                var map = _mapper.Map<List<TEntity>, List<TResponse>>(entityList);
                if (entityList == null)
                {
                    return new ApiResponse<List<TResponse>>("Listede kayıt bulunamadı.");
                }
                return new ApiResponse<List<TResponse>>(map);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<TResponse>>(ex.Message);
            }        
        }

        public virtual ApiResponse<TResponse> GetById(int id)
        {
            try
            {
                var entity = _unitOfWork.DynamicRepository<TEntity>().GetById(id);
                var map = _mapper.Map<TEntity,TResponse>(entity);
                if (entity == null)
                {
                    return new ApiResponse<TResponse>("Kayıt bulunamadı.");
                }
                return new ApiResponse<TResponse>(map);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TResponse>(ex.Message);
            }
        }

        public virtual ApiResponse Insert(TRequest request)
        {
            try
            {              
                var entity = _mapper.Map<TRequest, TEntity>(request);
                _unitOfWork.DynamicRepository<TEntity>().Insert(entity);
                _unitOfWork.Saved();
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public virtual ApiResponse Update(int id, TRequest request)
        {
            try
            {
                var entityId = _unitOfWork.DynamicRepository<TEntity>().GetById(id);

                if(entityId  == null)
                {
                    return new ApiResponse("Kayıt bulunamadı.");
                }

                var entity = _mapper.Map<TRequest, TEntity>(request);
                _unitOfWork.DynamicRepository<TEntity>().Update(entity);
                _unitOfWork.Saved();
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }
    }
}

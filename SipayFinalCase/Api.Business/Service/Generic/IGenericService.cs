using Api.Base.BaseResponse;

namespace Api.Business.Service.Generic
{
    public interface IGenericService<TEntity, TRequest, TResponse>
    {
        ApiResponse<List<TResponse>> GetAll();
        ApiResponse<TResponse> GetById(int id);   
        ApiResponse<TResponse> Update(int id, TRequest request);
        ApiResponse Delete(int id);
        ApiResponse<TResponse> Insert(TRequest request);
    }
}

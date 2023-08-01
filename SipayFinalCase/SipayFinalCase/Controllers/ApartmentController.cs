using Api.Base.BaseResponse;
using Api.DataAccess.Models;
using Api.DataAccess.UnitOfWork;
using Api.Schema.Request;
using Api.Schema.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ApiResponse<List<ApartmentResponse>> GetAll()
        {
            var entityList = _unitOfWork.ApartmentRepository.GetAll();
            var map = _mapper.Map<List<Apartment>, List<ApartmentResponse>>(entityList);
            return new ApiResponse<List<ApartmentResponse>>(map);
        }

        [HttpGet("{id}")]
        public ApiResponse<ApartmentResponse> Get(int id)
        {
            var entity = _unitOfWork.ApartmentRepository.GetById(id);
            var map = _mapper.Map<Apartment, ApartmentResponse>(entity);
            return new ApiResponse<ApartmentResponse>(map);
        }

        [HttpPost]
        public ApiResponse Post([FromBody] ApartmentRequest request)
        {
            var entity = _mapper.Map<ApartmentRequest, Apartment>(request);
            _unitOfWork.ApartmentRepository.Insert(entity);
            _unitOfWork.ApartmentRepository.Save();
            return new ApiResponse();
        }


        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] ApartmentRequest request)
        {
            var entity = _mapper.Map<ApartmentRequest, Apartment>(request);
            _unitOfWork.ApartmentRepository.Insert(entity);
            entity.Id = id;
            _unitOfWork.ApartmentRepository.Update(entity);
            _unitOfWork.ApartmentRepository.Save();
            return new ApiResponse();
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            _unitOfWork.ApartmentRepository.DeleteById(id);
            return new ApiResponse();
        }
    }
}

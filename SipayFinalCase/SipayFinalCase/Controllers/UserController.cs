using Api.Base.BaseResponse;
using Api.DataAccess;
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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public ApiResponse<List<UserResponse>> GetAll()
        {
            var entityList = _unitOfWork.UserRepository.GetAll();
            var map = _mapper.Map<List<User>, List<UserResponse>>(entityList);
            return new ApiResponse<List<UserResponse>>(map);
        }

        [HttpGet("{id}")]
        public ApiResponse<UserResponse> Get(int id)
        {
            var entity = _unitOfWork.UserRepository.GetById(id);
            var map = _mapper.Map<User, UserResponse>(entity);
            return new ApiResponse<UserResponse>(map);
        }

       
        [HttpPost]
        public ApiResponse Post([FromBody] UserRequest request)
        {
            var entity = _mapper.Map<UserRequest, User>(request);
            _unitOfWork.UserRepository.Insert(entity);
            return new ApiResponse();
        }

     
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] UserRequest request)
        {
            //var entityId = _userRepository.GetById(id);
            //var entity = _mapper.Map<UserRequest, User>(entityId);
            //_userRepository.Update(entity);
            //return new ApiResponse();
            var entity = _mapper.Map<UserRequest, User>(request);
            _unitOfWork.UserRepository.Insert(entity);
            entity.Id = id;
            _unitOfWork.UserRepository.Update(entity);
            return new ApiResponse();
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            _unitOfWork.UserRepository.DeleteById(id);
            return new ApiResponse();
        }
    }
}

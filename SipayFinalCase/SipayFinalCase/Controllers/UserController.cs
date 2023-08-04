using Api.Base.BaseResponse;
using Api.Business;
using Api.Business.ValidationRules;
using Api.Schema.Request;
using Api.Schema.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api.Service.Controllers
{
    //[Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ApiResponse<List<UserResponse>> GetAll()
        {
            var entityList = _userService.GetAll();
            return entityList;
        }

        [HttpGet("{id}")]
        public ApiResponse<UserResponse> Get(int id)
        {
            var entity = _userService.GetById(id);
            return entity;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] UserRequest request)
        {
            UserValidator userValidator = new UserValidator();
            var result = userValidator.Validate(request);
            if (result.IsValid)
            {
                var entity = _userService.Insert(request);
                return entity;
            }
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            var errorMessage = string.Join(", ", errorMessages);
            return new ApiResponse { Success = false, Message = errorMessage };
        }

        //[Authorize(Roles = "user,admin")]
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] UserRequest request)
        {
            var response = _userService.Update(id, request);
            return response;
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            var response = _userService.Delete(id);
            return response;
        }
    }
}

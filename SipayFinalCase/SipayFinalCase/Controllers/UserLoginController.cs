using Api.Base.BaseResponse;
using Api.Business;
using Api.Schema.Request;
using Api.Schema.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;

        public UserLoginController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpGet]
        public ApiResponse<List<UserLoginResponse>> GetAll()
        {
            var entityList = _userLoginService.GetAll();
            return entityList;
        }

        [HttpGet("{id}")]
        public ApiResponse<UserLoginResponse> Get(int id)
        {
            var entity = _userLoginService.GetById(id);
            return entity;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] UserLoginRequest request)
        {
            var entity = _userLoginService.Insert(request);               
            return entity;
        }


        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] UserLoginRequest request)
        {
            var response = _userLoginService.Update(id, request);
            return response;
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            var response = _userLoginService.Delete(id);
            return response;
        }

      
    }
}

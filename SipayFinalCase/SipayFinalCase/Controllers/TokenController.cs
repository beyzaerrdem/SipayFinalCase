using Api.Base.BaseResponse;
using Api.Business.Service.Token;
using Api.Schema.Request;
using Api.Schema.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        { 
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public ApiResponse<TokenResponse> Post([FromBody] TokenRequest request)
        {
            var response = _tokenService.Login(request);
            return response;
        }
    }
}

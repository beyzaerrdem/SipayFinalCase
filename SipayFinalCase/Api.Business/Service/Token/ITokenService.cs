using Api.Base.BaseResponse;
using Api.Schema.Request;
using Api.Schema.Response;

namespace Api.Business.Service.Token
{
    public interface ITokenService 
    {
        ApiResponse<TokenResponse> Login(TokenRequest request);
    }
}

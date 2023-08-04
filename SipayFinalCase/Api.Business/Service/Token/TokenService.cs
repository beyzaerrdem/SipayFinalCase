using Api.Base.BaseResponse;
using Api.Base.Jwt;
using Api.DataAccess.Models;
using Api.DataAccess.UnitOfWork;
using Api.Schema.Request;
using Api.Schema.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Business.Service.Token
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtConfig jwtConfig;

        public TokenService(IUnitOfWork unitOfWork, IOptionsMonitor<JwtConfig> jwtConfig) 
        {
            _unitOfWork = unitOfWork;
            this.jwtConfig = jwtConfig.CurrentValue;
        }

        public ApiResponse<TokenResponse> Login(TokenRequest request)
        {
            if (request is null)
            {
                return new ApiResponse<TokenResponse>("Request was null");
            }
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return new ApiResponse<TokenResponse>("Request was null");
            }

            request.UserName = request.UserName.Trim().ToLower();
            request.Password = request.Password.Trim();

            var user = _unitOfWork.UserLoginRepository.Where(x => x.UserName.Equals(request.UserName)).FirstOrDefault();
            if (user is null)
            {
                return new ApiResponse<TokenResponse>("Invalid user informations");
            }
            if (user.Password.ToLower() != CreateMD5(request.Password))
            {
                user.PasswordRetryCount++;
                user.LastActivity = DateTime.UtcNow;

                if (user.PasswordRetryCount > 3)
                    user.Status = 2;

                _unitOfWork.UserLoginRepository.Update(user);
                _unitOfWork.Saved();

                //Log(request.UserName, LogType.WrongPassword);
                return new ApiResponse<TokenResponse>("Invalid user informations");
            }

            user.LastActivity = DateTime.UtcNow;
            user.Status = 1;

            _unitOfWork.UserLoginRepository.Update(user);
            _unitOfWork.Saved();

            string token = Token(user);

            TokenResponse response = new()
            {
                AccessToken = token,
                ExpireTime = DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
                UserName = user.UserName
            };

            return new ApiResponse<TokenResponse>(response);
        }

        private string Token(UserLogin userLogin)
        {
            Claim[] claims = GetClaims(userLogin);
            var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                jwtConfig.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha512Signature)
                );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }


        private Claim[] GetClaims(UserLogin userLogin)
        {
            var claims = new[]
            {
            new Claim("UserName",userLogin.UserName),
            new Claim("UserId",userLogin.Id.ToString()),
            new Claim("Role",userLogin.Role),
            new Claim("Status",userLogin.Status.ToString()),
            new Claim(ClaimTypes.Role,userLogin.Role),
        };
            return claims;
        }

        private string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes).ToLower();
            }
        }
    }
}

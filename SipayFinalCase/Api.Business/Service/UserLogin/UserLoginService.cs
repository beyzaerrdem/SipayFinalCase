using Api.Base.BaseResponse;
using Api.Business.Service.Generic;
using Api.DataAccess.Models;
using Api.DataAccess.UnitOfWork;
using Api.Schema.Request;
using Api.Schema.Response;
using AutoMapper;

namespace Api.Business;

public class UserLoginService : GenericService<UserLogin, UserLoginRequest, UserLoginResponse> , IUserLoginService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserLoginService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public string RandomPasswordGenerator()
    {
        Random random = new Random();

        string password = string.Empty;

        for (int i = 0; i < 8; i++)
        {
            password += random.Next(0, 10).ToString();
        }
        //string mdPassword = CreateMD5(password);
        return password;
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

    public override ApiResponse<UserLoginResponse> Insert(UserLoginRequest request)
    {
        request.Password = RandomPasswordGenerator();
        return base.Insert(request);
    }
}

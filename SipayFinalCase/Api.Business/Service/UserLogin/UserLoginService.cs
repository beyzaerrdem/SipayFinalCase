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
        UserLoginRequest request = new UserLoginRequest();
        Random random = new Random();

        string password = string.Empty;

        for (int i = 0; i < 8; i++)
        {
            password += random.Next(0, 10).ToString();
        }

        request.Password = password;

        return request.Password;
    }
}

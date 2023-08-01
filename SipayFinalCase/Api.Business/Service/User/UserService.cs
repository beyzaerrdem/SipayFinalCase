using Api.Business.Service.Generic;
using Api.DataAccess.Models;
using Api.DataAccess.UnitOfWork;
using Api.Schema.Request;
using Api.Schema.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Business;

public class UserService : GenericService<User, UserRequest, UserResponse>, IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
}

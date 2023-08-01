using Api.Business.Service.Generic;
using Api.DataAccess.Models;
using Api.DataAccess.UnitOfWork;
using Api.Schema.Request;
using Api.Schema.Response;
using AutoMapper;

namespace Api.Business;

public class ApartmentService : GenericService<Apartment, ApartmentRequest, ApartmentResponse> , IApartmentService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ApartmentService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
}

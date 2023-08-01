using Api.Business.Service.Generic;
using Api.DataAccess.Models;
using Api.Schema.Request;
using Api.Schema.Response;

namespace Api.Business;

public interface IApartmentService : IGenericService<Apartment, ApartmentRequest, ApartmentResponse>
{

}

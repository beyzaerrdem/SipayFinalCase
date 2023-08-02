using Api.DataAccess.Models;
using Api.Schema.Request;
using Api.Schema.Response;
using AutoMapper;

namespace Api.Schema.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();

            CreateMap<ApartmentRequest, Apartment>();
            CreateMap<Apartment, ApartmentResponse>();

            CreateMap<InvoiceRequest, Invoice>();
            CreateMap<Invoice, InvoiceResponse>();

            CreateMap<VehicleRequest, Vehicle>();
            CreateMap<Vehicle, VehicleResponse>();

            CreateMap<UserLoginRequest, UserLogin>();
            CreateMap<UserLogin, UserLoginResponse>();
        }
    }
}

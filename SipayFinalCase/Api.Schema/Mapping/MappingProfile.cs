using Api.Business.Enums;
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

            CreateMap<ApartmentRequest, Apartment>(); //.ForMember(dest => dest.Block, opt => opt.MapFrom(src => ((ApartmentBlock)src.Block).ToString())); 
            CreateMap<Apartment, ApartmentResponse>();

            CreateMap<InvoiceRequest, Invoice>();
            CreateMap<Invoice, InvoiceResponse>();

            CreateMap<UserLoginRequest, UserLogin>();
            CreateMap<UserLogin, UserLoginResponse>();

            CreateMap<MessageRequest, Message>();
            CreateMap<Message, MessageResponse>();
        }
    }
}

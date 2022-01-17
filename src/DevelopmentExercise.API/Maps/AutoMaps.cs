using AutoMapper;
using DevelopmentExercise.API.DTOs;
using DevelopmentExercise.API.Models;

namespace DevelopmentExercise.API.Maps
{
    public class AutoMaps : Profile
    {
        public AutoMaps()
        {
            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Order, InvoiceOrderDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName.ToUpper()} {src.User.LastName}"))
                .ReverseMap();
            CreateMap<Invoice, GenerateInvoiceDto>().ReverseMap();
        }
    }
}
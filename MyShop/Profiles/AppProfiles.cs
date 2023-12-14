using AutoMapper;
using MyShop.Models;
using MyShop.Models.Dtos;

namespace MyShop.Profiles
{
    public class AppProfiles:Profile
    {
        public AppProfiles()
        {
            CreateMap<AddProductDto, Product>().ReverseMap();
            CreateMap<AddOrderDto, Order>().ReverseMap().ReverseMap();
            CreateMap<OrderResponseDto, OrderResponseDto>().ReverseMap();
            CreateMap<AddOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<AddUserDto , User>().ReverseMap();    
        }
    }
}

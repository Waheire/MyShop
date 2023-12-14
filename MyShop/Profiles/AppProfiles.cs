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
        }
    }
}

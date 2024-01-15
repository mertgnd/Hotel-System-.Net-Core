using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ServiceDtos;

namespace HotelProject.WebUI.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();   
            CreateMap<UpdateServiceDto, Service>().ReverseMap();   
            CreateMap<AddServiceDto, Service>().ReverseMap();   
        }
    }
}

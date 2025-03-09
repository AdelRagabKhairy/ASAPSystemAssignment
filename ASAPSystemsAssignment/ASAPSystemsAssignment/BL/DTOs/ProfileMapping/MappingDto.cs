using ASAPSystemsAssignment.DAL.Model;
using AutoMapper;

namespace ASAPSystemsAssignment.BL.DTOs.ProfileMapping
{
    public class MappingDto:Profile
    {
        public MappingDto()
        {
            CreateMap<ProductAddDto,Product>().ReverseMap();
            CreateMap<ProductDto,Product>().ReverseMap();
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //.ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))


        }
    }
}

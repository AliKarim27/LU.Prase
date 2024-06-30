using AutoMapper;
using LU.Prase.Authorization.Users;
using LU.Prase.Entities;

namespace LU.Prase.Sections.Dto
{
    public class SectionMappingProfile : Profile
    {

        public SectionMappingProfile()
        {
            CreateMap<Section, SectionDto>().ReverseMap();
            CreateMap<Section, CreateSectionDto>().ReverseMap();
            CreateMap<Section, UpdateSectionDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, ResponsibleDto>().ReverseMap();
            CreateMap<DepartementDto, Departement>().ReverseMap();
        }
    }
}

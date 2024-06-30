using AutoMapper;
using LU.Prase.Authorization.Users;
using LU.Prase.Entities;

namespace LU.Prase.Department.Dto
{
    public class DepartementMappingProfile : Profile
    {

        public DepartementMappingProfile()
        {
            CreateMap<Departement, DepartementDto>().ReverseMap();
            CreateMap<Departement, CreateDepartementDto>().ReverseMap();
            CreateMap<Departement, UpdateDepartementDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, ResponsibleDto>().ReverseMap();
        }
    }
}

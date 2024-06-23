using AutoMapper;
using LU.Prase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Machines.Dto
{
    public class PortfolioMappingProfile : Profile
    {

        public PortfolioMappingProfile()
        {
            CreateMap<Machine, MachineDto>().ReverseMap();
            CreateMap<Machine, CreateMachineDto>().ReverseMap();
            CreateMap<Machine, UpdateMachineDto>().ReverseMap();
        }
    }
}

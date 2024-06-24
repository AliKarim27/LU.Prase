using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LU.Prase.Entities;
using LU.Prase.Machines.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Machines
{
    public class MachineAppService : AsyncCrudAppService<Machine, MachineDto, long, PagedMachineRequest, CreateMachineDto, UpdateMachineDto, EntityDto<long>>
    {
        public MachineAppService(IRepository<Machine, long> repository) : base(repository)
        {
        }
    }
}

using Abp.Application.Services;
using LU.Prase.Machines.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Machines
{
    public interface IMachineAppService : IAsyncCrudAppService<MachineDto,long,PagedMachineRequest,CreateMachineDto,UpdateMachineDto,MachineDto> 
    {
       
    }
}

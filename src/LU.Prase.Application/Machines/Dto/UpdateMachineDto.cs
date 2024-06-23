using Abp.Application.Services.Dto;
using LU.Prase.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Machines.Dto
{
    public class UpdateMachineDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public MachineStates MachineStates { get; set; }
    }
}

using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Machines.Dto
{
    public class MachineDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public string MachineStates { get; set; }

    }
}

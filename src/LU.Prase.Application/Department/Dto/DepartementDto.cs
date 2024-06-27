using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Department.Dto
{
    public class DepartementDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public List<ResponsibleDto> Responsibles { get; set; }

    }
}

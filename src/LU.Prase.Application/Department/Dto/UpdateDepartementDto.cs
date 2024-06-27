using Abp.Application.Services.Dto;
using LU.Prase.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Department.Dto
{
    public class UpdateDepartementDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<UserDto> Responsibles { get; set; }
    }
}

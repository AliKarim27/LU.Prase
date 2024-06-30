using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Sections.Dto
{
    public class SectionDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DepartementDto Departement { get; set; }
        public List<ResponsibleDto> Responsibles { get; set; }
        public List<ResponsibleDto> AllResponsibles { get; set; }
        public List<DepartementDto> AllDepartements { get; set; }

    }
}

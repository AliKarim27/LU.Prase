using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Sections.Dto
{
    public class ResponsibleDto : EntityDto<long>
    {
        public string UserName { get; set; }

    }
}

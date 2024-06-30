using Abp.Application.Services;
using LU.Prase.Sections.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Sections
{
    public interface ISectionAppService : IApplicationService
    {
        Task<List<DepartementDto>> GetDepartementsAsync();
    }
}

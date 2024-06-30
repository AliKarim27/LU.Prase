using Abp.Application.Services;
using LU.Prase.Department.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LU.Prase.Department
{
    public interface IDepartementAppService : IApplicationService
    {
        Task<List<ResponsibleDto>> GetAllResponsiblesAsync();
    }
}

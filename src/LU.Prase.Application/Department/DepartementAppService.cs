using Abp.Application.Services;
using Abp.Domain.Repositories;
using LU.Prase.Department.Dto;
using LU.Prase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Department
{
    public class DepartementAppService : AsyncCrudAppService<Departement, DepartementDto, long, PagedDepartementRequest, CreateDepartementDto, UpdateDepartementDto>
    {
        public DepartementAppService(IRepository<Departement, long> repository) : base(repository)
        {
        }
    }
}

using Abp.Application.Services;
using LU.Prase.MultiTenancy.Dto;

namespace LU.Prase.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


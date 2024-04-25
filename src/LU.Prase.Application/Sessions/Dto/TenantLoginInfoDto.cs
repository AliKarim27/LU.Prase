using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LU.Prase.MultiTenancy;

namespace LU.Prase.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using LU.Prase.Authorization.Accounts.Dto;

namespace LU.Prase.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

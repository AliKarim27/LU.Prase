using System.Threading.Tasks;
using Abp.Application.Services;
using LU.Prase.Sessions.Dto;

namespace LU.Prase.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

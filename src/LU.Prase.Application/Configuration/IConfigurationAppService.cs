using System.Threading.Tasks;
using LU.Prase.Configuration.Dto;

namespace LU.Prase.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

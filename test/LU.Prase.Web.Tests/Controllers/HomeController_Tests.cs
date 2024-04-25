using System.Threading.Tasks;
using LU.Prase.Models.TokenAuth;
using LU.Prase.Web.Controllers;
using Shouldly;
using Xunit;

namespace LU.Prase.Web.Tests.Controllers
{
    public class HomeController_Tests: PraseWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
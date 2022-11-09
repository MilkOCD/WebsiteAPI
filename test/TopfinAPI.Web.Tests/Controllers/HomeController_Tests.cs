using System.Threading.Tasks;
using TopfinAPI.Models.TokenAuth;
using TopfinAPI.Web.Controllers;
using Shouldly;
using Xunit;

namespace TopfinAPI.Web.Tests.Controllers
{
    public class HomeController_Tests: TopfinAPIWebTestBase
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
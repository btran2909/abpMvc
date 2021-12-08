using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AbpMvc.Pages
{
    public class Index_Tests : AbpMvcWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}

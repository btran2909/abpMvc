using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace abpMvc.Pages
{
    public class Index_Tests : abpMvcWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}

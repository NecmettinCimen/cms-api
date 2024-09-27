using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class PageControllerTest : BaseControllerTest<Page>
    {
        public PageControllerTest()
        {
            Controller = "Page";
            model = new Page
            {
                Type = "Type",
                Name = "Name",
                Description = "Description"
            };
        }
        [Fact]
        public override async Task GetAll()
        {
            await base.GetAll();
        }
        [Fact]
        public override async Task AddUpdateDeleteAsync()
        {
            await base.AddUpdateDeleteAsync();
        }
    }
}

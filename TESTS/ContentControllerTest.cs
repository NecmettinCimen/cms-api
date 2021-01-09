using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class ContentControllerTest : BaseControllerTest<Content>
    {
        public ContentControllerTest()
        {
            Controller = "Content";
            model = new Content
            {
                Title = "Title",
                Description = "Description",
                Category = "Category",
                Status = ContentStatus.Created
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

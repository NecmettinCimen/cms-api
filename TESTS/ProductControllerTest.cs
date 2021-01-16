using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class ProductControllerTest : BaseControllerTest<Product>
    {
        public ProductControllerTest()
        {
            Controller = "Product";
            model = new Product
            {
                Name = "Name",
                ShortDescription = "ShortDescription",
                Description = "Description",
                Price = 1.1,
                PrimaryPicturePath = "PrimaryPicturePath"
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

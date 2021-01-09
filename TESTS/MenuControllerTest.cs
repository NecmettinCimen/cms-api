using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class MenuControllerTest:BaseControllerTest<Menu>
    {
        public MenuControllerTest()
        {
           Controller="Menu";
           model = new Menu{

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

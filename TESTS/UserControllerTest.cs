using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class UserControllerTest : BaseControllerTest<User>
    {
        public UserControllerTest()
        {
            Controller = "User";
            model = new User
            {

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

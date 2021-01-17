using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class ContactControllerTest : BaseControllerTest<Contact>
    {
        public ContactControllerTest()
        {
            Controller = "Contact";
            model = new Contact
            {
                Name = "Name",
                Email = "Email",
                Description = "Description",
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

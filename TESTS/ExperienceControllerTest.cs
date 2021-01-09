using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class ExperienceControllerTest:BaseControllerTest<Experience>
    {
        public ExperienceControllerTest()
        {
            Controller="Experience";
            model = new Experience{

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

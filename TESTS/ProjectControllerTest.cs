using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class ProjectControllerTest : BaseControllerTest<Project>
    {
        public ProjectControllerTest()
        {
            Controller = "Project";
            model = new Project
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

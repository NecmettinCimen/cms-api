using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class ProjectTechControllerTest : BaseControllerTest<ProjectTech>
    {
        public ProjectTechControllerTest()
        {
            Controller = "ProjectTech";
            model = new ProjectTech
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

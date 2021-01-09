using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class SkillControllerTest : BaseControllerTest<Skill>
    {
        public SkillControllerTest()
        {
            Controller = "Skill";
            model = new Skill
            {
                Name = "Name",
                Description = "Description",
                Icon = "Icon"
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

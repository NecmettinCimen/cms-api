using System;
using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class ExperienceControllerTest : BaseControllerTest<Experience>
    {
        public ExperienceControllerTest()
        {
            Controller = "Experience";
            model = new Experience
            {
                Type = "Type",
                Name = "Name",
                Description = "Description",
                Organization = "Organization",
                OrganizationLink = "OrganizationLink",
                StartingDate = DateTime.Now
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

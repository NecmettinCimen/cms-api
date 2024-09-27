using System;
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
                Type = "Type",
                Name = "Name",
                Description = "Description",
                Date = DateTime.Now,
                Link = "Link"
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

using System.Threading.Tasks;
using cms_api.Models;
using Xunit;

namespace TESTS
{
    public class ParameterControllerTest:BaseControllerTest<Parameter>
    {
        public ParameterControllerTest()
        {
           Controller="Parameter";
           model = new Parameter{

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

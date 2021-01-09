using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParameterController : BaseController<Parameter>
    {
        private readonly IBaseRepository<Parameter> tReposiory;
        public ParameterController(IBaseRepository<Parameter> tReposiory) : base(tReposiory)
        {
            this.tReposiory = tReposiory;
        }
    }
}

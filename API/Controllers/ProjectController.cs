using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectController : BaseController<Project>
    {
        private readonly IBaseRepository<Project> tReposiory;
        public ProjectController(IBaseRepository<Project> tReposiory) : base(tReposiory)
        {
            this.tReposiory = tReposiory;
        }
    }
}

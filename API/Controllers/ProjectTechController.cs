using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectTechController : BaseController<ProjectTech>
    {
        private readonly IBaseRepository<ProjectTech> tReposiory;
        public ProjectTechController(IBaseRepository<ProjectTech> tReposiory) : base(tReposiory)
        {
            this.tReposiory = tReposiory;
        }
    }
}

using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ExperienceController : BaseController<Experience>
    {
        private readonly IBaseRepository<Experience> tReposiory;
        public ExperienceController(IBaseRepository<Experience> tReposiory) : base(tReposiory)
        {
            this.tReposiory = tReposiory;
        }
    }
}

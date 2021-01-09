using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SkillController : BaseController<Skill>
    {
        private readonly IBaseRepository<Skill> tReposiory;
        public SkillController(IBaseRepository<Skill> tReposiory) : base(tReposiory)
        {
            this.tReposiory = tReposiory;
        }
    }
}

using System.IO;
using System.Linq;
using System.Threading.Tasks;
using cms_api.Models;
using cms_api.Repositories;
using cms_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SkillController(IBaseRepository<Skill> tReposiory) : BaseController<Skill>(tReposiory)
    {
        private readonly IBaseRepository<Skill> tReposiory = tReposiory;

        public string SkillIconFolder { get; set; } = "Skill_Icons";

        [Authorize]
        [HttpPost]
        public override async Task<Skill> AddAsync([FromForm] Skill entity)
        {
            if (Request.Form.Files.Any())
            {
                var file = Request.Form.Files.First();
                entity.Icon = await AssetsManageService.Save(SkillIconFolder, file.FileName, file);
            }
            var result = await tReposiory.AddAsync(entity);
            return result;
        }

        [Authorize]
        [HttpPut]
        public override async Task<Skill> UpdateAsync([FromForm] Skill entity)
        {
            if (Request.Form.Files.Any())
            {
                var file = Request.Form.Files.First();
                entity.Icon = await AssetsManageService.Save(SkillIconFolder, file.FileName, file);
            }
            var result = await tReposiory.UpdateAsync(entity);
            return result;
        }
    }
}

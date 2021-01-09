using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MenuController : BaseController<Menu>
    {
        private readonly IBaseRepository<Menu> tReposiory;
        public MenuController(IBaseRepository<Menu> tReposiory) : base(tReposiory)
        {
            this.tReposiory = tReposiory;
        }
    }
}

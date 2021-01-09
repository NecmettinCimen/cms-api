using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PageController : BaseController<Page>
    {
        private readonly IBaseRepository<Page> tReposiory;
        public PageController(IBaseRepository<Page> tReposiory) : base(tReposiory)
        {
            this.tReposiory = tReposiory;
        }
    }
}

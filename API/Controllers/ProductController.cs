using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : BaseController<Product>
    {
        private readonly IBaseRepository<Product> tReposiory;
        public ProductController(IBaseRepository<Product> tReposiory) : base(tReposiory)
        {
            this.tReposiory = tReposiory;
        }
    }
}

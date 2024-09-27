using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParameterController(IBaseRepository<Parameter> tReposiory) : BaseController<Parameter>(tReposiory)
    {
    }
}

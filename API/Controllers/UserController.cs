using System.Threading.Tasks;
using API.Dtos;
using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : BaseController<User>
    {
        private readonly IBaseRepository<User> tReposiory;
        private readonly IUserRepository userReposiory;
        public UserController(IBaseRepository<User> tReposiory,
        IUserRepository userReposiory) : base(tReposiory)
        {
            this.tReposiory = tReposiory;
            this.userReposiory = userReposiory;
        }
        [HttpPost("Authenticate")]
        public async Task<string> Authenticate(LoginDto model)
        {
            return await userReposiory.Authenticate(model);
        }
    }
}

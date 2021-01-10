using System.Threading.Tasks;
using API.Dtos;
using cms_api.Models;
using cms_api.Repositories;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        [Authorize]
        public override async Task<LoadResult> GetAll([FromQuery] DataSourceLoadOptionsBase loadOptions)
        {
            var result = await DataSourceLoader.LoadAsync(tReposiory.GetAll(), loadOptions);
            return result;
        }

        [Authorize]
        [HttpGet("{id}")]
        public override async Task<User> GetById(int id)
        {
            return await tReposiory.GetAll().FirstAsync(f => f.Id == id);
        }
        [HttpPost("Authenticate")]
        public async Task<string> Authenticate(LoginDto model)
        {
            return await userReposiory.Authenticate(model);
        }
    }
}

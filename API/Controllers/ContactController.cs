using System.Threading.Tasks;
using cms_api.Models;
using cms_api.Repositories;
using cms_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace cms_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactController(
        IBaseRepository<Contact> tReposiory,
        IConfiguration configuration)
        : BaseController<Contact>(tReposiory)
    {
        [AllowAnonymous]
        [HttpPost]
        public override async Task<Contact> AddAsync(Contact entity)
        {
            var result = await tReposiory.AddAsync(entity);

            EmailManage.AddEmailQueue(configuration, "Yeni İletişim Formu " + entity.Name + " " + entity.Email, entity.Description, isHtml: false);

            return result;
        }
    }
}

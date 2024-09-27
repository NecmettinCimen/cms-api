using System.Threading.Tasks;
using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace cms_api.Controllers
{
    public class BaseController<TEntity>(IBaseRepository<TEntity> tReposiory) : ControllerBase
        where TEntity : BaseModel, new()
    {
        [HttpGet]
        public virtual async Task<LoadResult> GetAll([FromQuery] DataSourceLoadOptionsBase loadOptions)
        {
            var result = await DataSourceLoader.LoadAsync(tReposiory.GetAll(), loadOptions);
            return result;
        }
        [HttpGet("{id}")]
        public virtual async Task<TEntity> GetById(int id)
        {
            return await tReposiory.GetAll().FirstAsync(f => f.Id == id);
        }
        [Authorize]
        [HttpPost]
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await tReposiory.AddAsync(entity);
            return result;
        }
        [Authorize]
        [HttpPut]
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = await tReposiory.UpdateAsync(entity);
            return result;
        }
        [Authorize]
        [HttpDelete("{id}")]
        public virtual async Task<TEntity> DeleteAsync(int id)
        {
            TEntity entity = await tReposiory.GetAll().FirstAsync(f => f.Id == id);
            var result = await tReposiory.DeleteAsync(entity);
            return result;
        }

    }
}

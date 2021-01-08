using System.Threading.Tasks;
using cms_api.Models;
using cms_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace cms_api.Controllers
{
    public class BaseController<TEntity> : ControllerBase where TEntity : BaseModel, new()
    {
        private readonly IBaseRepository<TEntity> _tReposiory;

        public BaseController(IBaseRepository<TEntity> tReposiory)
        {
            _tReposiory = tReposiory;
        }

        [HttpGet]
        public virtual async Task<LoadResult> GetAll([FromQuery] DataSourceLoadOptionsBase loadOptions)
        {
            var result = await DataSourceLoader.LoadAsync(_tReposiory.GetAll(), loadOptions);
            return result;
        }
        [HttpPost]
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _tReposiory.AddAsync(entity);
            return result;
        }
        [HttpPut]
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = await _tReposiory.UpdateAsync(entity);
            return result;
        }
        [HttpDelete]
        public virtual async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var result = await _tReposiory.DeleteAsync(entity);
            return result;
        }

    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using cms_api.Context;
using cms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cms_api.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseModel, new()
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
    }
    public class BaseRepository<TEntity>(CmsContext cmsContext) : IBaseRepository<TEntity>
        where TEntity : BaseModel, new()
    {
        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return cmsContext.Set<TEntity>().AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                Services.LoggerBackgroundService.kayitsayisi++;

                await cmsContext.AddAsync(entity);
                await cmsContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                if (!await cmsContext.Set<TEntity>().AnyAsync(a => a.Id == entity.Id))
                    throw new Exception($"{nameof(entity)} could not be finded: {entity.Id}");

                Services.LoggerBackgroundService.kayitsayisi++;

                cmsContext.Update(entity);
                await cmsContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            try
            {
                Services.LoggerBackgroundService.kayitsayisi++;

                entity.IsDeleted = true;
                cmsContext.Update(entity);
                await cmsContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }
    }
}
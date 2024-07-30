using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CoffeePattisserie.Data.Concrete.EfCore.Repositories
{
    public class EfCoreGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        public EfCoreGenericRepository(DbContext dbContext){
            _dbContext = dbContext;
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
           await _dbContext.Set<TEntity>().AddAsync(entity);
           await _dbContext.SaveChangesAsync();
           return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
           var entities = await _dbContext.Set<TEntity>().ToListAsync();
           return entities;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            TEntity entity = await _dbContext.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
           EntityEntry<TEntity> result = _dbContext.Set<TEntity>().Update(entity);
           await _dbContext.SaveChangesAsync();
           return entity;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Tcc.AvaliacaoMestrado.Data.Context;
using Tcc.AvaliacaoMestrado.Domain.Models.Interfaces;
using Tcc.AvaliacaoMestrado.Domain.Repositories;

namespace Tcc.AvaliacaoMestrado.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext _context;

        protected BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;    
            await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
            SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result.AsQueryable();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(enitities => enitities.Id == id);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public T Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Set<T>().Update(entity);
            SaveChanges();
            return entity;
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

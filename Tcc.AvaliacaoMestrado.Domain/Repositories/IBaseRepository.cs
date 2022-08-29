using Tcc.AvaliacaoMestrado.Domain.Models.Interfaces;

namespace Tcc.AvaliacaoMestrado.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<IQueryable<T>> GetAllAsync();
        void Delete(T entity);
    }
}

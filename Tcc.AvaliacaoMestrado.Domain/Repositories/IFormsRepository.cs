using Tcc.AvaliacaoMestrado.Domain.Models;

namespace Tcc.AvaliacaoMestrado.Domain.Repositories
{
    public interface IFormsRepository : IBaseRepository<Form>
    {
        Task<Form?> GetByIdAllAsync(Guid id);
        Task<Form?> GetByIdCreatedAsync(Guid id);
    }
}

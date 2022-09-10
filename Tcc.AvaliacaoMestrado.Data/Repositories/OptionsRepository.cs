using Tcc.AvaliacaoMestrado.Data.Context;
using Tcc.AvaliacaoMestrado.Domain.Models;
using Tcc.AvaliacaoMestrado.Domain.Repositories;

namespace Tcc.AvaliacaoMestrado.Data.Repositories
{
    public class OptionsRepository : BaseRepository<Option>, IOptionsRepository
    {
        public OptionsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

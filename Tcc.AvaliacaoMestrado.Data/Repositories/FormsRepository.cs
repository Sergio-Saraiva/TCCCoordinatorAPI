using Tcc.AvaliacaoMestrado.Data.Context;
using Tcc.AvaliacaoMestrado.Domain.Models;
using Tcc.AvaliacaoMestrado.Domain.Repositories;

namespace Tcc.AvaliacaoMestrado.Data.Repositories
{
    public class FormsRepository : BaseRepository<Form>, IFormsRepository
    {
        private readonly ApplicationDbContext _context;
        public FormsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

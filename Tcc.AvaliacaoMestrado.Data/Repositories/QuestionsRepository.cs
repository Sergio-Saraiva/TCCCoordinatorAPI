using Tcc.AvaliacaoMestrado.Data.Context;
using Tcc.AvaliacaoMestrado.Domain.Models;
using Tcc.AvaliacaoMestrado.Domain.Repositories;

namespace Tcc.AvaliacaoMestrado.Data.Repositories
{
    public class QuestionsRepository : BaseRepository<Question>, IQuestionsRepository
    {
        private readonly ApplicationDbContext _context;
        public QuestionsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

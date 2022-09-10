using Tcc.AvaliacaoMestrado.Data.Context;
using Tcc.AvaliacaoMestrado.Domain.Models;
using Tcc.AvaliacaoMestrado.Domain.Repositories;

namespace Tcc.AvaliacaoMestrado.Data.Repositories
{
    public class AnswersRepository : BaseRepository<Answer>, IAnswersRepository
    {
        private readonly ApplicationDbContext _context;
        public AnswersRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Answer> CreateBulk(List<Answer> answers)
        {
            var transaction = _context.Database.BeginTransaction();
            var resultAnswers = new List<Answer>();
            try
            {
                foreach (var answer in answers)
                {
                    answer.CreatedAt = DateTime.Now;
                    answer.UpdatedAt = DateTime.Now;
                    _context.Set<Answer>().Add(answer);
                    _context.SaveChanges();
                    resultAnswers.Add(answer);
                }
                transaction.Commit();
            } catch (Exception ex)
            {
                transaction.Rollback();
            }
            return resultAnswers;
        }
    }
}

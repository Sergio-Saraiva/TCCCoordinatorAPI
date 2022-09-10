using Tcc.AvaliacaoMestrado.Domain.Models;

namespace Tcc.AvaliacaoMestrado.Domain.Repositories
{
    public interface IAnswersRepository : IBaseRepository<Answer>
    {
        List<Answer> CreateBulk(List<Answer> answers);
    }
}

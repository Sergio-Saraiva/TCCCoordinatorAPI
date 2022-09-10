using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Commands.Questions
{
    public class UpdateQuestionCommand : IRequest<Result<QuestionViewModel>>
    {
        public Guid Id { get; set; }
        public string Statement { get; set; }
        public int type { get; set; }
    }
}

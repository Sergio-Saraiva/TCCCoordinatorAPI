using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Commands.Questions
{
    public class CreateQuestionCommand : IRequest<Result<QuestionViewModel>>
    {
        public Guid FormId { get; set; }
        public string Statement { get; set; }
        public int Type { get; set; }
    }
}

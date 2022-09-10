using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Commands.Answers
{
    public class CreateAnswerCommand : IRequest<Result<List<AnswerViewModel>>>
    {
        public Guid FormId { get; set; }
        public List<CreateAnswerArray> Answers { get; set; }
    }

    public class CreateAnswerArray
    {
        public Guid OptionId { get; set; }
        public Guid QuestionId { get; set; }
        public int UserId { get; set; }
    }
}

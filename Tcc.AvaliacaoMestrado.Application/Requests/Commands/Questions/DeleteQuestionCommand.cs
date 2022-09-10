using MediatR;
using OperationResult;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Commands.Questions
{
    public class DeleteQuestionCommand : IRequest<Result>
    {
        public DeleteQuestionCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

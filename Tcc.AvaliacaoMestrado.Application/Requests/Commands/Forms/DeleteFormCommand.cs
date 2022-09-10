using MediatR;
using OperationResult;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Commands.Forms
{
    public class DeleteFormCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public DeleteFormCommand(Guid id)
        {
            Id = id;
        }
    }
}

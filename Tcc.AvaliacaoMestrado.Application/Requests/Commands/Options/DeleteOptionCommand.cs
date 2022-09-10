using MediatR;
using OperationResult;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Commands.Options
{
    public class DeleteOptionCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public DeleteOptionCommand(Guid id)
        {
            Id = id;    
        }
    }
}

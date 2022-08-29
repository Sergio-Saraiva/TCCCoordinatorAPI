using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Commands.Forms
{
    public class UpdateFormCommand : IRequest<Result<FormViewModel>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

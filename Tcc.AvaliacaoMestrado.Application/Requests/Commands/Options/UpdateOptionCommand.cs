using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Commands.Options
{
    public class UpdateOptionCommand : IRequest<Result<OptionViewModel>>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Order { get; set; }
    }
}

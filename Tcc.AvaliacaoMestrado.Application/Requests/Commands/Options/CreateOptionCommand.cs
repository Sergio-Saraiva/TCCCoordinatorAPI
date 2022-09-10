using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Validators;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Commands.Options
{
    public class CreateOptionCommand : IRequest<Result<OptionViewModel>>
    {
        public string Value { get; set; }
        public int Order { get; set; }
        public Guid QuestionId { get; set; }
    }
}

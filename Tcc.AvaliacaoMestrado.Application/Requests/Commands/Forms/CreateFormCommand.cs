using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Validators;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Commands.Forms
{
    public class CreateFormCommand : IRequest<Result<FormViewModel>>, IValidatable
    {
       public string Name { get; set; }
    }
}

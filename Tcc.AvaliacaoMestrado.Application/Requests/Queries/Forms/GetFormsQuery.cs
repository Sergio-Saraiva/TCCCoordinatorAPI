using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Queries.Forms
{
    public class GetFormsQuery : IRequest<Result<List<FormViewModel>>>
    {
    }
}

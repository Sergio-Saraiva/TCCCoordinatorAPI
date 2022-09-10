using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Requests.Queries.Forms
{
    public class GetFormByIdQuery : IRequest<Result<GetByIdFormViewModel>>
    {
        public GetFormByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}

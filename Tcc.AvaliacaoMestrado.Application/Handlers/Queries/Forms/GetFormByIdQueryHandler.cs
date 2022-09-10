using AutoMapper;
using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Queries.Forms;
using Tcc.AvaliacaoMestrado.Domain.Repositories;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Queries.Forms
{
    public class GetFormByIdQueryHandler : IRequestHandler<GetFormByIdQuery, Result<GetByIdFormViewModel>>
    {
        private readonly IFormsRepository _formsRepository;
        private readonly IMapper _mapper;

        public GetFormByIdQueryHandler(IFormsRepository formsRepository, IMapper mapper)
        {
            _formsRepository = formsRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetByIdFormViewModel>> Handle(GetFormByIdQuery request, CancellationToken cancellationToken)
        {
            var form = await _formsRepository.GetByIdAllAsync(request.Id);
            if(form == null)
                return Result.Error<GetByIdFormViewModel>(new Exception("This form was not found"));

            return Result.Success(_mapper.Map<GetByIdFormViewModel>(form));
        }
    }
}

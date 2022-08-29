using AutoMapper;
using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Queries.Forms;
using Tcc.AvaliacaoMestrado.Domain.Repositories;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Queries.Forms
{
    public class GetFormsQueryHandler : IRequestHandler<GetFormsQuery, Result<List<FormViewModel>>>
    {
        private readonly IFormsRepository _formsRepository;
        private readonly IMapper _mapper;
        public GetFormsQueryHandler(IFormsRepository formsRepository, IMapper mapper)
        {
            _formsRepository = formsRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<FormViewModel>>> Handle(GetFormsQuery request, CancellationToken cancellationToken)
        {
            return Result.Success(_mapper.Map<List<FormViewModel>>(await _formsRepository.GetAllAsync()));
        }
    }
}

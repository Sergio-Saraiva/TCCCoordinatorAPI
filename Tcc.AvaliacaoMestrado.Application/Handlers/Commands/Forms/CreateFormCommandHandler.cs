using AutoMapper;
using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Forms;
using Tcc.AvaliacaoMestrado.Domain.Models;
using Tcc.AvaliacaoMestrado.Domain.Repositories;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Commands.Forms
{
    public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, Result<FormViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IFormsRepository _formsRepository;

        public CreateFormCommandHandler(IMapper mapper, IFormsRepository formsRepository)
        {
            _mapper = mapper;
            _formsRepository = formsRepository;
        }

        public async Task<Result<FormViewModel>> Handle(CreateFormCommand request, CancellationToken cancellationToken)
        {
            var form = _mapper.Map<Form>(_mapper.Map<FormViewModel>(request));
            var createdForm = _mapper.Map<FormViewModel>(await _formsRepository.CreateAsync(form));
            return Result.Success(createdForm);
        }
    }
}

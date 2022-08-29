using AutoMapper;
using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Forms;
using Tcc.AvaliacaoMestrado.Domain.Models;
using Tcc.AvaliacaoMestrado.Domain.Repositories;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Commands.Forms
{
    public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, Result<FormViewModel>>
    {
        private readonly IFormsRepository _formsRepository;
        private readonly IMapper _mapper;

        public UpdateFormCommandHandler(IFormsRepository formsRepository, IMapper mapper)
        {
            _formsRepository = formsRepository;
            _mapper = mapper;
        }

        public async Task<Result<FormViewModel>> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
        {
            var form = await _formsRepository.GetByIdAsync(request.Id);
            if (form == null)
                return Result.Error<FormViewModel>(new Exception("This form does not exists"));

            form.Name = request.Name;
            _formsRepository.Update(form);
            return Result.Success(_mapper.Map<FormViewModel>(form));
        }
    }
}

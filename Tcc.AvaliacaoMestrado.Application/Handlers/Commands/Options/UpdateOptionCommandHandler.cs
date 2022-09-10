using AutoMapper;
using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Options;
using Tcc.AvaliacaoMestrado.Domain.Repositories;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Commands.Options
{
    public class UpdateOptionCommandHandler : IRequestHandler<UpdateOptionCommand, Result<OptionViewModel>>
    {
        private readonly IOptionsRepository _optionsRepository;
        private readonly IMapper _mapper;

        public UpdateOptionCommandHandler(IOptionsRepository optionsRepository, IMapper mapper)
        {
            _optionsRepository = optionsRepository;
            _mapper = mapper;
        }

        public async Task<Result<OptionViewModel>> Handle(UpdateOptionCommand request, CancellationToken cancellationToken)
        {
            var option = await _optionsRepository.GetByIdAsync(request.Id);
            if (option == null)
                return Result.Error<OptionViewModel>(new Exception("This options does not exists"));

            option.Value = request.Value;
            option.Order = request.Order;
            return _mapper.Map<OptionViewModel>(_optionsRepository.Update(option));
        }
    }
}

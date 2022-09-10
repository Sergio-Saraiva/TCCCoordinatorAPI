using AutoMapper;
using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Options;
using Tcc.AvaliacaoMestrado.Domain.Models;
using Tcc.AvaliacaoMestrado.Domain.Repositories;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Commands.Options
{
    public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommand, Result<OptionViewModel>>
    {

        private readonly IOptionsRepository _optionsRepository;
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IMapper _mapper;

        public CreateOptionCommandHandler(IOptionsRepository optionsRepository, IMapper mapper, IQuestionsRepository questionsRepository)
        {
            _optionsRepository = optionsRepository;
            _mapper = mapper;
            _questionsRepository = questionsRepository;
        }

        public async Task<Result<OptionViewModel>> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
        {
            var questionExists = await _questionsRepository.GetByIdAsync(request.QuestionId);
            if (questionExists == null)
                return Result.Error<OptionViewModel>(new Exception("This question does not exists"));

            var option = _mapper.Map<Option>(_mapper.Map<OptionViewModel>(request));
            return _mapper.Map<OptionViewModel>(await _optionsRepository.CreateAsync(option));
        }
    }
}

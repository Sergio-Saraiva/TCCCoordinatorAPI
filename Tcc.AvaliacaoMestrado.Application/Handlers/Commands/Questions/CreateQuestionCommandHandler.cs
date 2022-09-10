using AutoMapper;
using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Questions;
using Tcc.AvaliacaoMestrado.Domain.Models;
using Tcc.AvaliacaoMestrado.Domain.Repositories;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Commands.Questions
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Result<QuestionViewModel>>
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IFormsRepository _formsRepository;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(IQuestionsRepository questionsRepository, IFormsRepository formsRepository,IMapper mapper)
        {
            _questionsRepository = questionsRepository;
            _formsRepository = formsRepository;
            _mapper = mapper;
        }

        public async Task<Result<QuestionViewModel>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var formExists = await _formsRepository.GetByIdAsync(request.FormId);
            if (formExists == null)
                return Result.Error<QuestionViewModel>(new Exception("This form was not found."));
            
            if(!formExists.isCreated)
                _formsRepository.Update(formExists);

            var question = await _questionsRepository.CreateAsync(_mapper.Map<Question>(_mapper.Map<QuestionViewModel>(request)));
            return Result.Success(_mapper.Map<QuestionViewModel>(question));
        }
    }
}

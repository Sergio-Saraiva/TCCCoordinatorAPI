using AutoMapper;
using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Questions;
using Tcc.AvaliacaoMestrado.Domain.Repositories;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Commands.Questions
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Result<QuestionViewModel>>
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IMapper _mapper;

        public UpdateQuestionCommandHandler(IQuestionsRepository questionsRepository, IMapper mapper)
        {
            _questionsRepository = questionsRepository;
            _mapper = mapper;
        }

        public async Task<Result<QuestionViewModel>> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _questionsRepository.GetByIdAsync(request.Id);
            if (question == null)
                return Result.Error<QuestionViewModel>(new Exception("This question was not found"));

            question.Statement = request.Statement;
            question.Type = request.type;
            _questionsRepository.Update(question);
            return Result.Success(_mapper.Map<QuestionViewModel>(question));

        }
    }
}

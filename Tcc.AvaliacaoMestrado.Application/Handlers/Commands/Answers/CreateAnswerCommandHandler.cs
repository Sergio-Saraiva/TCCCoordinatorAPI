using AutoMapper;
using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Answers;
using Tcc.AvaliacaoMestrado.Domain.Models;
using Tcc.AvaliacaoMestrado.Domain.Repositories;
using Tcc.AvaliacaoMestrado.Shared.ViewModels;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Commands.Answers
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, Result<List<AnswerViewModel>>>
    {
        private readonly IAnswersRepository _answersRepository;
        private readonly IFormsRepository _formsRepository;
        private readonly IMapper _mapper;

        public CreateAnswerCommandHandler(IAnswersRepository answersRepository, IFormsRepository formsRepository,IMapper mapper)
        {
            _answersRepository = answersRepository;
            _formsRepository = formsRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<AnswerViewModel>>> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {

            var answers = request.Answers;
            var form = await _formsRepository.GetByIdAsync(request.FormId);
            if (form == null)
                return Result.Error<List<AnswerViewModel>>(new Exception("This form does not exists"));

            var checkQuestionResult = CheckQuestionsExistsAndBelongToThisForm(answers, form.Questions);
            if (checkQuestionResult.Success == false)
                return Result.Error<List<AnswerViewModel>>(new Exception(checkQuestionResult.Message));

            var checkOptionResult = CheckIfOptionExistsAndBelongsToTheQuestions(answers, form.Questions);
            if (checkOptionResult.Success == false)
                return Result.Error<List<AnswerViewModel>>(new Exception(checkOptionResult.Message));

            var result = _answersRepository.CreateBulk(_mapper.Map<List<Answer>>(_mapper.Map<List<AnswerViewModel>>(answers)));
            
            return Result.Success(_mapper.Map<List<AnswerViewModel>>(result));
        }
             
        private CheckResult CheckQuestionsExistsAndBelongToThisForm(List<CreateAnswerArray> answers, List<Question> questions)
        {

            var result = new CheckResult();
            result.Success = true;
            answers.ForEach(answer =>
            {
                var questionExists = questions.FirstOrDefault(x => x.Id == answer.QuestionId);
                if(questionExists == null) { 
                    result.Success = false;
                    result.Message = $"The question with id: {answer.QuestionId} does not belong to this form or do not exists";
                }
            });

            return result;
        }

        private CheckResult CheckIfOptionExistsAndBelongsToTheQuestions(List<CreateAnswerArray> answers, List<Question> questions)
        {

            var result = new CheckResult();
            result.Success = true;
            answers.ForEach(answer =>
            {
                var question = questions.FirstOrDefault(x => x.Id == answer.QuestionId);
                if(question != null)
                {
                    var optionExists = question.Options.FirstOrDefault(x => x.Id == answer.OptionId);
                    if (optionExists == null)
                    {
                        result.Success = false;
                        result.Message = $"The option with id: {answer.OptionId} does not belong to the question with id: {question.Id} and statement: {question.Statement}, or do not exists";
                    }
                }
            });

            return result;
        }


        private class CheckResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }
    }
}

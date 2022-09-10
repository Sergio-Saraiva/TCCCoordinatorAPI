using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Questions;
using Tcc.AvaliacaoMestrado.Domain.Repositories;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Commands.Questions
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, Result>
    {
        private readonly IQuestionsRepository _questionsRepository;

        public DeleteQuestionCommandHandler(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task<Result> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _questionsRepository.GetByIdAsync(request.Id);
            if (question == null)
                return Result.Error(new Exception("This question does not exists"));

            _questionsRepository.Delete(question);
            return Result.Success();
        }
    }
}

using FluentValidation;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Answers;

namespace Tcc.AvaliacaoMestrado.Application.Validators.Answers
{
    public class CreateAnswersCommandValidator : AbstractValidator<CreateAnswerCommand>
    {
        public CreateAnswersCommandValidator()
        {
            RuleFor(c => c.FormId).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");
            RuleFor(c => c.Answers).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");
            RuleForEach(c => c.Answers).SetValidator(new CreateAnsersArrayValidator());
        }
    }

    public class CreateAnsersArrayValidator : AbstractValidator<CreateAnswerArray>
    {
        public CreateAnsersArrayValidator()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");
            RuleFor(c => c.QuestionId).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");
            RuleFor(c => c.OptionId).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");
        }
    }
}
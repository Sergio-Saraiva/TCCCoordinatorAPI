using FluentValidation;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Questions;

namespace Tcc.AvaliacaoMestrado.Application.Validators.Questions
{
    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator()
        {
            RuleFor(c => c.FormId).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");
            RuleFor(c => c.Statement).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null")
                .MaximumLength(200).WithMessage("{PropertyName} must have less than 200 characters")
                .MinimumLength(10).WithMessage("{PropertyName} must have more than 10 characters");
            RuleFor(c => c.Type).NotNull().WithMessage("{PropertyName} must not be null")
                .GreaterThan(-1).WithMessage("{PropertyName} must not be between 0 and 1")
                .LessThan(2).WithMessage("{PropertyName} must not be between 0 and 1");
        }
    }
}

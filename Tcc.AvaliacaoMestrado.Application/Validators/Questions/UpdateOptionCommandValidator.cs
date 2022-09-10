using FluentValidation;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Options;

namespace Tcc.AvaliacaoMestrado.Application.Validators.Questions
{
    public class UpdateOptionCommandValidator : AbstractValidator<UpdateOptionCommand>
    {
        public UpdateOptionCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");
            RuleFor(c => c.Value).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null")
                .MaximumLength(20).WithMessage("{PropertyName} must have less than 20 characters")
                .MinimumLength(5).WithMessage("{PropertyName} must have more than 5 characters");
            RuleFor(c => c.Order).NotNull().WithMessage("{PropertyName} must not be null");
        }
    }
}

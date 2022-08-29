using FluentValidation;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Forms;

namespace Tcc.AvaliacaoMestrado.Application.Validators.Forms
{
    public class UpdateFormCommandValidator : AbstractValidator<UpdateFormCommand>
    {
        public UpdateFormCommandValidator()
        {
            RuleFor(c => c.Id).NotNull().WithMessage("{PropertyName} must not be null")
                .NotEmpty().WithMessage("{PropertyName} must not be empty");

            RuleFor(c => c.Name).NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null")
                .MaximumLength(200).WithMessage("{PropertyName} must have less than 200 characters")
                .MinimumLength(3).WithMessage("{PropertyName} must have more than 3 characters");
        }
    }
}

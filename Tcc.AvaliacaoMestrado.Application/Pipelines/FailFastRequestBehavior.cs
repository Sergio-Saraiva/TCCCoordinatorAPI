using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OperationResult;
using System.Reflection;
using Tcc.AvaliacaoMestrado.Application.Validators;
using Tcc.AvaliacaoMestrado.Domain.Exceptions;

namespace Tcc.AvaliacaoMestrado.Application.Pipelines
{
    public sealed class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IValidatable, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;
        private readonly MethodInfo _operationResultError;
        private Type _type = typeof(TResponse);
        private Type _typeOperationResultGeneric = typeof(Result<>);
        private Type _typeOperationResult = typeof(Result);

        public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
            if (_type.IsGenericType)
            {
                _operationResultError = _typeOperationResult.GetMethods().FirstOrDefault(m => m.Name == "Error" && m.IsGenericMethod);
                _operationResultError = _operationResultError.MakeGenericMethod(_type.GetGenericArguments().First());
            }
        }


        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Domain.Exceptions.ValidationException validationError;
            List<ValidationFailure> errors;

            if(_type == _typeOperationResult)
            {
                errors = GetErrors(request);
                if (errors?.Any() != true)
                    return next?.Invoke();

                validationError = new Domain.Exceptions.ValidationException(errors.GroupBy(v => v.PropertyName, v => v.ErrorMessage).ToDictionary(v => v.Key, v => v.Select(y => y)));

                return Task.FromResult((TResponse)Convert.ChangeType(Result.Error(validationError), _type));
            }

            if (!_type.IsGenericType || _type.GetGenericTypeDefinition() != _typeOperationResultGeneric)
                return next?.Invoke();

            errors = GetErrors(request);
            if (errors?.Any() != true)
                return next?.Invoke();

            validationError = new Domain.Exceptions.ValidationException(errors.GroupBy(v => v.PropertyName, v => v.ErrorMessage).ToDictionary(v => v.Key, v => v.Select(y => y)));
            return Task.FromResult((TResponse)Convert.ChangeType(_operationResultError.Invoke(null, new object[] { validationError }), _type));
        }

        private List<ValidationFailure> GetErrors(TRequest request) => _validators
            .Select(v => v.Validate(new ValidationContext<TRequest>(request)))
            .SelectMany(x => x.Errors)
            .Where(f => f != null)
            .ToList();
    }
}

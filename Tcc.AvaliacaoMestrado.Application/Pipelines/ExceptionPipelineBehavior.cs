using MediatR;
using OperationResult;
using Serilog;
using System.Reflection;
using Tcc.AvaliacaoMestrado.Application.Validators;

namespace Tcc.AvaliacaoMestrado.Application.Pipelines
{
    public sealed class ExceptionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IValidatable, IRequest<TResponse>
    {

        private readonly MethodInfo _operationResultError;
        private readonly Type _type = typeof(TResponse);
        private readonly Type _typeOperationResult = typeof(Result);
        private readonly ILogger _logger;

        public ExceptionPipelineBehavior(ILogger logger)
        {
            if(_type.IsGenericType)
            {
                _operationResultError = _typeOperationResult.GetMethods().FirstOrDefault(m => m.Name == "Error" && m.IsGenericMethod);
                _operationResultError = _operationResultError.MakeGenericMethod(_type.GetGenericArguments().First());
            }
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response;
            try
            {
                response = await next().ConfigureAwait(false);
            }
            catch (Exception exception)
            {

                _logger.Error(exception, "Error on request handling");
                response = _type == _typeOperationResult
                    ? (TResponse)Convert.ChangeType(Result.Error(exception), _type)
                    : (TResponse)Convert.ChangeType(_operationResultError.Invoke(null, new object[] { exception }), _type);
            }
            return response;
        }
    }
}

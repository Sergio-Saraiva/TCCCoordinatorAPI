using MediatR;
using OperationResult;
using Serilog;
using System.Reflection;
using Tcc.AvaliacaoMestrado.Application.Validators;

namespace Tcc.AvaliacaoMestrado.Application.Pipelines
{
    public sealed class LoggingRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IValidatable, IRequest<TResponse>
    {
        private readonly ILogger _logger;
        private readonly Type _typeOperationResult = typeof(Result);
        private readonly MethodInfo _operationResultError;
        private readonly Type _type = typeof(TResponse);

        public LoggingRequestBehavior(ILogger logger)
        {
            if (_type.IsGenericType)
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

                var exception = (Exception)_type.GetProperty(nameof(Result.Exception)).GetValue(response);

                if (exception != null)
                    _logger.Error(exception, "Error on request handling");
            } catch(Exception ex)
            {
                response = _type == _typeOperationResult
                    ? (TResponse)Convert.ChangeType(Result.Error(ex), _type)
                    : (TResponse)Convert.ChangeType(_operationResultError.Invoke(null, new object[] { ex }), _type); 
            }

            return response;
        }
    }
}

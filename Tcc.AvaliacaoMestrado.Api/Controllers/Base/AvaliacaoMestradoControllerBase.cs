using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using Tcc.AvaliacaoMestrado.Domain.Exceptions;

namespace Tcc.AvaliacaoMestrado.Api.Controllers.Base
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoMestradoControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        protected AvaliacaoMestradoControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> SendRequest<T>(IRequest<Result<T>> request)
            => await _mediator.Send(request).ConfigureAwait(false) switch
            {
                (true, var result, _) => Ok(result),
                (_, _, var error) => HandleError(error)
            };

        protected async Task<IActionResult> SendRequest(IRequest<Result> request, int statusCode = 200)
            => await _mediator.Send(request).ConfigureAwait(false) switch
            {
                (true, _) => StatusCode(statusCode),
                (_, var error) => HandleError(error)
            };

        private IActionResult HandleError(Exception error)
            => error switch
            {
                ValidationException exception => BadRequest(exception.Errors),
                _ => BadRequest(new ErrorMessage(error.Message))
            };

        private class ErrorMessage
        {
            public ErrorMessage(string message) => Message = message;
            public string Message { get; } 
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tcc.AvaliacaoMestrado.Api.Controllers.Base;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Answers;
using Tcc.AvaliacaoMestrado.Application.Validators;

namespace Tcc.AvaliacaoMestrado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : AvaliacaoMestradoControllerBase, IValidatable
    {
        public AnswersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public Task<IActionResult> CreateAnswer([FromBody] CreateAnswerCommand createAnswerCommand) => SendRequest(createAnswerCommand);
    }
}

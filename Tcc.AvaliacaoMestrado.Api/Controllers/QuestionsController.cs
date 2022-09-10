using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tcc.AvaliacaoMestrado.Api.Controllers.Base;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Questions;
using Tcc.AvaliacaoMestrado.Application.Validators;

namespace Tcc.AvaliacaoMestrado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : AvaliacaoMestradoControllerBase, IValidatable
    {
        public QuestionsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCommand createQuestionCommand) => SendRequest(createQuestionCommand);

        [HttpPut]
        public Task<IActionResult> UpdateQuestion([FromBody] UpdateQuestionCommand updateQuestionCommand) => SendRequest(updateQuestionCommand);
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteQuestion([FromRoute] Guid id) => SendRequest(new DeleteQuestionCommand(id));
    }
}

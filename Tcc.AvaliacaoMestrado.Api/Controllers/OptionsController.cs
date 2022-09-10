using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tcc.AvaliacaoMestrado.Api.Controllers.Base;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Options;
using Tcc.AvaliacaoMestrado.Application.Validators;

namespace Tcc.AvaliacaoMestrado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : AvaliacaoMestradoControllerBase, IValidatable
    {
        public OptionsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public Task<IActionResult> CreateOption([FromBody] CreateOptionCommand createOptionCommand) => SendRequest(createOptionCommand);
        [HttpPut]
        public Task<IActionResult> UpdateOption([FromBody] UpdateOptionCommand updateOptionCommand) => SendRequest(updateOptionCommand);
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteOption([FromRoute] Guid id) => SendRequest(new DeleteOptionCommand(id));
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tcc.AvaliacaoMestrado.Api.Controllers.Base;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Forms;
using Tcc.AvaliacaoMestrado.Application.Requests.Queries;
using Tcc.AvaliacaoMestrado.Application.Requests.Queries.Forms;
using Tcc.AvaliacaoMestrado.Application.Validators;

namespace Tcc.AvaliacaoMestrado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : AvaliacaoMestradoControllerBase, IValidatable
    {

        public FormsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public Task<IActionResult> CreateForm([FromBody] CreateFormCommand createFormCommand) => SendRequest(createFormCommand);

        [HttpGet]
        public Task<IActionResult> GetForms() => SendRequest(new GetFormsQuery());

        [HttpGet("{id}")]
        public Task<IActionResult> GetFormById([FromRoute] Guid id) => SendRequest(new GetFormByIdQuery(id));

        [HttpPut]
        public Task<IActionResult> UpdateForm([FromBody] UpdateFormCommand updateFormCommand) => SendRequest(updateFormCommand);

    }
}

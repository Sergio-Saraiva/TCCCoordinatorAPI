using AutoMapper;
using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Forms;
using Tcc.AvaliacaoMestrado.Domain.Repositories;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Commands.Forms
{
    public class DeleteFormCommandHandler : IRequestHandler<DeleteFormCommand, Result>
    {
        private readonly IFormsRepository _formsRepository;

        public DeleteFormCommandHandler(IFormsRepository formsRepository, IMapper mapper)
        {
            _formsRepository = formsRepository;
        }

        public async Task<Result> Handle(DeleteFormCommand request, CancellationToken cancellationToken)
        {
            var form = await _formsRepository.GetByIdAllAsync(request.Id);
            if (form == null)
                return Result.Error(new Exception("This form does not exists"));

            _formsRepository.Delete(form);

            return Result.Success();
        }
    }
}

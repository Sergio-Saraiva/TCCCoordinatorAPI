using MediatR;
using OperationResult;
using Tcc.AvaliacaoMestrado.Application.Requests.Commands.Options;
using Tcc.AvaliacaoMestrado.Domain.Repositories;

namespace Tcc.AvaliacaoMestrado.Application.Handlers.Commands.Options
{
    public class DeleteOptionCommandHandler : IRequestHandler<DeleteOptionCommand, Result>
    {
        private readonly IOptionsRepository _optionsRepository;

        public DeleteOptionCommandHandler(IOptionsRepository optionsRepository)
        {
            _optionsRepository = optionsRepository;
        }

        public async Task<Result> Handle(DeleteOptionCommand request, CancellationToken cancellationToken)
        {
            var option = await _optionsRepository.GetByIdAsync(request.Id);
            if (option == null)
                return Result.Error(new Exception("This options does not exists"));

            _optionsRepository.Delete(option);
            return Result.Success();
        }
    }
}

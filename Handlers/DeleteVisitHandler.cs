using MediatR;
using ScrubChartAiTest.Commands;
using ScrubChartAiTest.Repositories;

namespace ScrubChartAiTest.Handlers
{
    public class DeleteVisitHandler : IRequestHandler<DeleteVisitCommand, int>
    {
        private readonly IVisitRepository _repository;

        public DeleteVisitHandler(IVisitRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteVisitCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var item = await _repository.GetVisitByIdAsync(command.Id, cancellationToken);
            if (item == null)
                return default;

            return await _repository.DeleteVisitAsync(command.Id);
        }
    }
}

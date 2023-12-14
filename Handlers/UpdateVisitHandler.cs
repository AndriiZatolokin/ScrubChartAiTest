using MediatR;
using ScrubChartAiTest.Commands;
using ScrubChartAiTest.Models;
using ScrubChartAiTest.Repositories;

namespace ScrubChartAiTest.Handlers
{
    public class UpdateVisitHandler : IRequestHandler<UpdateVisitCommand, int>
    {
        private readonly IVisitRepository _repository;

        public UpdateVisitHandler(IVisitRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateVisitCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var item = await _repository.GetVisitByIdAsync(command.Id, cancellationToken);
            if (item == null)
                return default;

            item.StartDate = command.StartDate;
            item.EndDate = command.EndDate;
            item.DoctorId = command.DoctorId;
            item.PatientId = command.PatientId;
            item.PatientName = command.PatientName;

            return await _repository.UpdateVisitAsync(item);
        }
    }
}

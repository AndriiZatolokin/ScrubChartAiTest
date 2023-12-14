using MediatR;
using ScrubChartAiTest.Commands;
using ScrubChartAiTest.Models;
using ScrubChartAiTest.Repositories;

namespace ScrubChartAiTest.Handlers
{
    public class CreateVisitHandler : IRequestHandler<CreateVisitCommand, Visit>
    {
        private readonly IVisitRepository _repository;

        public CreateVisitHandler(IVisitRepository repository)
        {
            _repository = repository;
        }

        public async Task<Visit> Handle(CreateVisitCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var item = new Visit()
            {
                StartDate  = command.StartDate,
                EndDate = command.EndDate,
                DoctorId = command.DoctorId,
                PatientId = command.PatientId,
                PatientName = command.PatientName
            };

            return await _repository.AddVisitAsync(item);
        }
    }
}

using MediatR;
using ScrubChartAiTest.Models;
using ScrubChartAiTest.Queries;
using ScrubChartAiTest.Repositories;

namespace ScrubChartAiTest.Handlers
{
    public class GetVisitByPatientNameHandler : IRequestHandler<GetVisitByPatientNameQuery, List<Visit>>
    {
        private readonly IVisitRepository _repository;

        public GetVisitByPatientNameHandler(IVisitRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Visit>> Handle(GetVisitByPatientNameQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetVisitByPatienNameAsync(query.PatientName, cancellationToken);
        }
    }
}

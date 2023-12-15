using MediatR;
using ScrubChartAiTest.Models;
using ScrubChartAiTest.Queries;
using ScrubChartAiTest.Repositories;

namespace ScrubChartAiTest.Handlers
{
    public class GetVisitListHandler : IRequestHandler<GetVisitListQuery, List<Visit>>
    {
        private readonly IVisitRepository _repository;

        public GetVisitListHandler(IVisitRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Visit>> Handle(GetVisitListQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetVisitListAsync(query.PatientName, query.DateTime, cancellationToken);
        }
    }
}

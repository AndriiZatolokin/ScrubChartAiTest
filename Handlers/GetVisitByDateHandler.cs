using MediatR;
using ScrubChartAiTest.Models;
using ScrubChartAiTest.Queries;
using ScrubChartAiTest.Repositories;

namespace ScrubChartAiTest.Handlers
{
    public class GetVisitByDateHandler : IRequestHandler<GetVisitByDateQuery, List<Visit>>
    {
        private readonly IVisitRepository _repository;

        public GetVisitByDateHandler(IVisitRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Visit>> Handle(GetVisitByDateQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetVisitByStartDateAsync(query.DateTime, cancellationToken);
        }
    }
}

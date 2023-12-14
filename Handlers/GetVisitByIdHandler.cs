using MediatR;
using ScrubChartAiTest.Models;
using ScrubChartAiTest.Queries;
using ScrubChartAiTest.Repositories;

namespace ScrubChartAiTest.Handlers
{
    public class GetVisitByIdHandler : IRequestHandler<GetVisitByIdQuery, Visit?>
    {
        private readonly IVisitRepository _repository;

        public GetVisitByIdHandler(IVisitRepository repository)
        {
            _repository = repository;
        }

        public async Task<Visit?> Handle(GetVisitByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetVisitByIdAsync(query.Id, cancellationToken);
        }
    }
}

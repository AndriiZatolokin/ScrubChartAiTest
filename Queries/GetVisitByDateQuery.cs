using MediatR;
using ScrubChartAiTest.Models;

namespace ScrubChartAiTest.Queries
{
    public class GetVisitByDateQuery : IRequest<List<Visit>>
    {
        public DateTime DateTime { get; set; }
    }
}

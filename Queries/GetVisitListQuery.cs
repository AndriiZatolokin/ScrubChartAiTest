using MediatR;
using ScrubChartAiTest.Models;

namespace ScrubChartAiTest.Queries
{
    public class GetVisitListQuery : IRequest<List<Visit>>
    {
        public string? PatientName { get; set; }

        public DateTime? DateTime { get; set; }
    }
}

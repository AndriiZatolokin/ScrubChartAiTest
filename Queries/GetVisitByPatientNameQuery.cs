using MediatR;
using ScrubChartAiTest.Models;

namespace ScrubChartAiTest.Queries
{
    public class GetVisitByPatientNameQuery : IRequest<List<Visit>>
    {
        public required string PatientName { get; set; }
    }
}

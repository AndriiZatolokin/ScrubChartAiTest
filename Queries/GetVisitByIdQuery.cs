using MediatR;
using ScrubChartAiTest.Models;

namespace ScrubChartAiTest.Queries
{
    public class GetVisitByIdQuery : IRequest<Visit?>
    {
        public int Id { get; set; }
    }
}

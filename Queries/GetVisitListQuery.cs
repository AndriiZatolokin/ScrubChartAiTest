using MediatR;
using ScrubChartAiTest.Models;

namespace ScrubChartAiTest.Queries
{
    public class GetVisitListQuery : IRequest<List<Visit>>
    {
    }
}

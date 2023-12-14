using MediatR;

namespace ScrubChartAiTest.Commands
{
    public class DeleteVisitCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

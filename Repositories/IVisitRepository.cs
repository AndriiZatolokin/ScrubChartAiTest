using ScrubChartAiTest.Models;

namespace ScrubChartAiTest.Repositories
{
    public interface IVisitRepository
    {
        public Task<List<Visit>> GetVisitListAsync(string? parienName, DateTime? startDate, CancellationToken cancellationToken);
        public Task<List<Visit>> GetVisitByStartDateAsync(DateTime startDate, CancellationToken cancellationToken);
        public Task<List<Visit>> GetVisitByPatienNameAsync(string parienName, CancellationToken cancellationToken);
        public Task<Visit?> GetVisitByIdAsync(int Id, CancellationToken cancellationToken);
        public Task<Visit> AddVisitAsync(Visit visit);
        public Task<int> UpdateVisitAsync(Visit visit);
        public Task<int> DeleteVisitAsync(int Id);
    }
}

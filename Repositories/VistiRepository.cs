using Microsoft.EntityFrameworkCore;
using ScrubChartAiTest.DataBase;
using ScrubChartAiTest.Models;

namespace ScrubChartAiTest.Repositories
{
    public class VistiRepository : IVisitRepository
    {
        private readonly AppDBContext _dbContext;

        public VistiRepository(AppDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Visit> AddVisitAsync(Visit visit)
        {
            //Code just for testing
            await CheckRelations(visit);

            var result = _dbContext.Visits.Add(visit);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteVisitAsync(int Id)
        {
            var filteredData = _dbContext.Visits.Where(x => x.Id == Id).FirstOrDefault();
            if (filteredData != null)
            {
                _dbContext.Visits.Remove(filteredData);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Visit?> GetVisitByIdAsync(int Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Visits.Where(x => x.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Visit>> GetVisitByPatienNameAsync(string parienName, CancellationToken cancellationToken)
        {
            return await _dbContext.Visits.Where(v => v.PatientName == parienName).ToListAsync(cancellationToken);
        }

        public async Task<List<Visit>> GetVisitByStartDateAsync(DateTime startDate, CancellationToken cancellationToken)
        {
            return await _dbContext.Visits.Where(v => v.StartDate == startDate).ToListAsync(cancellationToken);
        }

        public async Task<List<Visit>> GetVisitListAsync(string? parienName, DateTime? startDate, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var visits = _dbContext.Visits.AsQueryable();
            if (parienName != null)
            {
                visits = visits.Where(v => v.PatientName == parienName);
            }
            if (startDate != null)
            {
                visits = visits.Where(v => v.StartDate == startDate);
            }

            return await visits.ToListAsync(cancellationToken);
        }

        public async Task<int> UpdateVisitAsync(Visit visit)
        {
            //Code just for testing
            await CheckRelations(visit);

            _dbContext.Visits.Update(visit);
            return await _dbContext.SaveChangesAsync();
        }

        private async Task CheckRelations(Visit visit)
        {
            //code for easy testing
            var doctorId = visit.DoctorId;
            var isDoctorExist = _dbContext.Doctors.SingleOrDefault(d => d.Id == doctorId) != null ? true : false;
            if (isDoctorExist == false)
            {
                _dbContext.Doctors.Add(new Doctor() { Id = doctorId });
                await _dbContext.SaveChangesAsync();
            }

            var patientId = visit.PatientId;
            var isPatientExist = _dbContext.Patients.SingleOrDefault(p => p.Id == patientId) != null ? true : false;
            if (isPatientExist == false)
            {
                _dbContext.Patients.Add(new Patient() { Id = patientId });
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

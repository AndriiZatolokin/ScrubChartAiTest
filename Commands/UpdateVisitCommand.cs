using MediatR;
using ScrubChartAiTest.Models;

namespace ScrubChartAiTest.Commands
{
    public class UpdateVisitCommand : IRequest<int>
    {
        public int Id {  get; set; } 

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public int DoctorId { get; set; }

        public UpdateVisitCommand(int id, DateTime startDate, DateTime endDate, int patientId, string patientName, int doctorId)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            PatientName = patientName;
            PatientId = patientId;
            DoctorId = doctorId;
        }
    }
}

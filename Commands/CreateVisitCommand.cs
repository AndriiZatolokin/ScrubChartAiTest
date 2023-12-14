using MediatR;
using ScrubChartAiTest.Models;
using System.ComponentModel.DataAnnotations;

namespace ScrubChartAiTest.Commands
{
    public class CreateVisitCommand : IRequest<Visit>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public int DoctorId { get; set; }

        public CreateVisitCommand(DateTime startDate, DateTime endDate, int patientId, string patientName, int doctorId)
        {
            StartDate = startDate;
            EndDate = endDate;
            PatientName = patientName;
            PatientId = patientId;
            DoctorId = doctorId;
        }
    }
}

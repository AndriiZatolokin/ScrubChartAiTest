namespace ScrubChartAiTest.Models
{
    public class Visit : Entity
    {
        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }

        public required int PatientId { get; set; }

        public required string PatientName { get; set;}

        public required int DoctorId { get; set; }
    }
}

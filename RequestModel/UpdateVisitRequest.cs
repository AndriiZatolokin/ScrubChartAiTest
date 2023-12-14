namespace ScrubChartAiTest.RequestModel
{
    public class UpdateVisitRequest
    {
        public required int Id { get; set; }

        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }

        public required int PatientId { get; set; }

        public required string PatientName { get; set; }

        public required int DoctorId { get; set; }
    }
}

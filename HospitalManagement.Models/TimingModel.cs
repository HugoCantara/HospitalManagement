/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Models
{
    using HospitalManagement.Models.Enumerations;

    /// <summary>Timing Model Class</summary>
    public class Timing
    {
        public int Id { get; set; }
        public ApplicationUser DoctorId { get; set; }
        public DateTime Date { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
    }
}
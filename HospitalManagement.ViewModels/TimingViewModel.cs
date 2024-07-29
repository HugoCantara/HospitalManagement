/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.ViewModels
{
    using HospitalManagement.Models;
    using HospitalManagement.Models.Enumerations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    /// <summary>Timing View Model Class</summary>
    public class TimingViewModel
    {
        public int Id { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        public ApplicationUser Doctor { get; set; }

        List<SelectListItem> MorningShiftStart = new List<SelectListItem>();
        List<SelectListItem> MorningShiftEnd = new List<SelectListItem>();
        List<SelectListItem> AfternoonShiftStart = new List<SelectListItem>();
        List<SelectListItem> AfternoonShiftEnd = new List<SelectListItem>();
        

        public TimingViewModel() { }

        public TimingViewModel(Timing model)
        {
            Id = model.Id;
            ScheduleDate = model.Date;
            MorningShiftStartTime = model.MorningShiftStartTime;
            MorningShiftEndTime = model.MorningShiftEndTime;
            AfternoonShiftStartTime = model.AfternoonShiftStartTime;
            AfternoonShiftEndTime = model.AfternoonShiftEndTime;
            Duration = model.Duration;
            Status = model.Status;
            Doctor = model.Doctor;
        }

        public Timing ConvertViewModel(TimingViewModel viewModel)
        {
            return new Timing
            {
                Id = viewModel.Id,
                Date = viewModel.ScheduleDate,
                MorningShiftStartTime = viewModel.MorningShiftStartTime,
                MorningShiftEndTime = viewModel.MorningShiftEndTime,
                AfternoonShiftStartTime = viewModel.AfternoonShiftStartTime,
                AfternoonShiftEndTime = viewModel.AfternoonShiftEndTime,
                Duration = viewModel.Duration,
                Status = viewModel.Status,
                Doctor = viewModel.Doctor
            };
        }
    }
}

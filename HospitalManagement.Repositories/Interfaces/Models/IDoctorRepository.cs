/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories.Interfaces.Models
{
    using HospitalManagement.Models;
    using HospitalManagement.ViewModels;

    /// <summary>Doctors Repository Interface</summary>
    public interface IDoctorRepository
    {
        IEnumerable<TimingViewModel> GetAll();
        PagedResult<TimingViewModel> GetAllWithPagination(int pageNumber, int pageSize);
        TimingViewModel GetTimingById(int id);
        void InsertTiming(TimingViewModel viewModel);
        void UpdateTiming(TimingViewModel viewModel);
        void DeleteTiming(int id);
    }
}

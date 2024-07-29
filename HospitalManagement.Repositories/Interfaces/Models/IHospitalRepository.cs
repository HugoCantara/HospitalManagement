/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories.Interfaces.Models
{
    using HospitalManagement.Models;
    using HospitalManagement.ViewModels;

    /// <summary>Hospital Repository Interface</summary>
    public interface IHospitalRepository
    {
        IEnumerable<HospitalViewModel> GetAll();
        PagedResult<HospitalViewModel> GetAllWithPagination(int pageNumber, int pageSize);
        HospitalViewModel GetHospitalById(int id);
        void InsertHospital(HospitalViewModel viewModel);
        void UpdateHospital(HospitalViewModel viewModel);
        void DeleteHospital(int id);
    }
}

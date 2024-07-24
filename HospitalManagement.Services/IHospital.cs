/// <summary>Hospital Interface</summary>
namespace HospitalManagement.Services
{
    using HospitalManagement.Models;
    using HospitalManagement.ViewModels;

    public interface IHospital
    {
        PagedResult<HospitalViewModel> GetAll(int pageNumber, int pageSize);
        HospitalViewModel GetHospitalById(int id);
        void UpdateHospital(HospitalViewModel hospital);
        void InsertHospital(HospitalViewModel hospital);
        void DeleteHospital(int id);
    }
}
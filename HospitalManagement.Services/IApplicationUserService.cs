/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Services
{
    using HospitalManagement.Models;
    using HospitalManagement.ViewModels;

    /// <summary>Application User Interface</summary>
    public interface IApplicationUserService
    {
        PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> GetAllDoctors(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> GetAllPatients(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Speciality);
    }
}

/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories.Interfaces.Models
{
    using HospitalManagement.Models;
    using HospitalManagement.ViewModels;

    /// <summary>Users Repository Interface</summary>
    public interface IUserRepository
    {
        PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize);
        PagedResult<ApplicationUserViewModel> GetAllDoctors(int pageNumber, int pageSize);
        PagedResult<ApplicationUserViewModel> GetAllPatients(int pageNumber, int pageSize);
        PagedResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize, string speciality);
    }
}
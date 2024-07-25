/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Services
{
    using HospitalManagement.Models;
    using HospitalManagement.ViewModels;

    /// <summary>Hospital Service Interface</summary>
    public interface IHospitalService
    {
        /// <summary>Get All Hospital</summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>PagedResult<HospitalViewModel></returns>
        PagedResult<HospitalViewModel> GetAll(int pageNumber, int pageSize);

        /// <summary>Get Hospital by Identifier</summary>
        /// <param name="id">Hospital Identifier</param>
        /// <returns>HospitalViewModel</returns>
        HospitalViewModel GetHospitalById(int id);

        /// <summary>Insert Hospital</summary>
        /// <param name="viewModel">Hospital View Model</param>
        void InsertHospital(HospitalViewModel viewModel);

        /// <summary>Update Hospital</summary>
        /// <param name="viewModel">Hospital View Model</param>
        void UpdateHospital(HospitalViewModel viewModel);
        
        /// <summary>Delete Hospital</summary>
        /// <param name="id">Hospital Identifier</param>
        void DeleteHospital(int id);
    }
}
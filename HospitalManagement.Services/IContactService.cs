/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Services
{
    using HospitalManagement.Models;
    using HospitalManagement.ViewModels;

    /// <summary>Contact Service Interface</summary>
    public interface IContactService
    {
        /// <summary>Get All Contact</summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>PagedResult<ContactViewModel></returns>
        PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize);

        /// <summary>Get Contact by Identifier</summary>
        /// <param name="id">Contact Identifier</param>
        /// <returns>ContactViewModel</returns>
        ContactViewModel GetContactById(int id);

        /// <summary>Insert Contact</summary>
        /// <param name="viewModel">Contact View Model</param>
        void InsertContact(ContactViewModel viewModel);

        /// <summary>Update Contact</summary>
        /// <param name="viewModel">Contact View Model</param>
        void UpdateContact(ContactViewModel viewModel);

        /// <summary>Delete Contact</summary>
        /// <param name="id">Contact Identifier</param>
        void DeleteContact(int id);
    }
}

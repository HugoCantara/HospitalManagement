/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories.Interfaces.Models
{
    using HospitalManagement.Models;
    using HospitalManagement.ViewModels;

    /// <summary>Contact Repository Interface</summary>
    public interface IContactRepository
    {
        IEnumerable<ContactViewModel> GetAll();
        PagedResult<ContactViewModel> GetAllWithPagination(int pageNumber, int pageSize);
        ContactViewModel GetContactById(int id);
        void InsertContact(ContactViewModel viewModel);
        void UpdateContact(ContactViewModel viewModel);
        void DeleteContact(int id);
    }
}

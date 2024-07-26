/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interfaces;
    using HospitalManagement.Services;
    using HospitalManagement.ViewModels;

    /// <summary>Contact Service Class</summary>
    public class ContactService : IContactService
    {
        /// <summary>Unit Of Work</summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>Constructor</summary>
        /// <param name="unitOfWork">Unit Of Work</param>
        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>Get All Contacts</summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>PagedResult<ContactViewModel></returns>
        public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            var contactViewModelCollection = new List<ContactViewModel>();
            int totalRecords;
            
            try
            {
                int records = (pageSize * pageNumber) - pageSize;
                var modelCollection = _unitOfWork.GenericRepository<Contact>().GetAll(includeProperties:"Hospital").Skip(records).Take(pageSize).ToList();
                totalRecords = _unitOfWork.GenericRepository<Contact>().GetAll().ToList().Count;
                contactViewModelCollection = GetContactViewModelCollection(modelCollection);
            }
            catch (Exception)
            {
                throw;
            }

            return new PagedResult<ContactViewModel>
            {
                Data = contactViewModelCollection,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        /// <summary>Get Contact by Identifier</summary>
        /// <param name="id">Identifier</param>
        /// <returns>ContactViewModel</returns>
        public ContactViewModel GetContactById(int id)
        {
            return new ContactViewModel(_unitOfWork.GenericRepository<Contact>().GetById(id));
        }

        /// <summary>Insert Contact</summary>
        /// <param name="viewModel">Contact View Model</param>
        public void InsertContact(ContactViewModel viewModel)
        {
            _unitOfWork.GenericRepository<Contact>().Add(new ContactViewModel().ConvertViewModel(viewModel));
            _unitOfWork.Save();
        }

        /// <summary>Update Contact</summary>
        /// <param name="viewModel">Contact View Model</param>
        public void UpdateContact(ContactViewModel viewModel)
        {
            var model = new ContactViewModel().ConvertViewModel(viewModel);
            var modelById = _unitOfWork.GenericRepository<Contact>().GetById(model.Id);
            modelById.HospitalId = viewModel.HospitalId;
            modelById.Email = viewModel.Email;
            modelById.Phone = viewModel.Phone;
            _unitOfWork.GenericRepository<Contact>().Update(modelById);
            _unitOfWork.Save();
        }

        /// <summary>Delete Contact</summary>
        /// <param name="id">Contact Identifier</param>
        public void DeleteContact(int id)
        {
            _unitOfWork.GenericRepository<Contact>().Delete(_unitOfWork.GenericRepository<Contact>().GetById(id));
            _unitOfWork.Save();
        }

        /// <summary>Convert Model to View Model Collection</summary>
        /// <param name="contactCollection">Contact Model Collection</param>
        /// <returns>List<ContactViewModel></returns>
        private List<ContactViewModel> GetContactViewModelCollection(List<Contact> contactCollection)
        {
            return contactCollection.Select(x => new ContactViewModel(x)).ToList();
        }
    }
}

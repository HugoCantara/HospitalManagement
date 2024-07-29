/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories.Repositories.Models
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interfaces;
    using HospitalManagement.Repositories.Interfaces.Models;
    using HospitalManagement.ViewModels;
    using System.Collections.Generic;

    /// <summary>Contact Repository</summary>
    public class ContactRepository : IContactRepository
    {
        private IUnitOfWork _unitOfWork;

        public ContactRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ContactViewModel> GetAll()
        {
            var collection = _unitOfWork.GenericRepository<Contact>().GetAll(includeProperties: "Hospital").ToList();
            return this.ConvertToViewModelCollection(collection);
        }

        public PagedResult<ContactViewModel> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var viewModelCollection = new List<ContactViewModel>();
            int totalRecords;

            try
            {
                int records = (pageSize * pageNumber) - pageSize;
                var modelCollection = _unitOfWork.GenericRepository<Contact>().GetAll(includeProperties: "Hospital").Skip(records).Take(pageSize).ToList();
                totalRecords = _unitOfWork.GenericRepository<Contact>().GetAll().ToList().Count;
                viewModelCollection = this.ConvertToViewModelCollection(modelCollection);
            }
            catch (Exception)
            {
                throw;
            }

            return new PagedResult<ContactViewModel>
            {
                Data = viewModelCollection,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public ContactViewModel GetContactById(int id)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(id);
            return new ContactViewModel(model);
        }

        public void InsertContact(ContactViewModel viewModel)
        {
            var model = new ContactViewModel().ConvertViewModel(viewModel);
            _unitOfWork.GenericRepository<Contact>().Add(model);
            _unitOfWork.Save();
        }

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

        public void DeleteContact(int id)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(id);
            _unitOfWork.GenericRepository<Contact>().Delete(model);
            _unitOfWork.Save();
        }

        private List<ContactViewModel> ConvertToViewModelCollection(List<Contact> collection)
        {
            return collection.Select(x => new ContactViewModel(x)).ToList();
        }
    }
}
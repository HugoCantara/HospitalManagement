/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories.Repositories.Models
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interfaces;
    using HospitalManagement.Repositories.Interfaces.Models;
    using HospitalManagement.ViewModels;
    using System.Collections.Generic;

    /// <summary>Hospital Repository</summary>
    public class HospitalRepository : IHospitalRepository
    {
        private IUnitOfWork _unitOfWork;

        public HospitalRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<HospitalViewModel> GetAll()
        {
            var collection = _unitOfWork.GenericRepository<Hospital>().GetAll().ToList();
            return this.ConvertToViewModelCollection(collection);
        }

        public PagedResult<HospitalViewModel> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var viewModelCollection = new List<HospitalViewModel>();
            int totalRecords;

            try
            {
                int records = (pageSize * pageNumber) - pageSize;
                var modelCollection = _unitOfWork.GenericRepository<Hospital>().GetAll().Skip(records).Take(pageSize).ToList();
                totalRecords = _unitOfWork.GenericRepository<Hospital>().GetAll().ToList().Count;
                viewModelCollection = this.ConvertToViewModelCollection(modelCollection);
            }
            catch (Exception)
            {
                throw;
            }

            return new PagedResult<HospitalViewModel>
            {
                Data = viewModelCollection,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public HospitalViewModel GetHospitalById(int id)
        {
            var model = _unitOfWork.GenericRepository<Hospital>().GetById(id);
            return new HospitalViewModel(model);
        }

        public void InsertHospital(HospitalViewModel viewModel)
        {
            var model = new HospitalViewModel().ConvertViewModel(viewModel);
            _unitOfWork.GenericRepository<Hospital>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateHospital(HospitalViewModel viewModel)
        {
            var model = new HospitalViewModel().ConvertViewModel(viewModel);
            var modelById = _unitOfWork.GenericRepository<Hospital>().GetById(model.Id);
            modelById.Name = viewModel.Name;
            modelById.City = viewModel.City;
            modelById.PinCode = viewModel.PinCode;
            modelById.Country = viewModel.Country;
            _unitOfWork.GenericRepository<Hospital>().Update(modelById);
            _unitOfWork.Save();
        }

        public void DeleteHospital(int id)
        {
            var model = _unitOfWork.GenericRepository<Hospital>().GetById(id);
            _unitOfWork.GenericRepository<Hospital>().Delete(model);
            _unitOfWork.Save();
        }

        private List<HospitalViewModel> ConvertToViewModelCollection(List<Hospital> collection)
        {
            return collection.Select(x => new HospitalViewModel(x)).ToList();
        }
    }
}

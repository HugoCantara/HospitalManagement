/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interfaces;
    using HospitalManagement.Services;
    using HospitalManagement.ViewModels;

    /// <summary>Hospital Service Class</summary>
    public class HospitalService : IHospitalService
    {
        /// <summary>Unit Of Work</summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>Constructor</summary>
        /// <param name="unitOfWork">Unit Of Work</param>
        public HospitalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>Get All Hospitals</summary>
        /// <returns>List<HospitalViewModel></returns>
        public List<HospitalViewModel> GetAll() 
        {
            var hospitalViewModelCollection = new List<HospitalViewModel>();
           
            try
            {
                
                var modelCollection = _unitOfWork.GenericRepository<Hospital>().GetAll().ToList();
                hospitalViewModelCollection = GetHospitalViewModelCollection(modelCollection);
            }
            catch (Exception)
            {
                throw;
            }

            return hospitalViewModelCollection;
        }

        /// <summary>Get All Hospitals</summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>PagedResult<HospitalViewModel></returns>
        public PagedResult<HospitalViewModel> GetAll(int pageNumber, int pageSize)
        {
            var hospitalViewModelCollection = new List<HospitalViewModel>();
            int totalRecords;
            
            try 
            {
                int records = (pageSize * pageNumber) - pageSize;
                var modelCollection = _unitOfWork.GenericRepository<Hospital>().GetAll().Skip(records).Take(pageSize).ToList();
                totalRecords = _unitOfWork.GenericRepository<Hospital>().GetAll().ToList().Count;
                hospitalViewModelCollection = GetHospitalViewModelCollection(modelCollection);
            }
            catch (Exception) 
            {
                throw;
            }

            return new PagedResult<HospitalViewModel>
            {
                Data = hospitalViewModelCollection,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        /// <summary>Get Hospital by Identifier</summary>
        /// <param name="id">Identifier</param>
        /// <returns>HospitalViewModel</returns>
        public HospitalViewModel GetHospitalById(int id)
        {
            return new HospitalViewModel(_unitOfWork.GenericRepository<Hospital>().GetById(id));
        }

        /// <summary>Insert Hospital</summary>
        /// <param name="viewModel">Hospital View Model</param>
        public void InsertHospital(HospitalViewModel viewModel)
        {
            _unitOfWork.GenericRepository<Hospital>().Add(new HospitalViewModel().ConvertViewModel(viewModel));
            _unitOfWork.Save();
        }

        /// <summary>Update Hospital</summary>
        /// <param name="viewModel">Hospital View Model</param>
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

        /// <summary>Delete Hospital</summary>
        /// <param name="id">Hospital Identifier</param>
        public void DeleteHospital(int id)
        {
            _unitOfWork.GenericRepository<Hospital>().Delete(_unitOfWork.GenericRepository<Hospital>().GetById(id));
            _unitOfWork.Save();
        }

        /// <summary>Convert Model to View Model Collection</summary>
        /// <param name="hospitalCollection">Hospital Model Collection</param>
        /// <returns>List<HospitalViewModel></returns>
        private List<HospitalViewModel> GetHospitalViewModelCollection(List<Hospital> hospitalCollection) 
        {
            return hospitalCollection.Select(x => new HospitalViewModel(x)).ToList();
        }
    }
}

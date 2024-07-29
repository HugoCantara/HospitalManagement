/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories.Repositories.Models
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interfaces;
    using HospitalManagement.Repositories.Interfaces.Models;
    using HospitalManagement.ViewModels;

    /// <summary>User Repository</summary>
    public class UserRepository : IUserRepository
    {
        private IUnitOfWork _unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize)
        {
            var viewModelCollection = new List<ApplicationUserViewModel>();
            int totalRecords;

            try
            {
                int records = (pageSize * pageNumber) - pageSize;
                var modelCollection = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().Skip(records).Take(pageSize).ToList();
                totalRecords = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().ToList().Count;
                viewModelCollection = this.ConvertToViewModelCollection(modelCollection);
            }
            catch (Exception)
            {
                throw;
            }

            return new PagedResult<ApplicationUserViewModel>
            {
                Data = viewModelCollection,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public PagedResult<ApplicationUserViewModel> GetAllDoctors(int pageNumber, int pageSize)
        {
            var viewModelCollection = new List<ApplicationUserViewModel>();
            int totalRecords;

            try
            {
                int records = (pageSize * pageNumber) - pageSize;
                var modelCollection = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == true).Skip(records).Take(pageSize).ToList();
                totalRecords = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == true).ToList().Count;
                viewModelCollection = this.ConvertToViewModelCollection(modelCollection);
            }
            catch (Exception)
            {
                throw;
            }

            return new PagedResult<ApplicationUserViewModel>
            {
                Data = viewModelCollection,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public PagedResult<ApplicationUserViewModel> GetAllPatients(int pageNumber, int pageSize)
        {
            var viewModelCollection = new List<ApplicationUserViewModel>();
            int totalRecords;

            try
            {
                int records = (pageSize * pageNumber) - pageSize;
                var modelCollection = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == false).Skip(records).Take(pageSize).ToList();
                totalRecords = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == false).ToList().Count;
                viewModelCollection = this.ConvertToViewModelCollection(modelCollection);
            }
            catch (Exception)
            {
                throw;
            }

            return new PagedResult<ApplicationUserViewModel>
            {
                Data = viewModelCollection,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public PagedResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize, string speciality)
        {
            throw new NotImplementedException();
        }

        private List<ApplicationUserViewModel> ConvertToViewModelCollection(List<ApplicationUser> collection)
        {
            return collection.Select(x => new ApplicationUserViewModel(x)).ToList();
        }
    }
}

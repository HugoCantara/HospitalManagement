/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interfaces;
    using HospitalManagement.Services;
    using HospitalManagement.ViewModels;

    /// <summary>Application User Service Class</summary>
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize)
        {
            var contactViewModelCollection = new List<ApplicationUserViewModel>();
            int totalRecords;

            try
            {
                int records = (PageSize * PageNumber) - PageSize;
                var modelCollection = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().Skip(records).Take(PageSize).ToList();
                totalRecords = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().ToList().Count;
                contactViewModelCollection = GetApplicationUserViewModelCollection(modelCollection);
            }
            catch (Exception)
            {
                throw;
            }

            return new PagedResult<ApplicationUserViewModel>
            {
                Data = contactViewModelCollection,
                TotalItems = totalRecords,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
        }

        public PagedResult<ApplicationUserViewModel> GetAllDoctors(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ApplicationUserViewModel> GetAllPatients(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Speciality)
        {
            throw new NotImplementedException();
        }

        private List<ApplicationUserViewModel> GetApplicationUserViewModelCollection(List<ApplicationUser> applicationUserCollection)
        {
            return applicationUserCollection.Select(x => new ApplicationUserViewModel(x)).ToList();
        }
    }
}

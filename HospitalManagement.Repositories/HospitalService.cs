/// <summary>Hospital Service Class</summary>
namespace HospitalManagement.Repositories
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interfaces;
    using HospitalManagement.Services;
    using HospitalManagement.ViewModels;

    public class HospitalService : IHospital
    {
        private IUnitOfWork _unitOfWork;

        public HospitalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<HospitalViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new HospitalViewModel();
            int totalCount;
            List<HospitalViewModel> vmList = new List<HospitalViewModel>();
            try 
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Hospital>().GetAll().Skip(excludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Hospital>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception) 
            {
                throw;
            }
            var result = new PagedResult<HospitalViewModel> 
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public HospitalViewModel GetHospitalById(int id)
        {
            var model = _unitOfWork.GenericRepository<Hospital>().GetById(id);
            var vm = new HospitalViewModel(model);
            return vm;
        }

        public void InsertHospital(HospitalViewModel hospital)
        {
            var model = new HospitalViewModel().ConvertViewModel(hospital);
            _unitOfWork.GenericRepository<Hospital>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateHospital(HospitalViewModel hospital)
        {
            var model = new HospitalViewModel().ConvertViewModel(hospital);
            var modelById = _unitOfWork.GenericRepository<Hospital>().GetById(model.Id);
            modelById.Name = hospital.Name;
            modelById.City = hospital.City;
            modelById.PinCode = hospital.PinCode;
            modelById.Country = hospital.Country;
            _unitOfWork.GenericRepository<Hospital>().Update(modelById);
            _unitOfWork.Save();
        }

        public void DeleteHospital(int id)
        {
            var model = _unitOfWork.GenericRepository<Hospital>().GetById(id);
            _unitOfWork.GenericRepository<Hospital>().Delete(model);
            _unitOfWork.Save();
        }

        private List<HospitalViewModel> ConvertModelToViewModelList(List<Hospital> modelList) 
        {
            return modelList.Select(x => new HospitalViewModel(x)).ToList();
        }
    }
}

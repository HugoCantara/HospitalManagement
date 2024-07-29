/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories.Repositories.Models
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interfaces;
    using HospitalManagement.Repositories.Interfaces.Models;
    using HospitalManagement.ViewModels;
    using System.Collections.Generic;

    /// <summary>Doctor Repository</summary>
    public class DoctorRepository : IDoctorRepository
    {
        private IUnitOfWork _unitOfWork;

        public DoctorRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TimingViewModel> GetAll()
        {
            var collection = _unitOfWork.GenericRepository<Timing>().GetAll().ToList();
            return this.ConvertToViewModelCollection(collection);
        }

        public PagedResult<TimingViewModel> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var viewModelCollection = new List<TimingViewModel>();
            int totalRecords;

            try
            {
                int records = (pageSize * pageNumber) - pageSize;
                var modelCollection = _unitOfWork.GenericRepository<Timing>().GetAll().Skip(records).Take(pageSize).ToList();
                totalRecords = _unitOfWork.GenericRepository<Timing>().GetAll().ToList().Count;
                viewModelCollection = this.ConvertToViewModelCollection(modelCollection);
            }
            catch (Exception)
            {
                throw;
            }

            return new PagedResult<TimingViewModel>
            {
                Data = viewModelCollection,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public TimingViewModel GetTimingById(int id)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(id);
            return new TimingViewModel(model);
        }

        public void InsertTiming(TimingViewModel viewModel)
        {
            var model = new TimingViewModel().ConvertViewModel(viewModel);
            _unitOfWork.GenericRepository<Timing>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateTiming(TimingViewModel viewModel)
        {
            var model = new TimingViewModel().ConvertViewModel(viewModel);
            var modelById = _unitOfWork.GenericRepository<Timing>().GetById(model.Id);
            modelById.Id = viewModel.Id;
            modelById.Doctor = viewModel.Doctor;
            modelById.MorningShiftStartTime = viewModel.MorningShiftStartTime;
            modelById.MorningShiftEndTime = viewModel.MorningShiftEndTime;
            modelById.AfternoonShiftStartTime = viewModel.AfternoonShiftStartTime;
            modelById.AfternoonShiftEndTime = viewModel.AfternoonShiftEndTime;
            modelById.Duration = viewModel.Duration;
            modelById.Status = viewModel.Status;
            _unitOfWork.GenericRepository<Timing>().Update(modelById);
            _unitOfWork.Save();
        }

        public void DeleteTiming(int id)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(id);
            _unitOfWork.GenericRepository<Timing>().Delete(model);
            _unitOfWork.Save();
        }

        private List<TimingViewModel> ConvertToViewModelCollection(List<Timing> collection)
        {
            return collection.Select(x => new TimingViewModel(x)).ToList();
        }
    }
}
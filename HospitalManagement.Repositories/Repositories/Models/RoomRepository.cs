/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories.Repositories.Models
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interfaces;
    using HospitalManagement.Repositories.Interfaces.Models;
    using HospitalManagement.ViewModels;
    using System.Collections.Generic;

    /// <summary>Hospital Repository</summary>
    public class RoomRepository : IRoomRepository
    {
        private IUnitOfWork _unitOfWork;

        public RoomRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<RoomViewModel> GetAll()
        {
            var collection = _unitOfWork.GenericRepository<Room>().GetAll(includeProperties: "Hospital").ToList();
            return this.ConvertToViewModelCollection(collection);
        }

        public PagedResult<RoomViewModel> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var viewModelCollection = new List<RoomViewModel>();
            int totalRecords;

            try
            {
                int records = (pageSize * pageNumber) - pageSize;
                var modelCollection = _unitOfWork.GenericRepository<Room>().GetAll(includeProperties: "Hospital").Skip(records).Take(pageSize).ToList();
                totalRecords = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count;
                viewModelCollection = this.ConvertToViewModelCollection(modelCollection);
            }
            catch (Exception)
            {
                throw;
            }

            return new PagedResult<RoomViewModel>
            {
                Data = viewModelCollection,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public RoomViewModel GetRoomById(int id)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(id);
            return new RoomViewModel(model);
        }

        public void InsertRoom(RoomViewModel viewModel)
        {
            var model = new RoomViewModel().ConvertViewModel(viewModel);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateRoom(RoomViewModel viewModel)
        {
            var model = new RoomViewModel().ConvertViewModel(viewModel);
            var modelById = _unitOfWork.GenericRepository<Room>().GetById(model.Id);
            modelById.HospitalId = viewModel.HospitalId;
            modelById.RoomNumber = viewModel.RoomNumber;
            modelById.Type = viewModel.Type;
            modelById.Status = viewModel.Status;
            _unitOfWork.GenericRepository<Room>().Update(modelById);
            _unitOfWork.Save();
        }

        public void DeleteRoom(int id)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(id);
            _unitOfWork.GenericRepository<Room>().Delete(model);
            _unitOfWork.Save();
        }

        private List<RoomViewModel> ConvertToViewModelCollection(List<Room> collection)
        {
            return collection.Select(x => new RoomViewModel(x)).ToList();
        }
    }
}
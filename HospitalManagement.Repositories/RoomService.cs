/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interfaces;
    using HospitalManagement.Services;
    using HospitalManagement.ViewModels;

    /// <summary>Room Service Class</summary>
    public class RoomService : IRoomService
    {
        /// <summary>Unit of Work</summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>Constructor</summary>
        /// <param name="unitOfWork">Unit Of Work</param>
        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>Get All Rooms</summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>PagedResult<RoomViewModel></returns>
        public PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize)
        {
            var roomViewModelCollection = new List<RoomViewModel>();
            int totalRecords;
            
            try
            {
                int records = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Room>().GetAll().Skip(records).Take(pageSize).ToList();
                totalRecords = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count;
                roomViewModelCollection = GetRoomViewModelCollection(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            
            return new PagedResult<RoomViewModel>
            {
                Data = roomViewModelCollection,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        /// <summary>Get Room by Identifier</summary>
        /// <param name="id">Room Identifier</param>
        /// <returns>RoomViewModel</returns>
        public RoomViewModel GetRoomById(int id)
        {
            return new RoomViewModel(_unitOfWork.GenericRepository<Room>().GetById(id));
        }

        /// <summary>Insert Room</summary>
        /// <param name="viewModel">Room View Model</param>
        public void InsertRoom(RoomViewModel viewModel)
        {
            _unitOfWork.GenericRepository<Room>().Add(new RoomViewModel().ConvertViewModel(viewModel));
            _unitOfWork.Save();
        }

        /// <summary>Update Room</summary>
        /// <param name="viewModel">Room View Model</param>
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

        /// <summary>Delete Room</summary>
        /// <param name="id">Room Identifier</param>
        public void DeleteRoom(int id)
        {
            _unitOfWork.GenericRepository<Room>().Delete(_unitOfWork.GenericRepository<Room>().GetById(id));
            _unitOfWork.Save();
        }

        /// <summary>Convert Model to View Model List</summary>
        /// <param name="roomCollection">Room Model Collection</param>
        /// <returns>List<RoomViewModel></returns>
        private List<RoomViewModel> GetRoomViewModelCollection(List<Room> roomCollection)
        {
            return roomCollection.Select(x => new RoomViewModel(x)).ToList();
        }
    }
}
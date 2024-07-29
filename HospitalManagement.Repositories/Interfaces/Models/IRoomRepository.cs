/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Repositories.Interfaces.Models
{
    using HospitalManagement.Models;
    using HospitalManagement.ViewModels;

    /// <summary>Room Repository Interface</summary>
    public interface IRoomRepository
    {
        IEnumerable<RoomViewModel> GetAll();
        PagedResult<RoomViewModel> GetAllWithPagination(int pageNumber, int pageSize);
        RoomViewModel GetRoomById(int id);
        void InsertRoom(RoomViewModel viewModel);
        void UpdateRoom(RoomViewModel viewModel);
        void DeleteRoom(int id);
    }
}

/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Services
{
    using HospitalManagement.Models;
    using HospitalManagement.ViewModels;

    /// <summary>Room Service Interface</summary>
    public interface IRoomService
    {
        PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize);
        RoomViewModel GetRoomById(int id);
        void UpdateRoom(RoomViewModel viewModel);
        void InsertRoom(RoomViewModel viewModel);
        void DeleteRoom(int id);
    }
}

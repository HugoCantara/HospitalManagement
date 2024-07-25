/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.ViewModels
{
    using HospitalManagement.Models;

    /// <summary>Room View Model Class</summary>
    public class RoomViewModel
    {
        /// <summary>Room Identifier</summary>
        public int Id { get; set; }

        /// <summary>Hospital Identifier</summary>
        public int HospitalId { get; set; }

        /// <summary>Room Number</summary>
        public string RoomNumber { get; set; }

        /// <summary>Room Type</summary>
        public string Type { get; set; }

        /// <summary>Room Status</summary>
        public string Status { get; set; }

        /// <summary>Constructor</summary>
        public RoomViewModel() { }

        /// <summary>Constructor</summary>
        /// <param name="model">Room Model</param>
        public RoomViewModel(Room model)
        {
            Id = model.Id;
            HospitalId = model.HospitalId;
            RoomNumber = model.RoomNumber;
            Type = model.Type;
            Status = model.Status;
        }

        /// <summary>Convert View Model to Model</summary>
        /// <param name="viewModel">Room View Model</param>
        /// <returns>Room</returns>
        public Room ConvertViewModel(RoomViewModel viewModel)
        {
            return new Room
            {
                Id = viewModel.Id,
                HospitalId = viewModel.HospitalId,
                RoomNumber = viewModel.RoomNumber,
                Type = viewModel.Type,
                Status = viewModel.Status
            };
        }
    }
}

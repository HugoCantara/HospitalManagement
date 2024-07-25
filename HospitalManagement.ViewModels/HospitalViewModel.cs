/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.ViewModels
{
    using HospitalManagement.Models;

    /// <summary>Hospital View Model Class</summary>
    public class HospitalViewModel
    {
        /// <summary>Hospital Identifier</summary>
        public int Id { get; set; }
        
        /// <summary>Hospital Name</summary>
        public string Name { get; set; }
        
        /// <summary>Hospital Type</summary>
        public string Type { get; set; }
        
        /// <summary>Hospital City</summary>
        public string City { get; set; }

        /// <summary>Hospital Pin Code</summary>
        public string PinCode { get; set; }

        /// <summary>Hospital Country</summary>
        public string Country { get; set; }

        /// <summary>Constructor</summary>
        public HospitalViewModel() { }

        /// <summary>Constructor</summary>
        /// <param name="model">Hospital Model</param>
        public HospitalViewModel(Hospital model)
        {
            Id = model.Id;
            Name = model.Name;
            Type = model.Type;
            City = model.City;
            PinCode = model.PinCode;
            Country = model.Country;
        }

        /// <summary>Convert View Model to Model</summary>
        /// <param name="viewModel">Hospital View Model</param>
        /// <returns>Hospital</returns>
        public Hospital ConvertViewModel(HospitalViewModel viewModel)
        {
            return new Hospital{
                Id = viewModel.Id,
                Name = viewModel.Name,
                Type = viewModel.Type,
                City = viewModel.City,
                PinCode = viewModel.PinCode,
                Country = viewModel.Country
            };
        }
    }
}

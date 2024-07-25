/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.ViewModels
{
    using HospitalManagement.Models;

    /// <summary>Contact View Model Class</summary>
    public class ContactViewModel
    {
        /// <summary>Contact Identifier</summary>
        public int Id { get; set; }

        /// <summary>Hospital Identifier</summary>
        public int HospitalId { get; set; }

        /// <summary>Contact Email</summary>
        public string Email { get; set; }

        /// <summary>Contact Phone</summary>
        public string Phone { get; set; }

        /// <summary>Constructor</summary>
        public ContactViewModel() { }

        /// <summary>Constructor</summary>
        /// <param name="model">Contact Model</param>
        public ContactViewModel(Contact model)
        {
            Id = model.Id;
            HospitalId = model.HospitalId;
            Email = model.Email;
            Phone = model.Phone;
        }

        /// <summary>Convert View Model to Model</summary>
        /// <param name="viewModel">Contact View Model</param>
        /// <returns>Contact</returns>
        public Contact ConvertViewModel(ContactViewModel viewModel)
        {
            return new Contact
            {
                Id = viewModel.Id,
                HospitalId = viewModel.HospitalId,
                Email = viewModel.Email,
                Phone = viewModel.Phone
            };
        }
    }
}

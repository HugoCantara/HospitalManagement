/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.ViewModels
{
    using HospitalManagement.Models;
    using HospitalManagement.Models.Enumerations;

    /// <summary>Application User View Model Class</summary>
    public class ApplicationUserViewModel
    {
        public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Specialist { get; set; }
        public bool IsDoctor { get; set; }
        public string PictureUrl { get; set; }

        public ApplicationUserViewModel() { }

        public ApplicationUserViewModel(ApplicationUser model)
        {
            UserName = model.UserName;
            Email = model.Email;
            Name = model.Name;
            Gender = model.Gender;
            Nationality = model.Nationality;
            Address = model.Address;
            DOB = model.DOB;
            Specialist = model.Specialist;
            IsDoctor = model.IsDoctor;
            PictureUrl = model.PictureUri;
        }

        public ApplicationUser ConvertViewModel(ApplicationUserViewModel viewModel)
        {
            return new ApplicationUser
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                Name = viewModel.Name,
                Gender = viewModel.Gender,
                Nationality = viewModel.Nationality,
                Address = viewModel.Address,
                DOB = viewModel.DOB,
                Specialist = viewModel.Specialist,
                IsDoctor = viewModel.IsDoctor,
                PictureUri = viewModel.PictureUrl
            };
        }
    }
}

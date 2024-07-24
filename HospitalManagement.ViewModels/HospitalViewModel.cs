using HospitalManagement.Models;
/// <summary>Hospital View Model Class</summary>
namespace HospitalManagement.ViewModels
{
    public class HospitalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }

        public HospitalViewModel() { }

        public HospitalViewModel(Hospital model)
        {
            Id = model.Id;
            Name = model.Name;
            Type = model.Type;
            City = model.City;
            PinCode = model.PinCode;
            Country = model.Country;
        }

        public Hospital ConvertViewModel(HospitalViewModel model)
        {
            return new Hospital{
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                PinCode = model.PinCode,
                Country = model.Country
            };
        }
    }
}

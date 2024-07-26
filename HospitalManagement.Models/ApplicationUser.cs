/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Models
{
    using HospitalManagement.Models.Enumerations;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Application User Model Class</summary>
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        
        public Gender Gender { get; set; }
        
        public string Nationality { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public string Specialist { get; set; }

        public bool IsDoctor { get; set; }

        public string PictureUri { get; set; }

        public Department? Department { get; set; }

        [NotMapped]
        public ICollection<Appointment> Appointments { get; set; }

        [NotMapped]
        public ICollection<Payroll> Payrolls { get; set; }

        [NotMapped]
        public ICollection<PatientReport> PatientReports { get; set; }
    }
}
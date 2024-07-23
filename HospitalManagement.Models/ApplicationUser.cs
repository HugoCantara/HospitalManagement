﻿/// <summary>Application User Class</summary>
namespace HospitalManagement.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Specialist { get; set; }
        public Department Department { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
    }
}

/// <summary>Gender Enum</summary>
namespace HospitalManagement.Models
{
    public enum Gender
    {
        Male, Female, Other
    }
}
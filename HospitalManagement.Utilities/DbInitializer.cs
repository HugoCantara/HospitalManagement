/// <summary>Class Database Initializer</summary>
namespace HospitalManagement.Utilities
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try 
            {
                if (_context.Database.GetPendingMigrations().Count() > 0) 
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (!_roleManager.RoleExistsAsync(WebSiteRoles.AdminRole).GetAwaiter().GetResult()) 
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.AdminRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.PatientRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.DoctorRole)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Name",
                    Email = "email",
                }, "password").GetAwaiter().GetResult();

                var appUser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "email");

                if(appUser != null)
                {
                    _userManager.AddToRoleAsync(appUser, WebSiteRoles.AdminRole).GetAwaiter().GetResult();
                }
            }
        }
    }
}

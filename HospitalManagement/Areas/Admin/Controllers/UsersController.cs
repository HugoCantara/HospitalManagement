/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Web.Areas.Admin.Controllers
{
    using HospitalManagement.Repositories.Interfaces.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>Users Controller</summary>
    [Area("admin")]
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_userRepository.GetAll(pageNumber, pageSize));
        }

        public IActionResult IndexAllDoctors(int pageNumber = 1, int pageSize = 10)
        {
            return View(_userRepository.GetAllDoctors(pageNumber, pageSize));
        }
    }
}

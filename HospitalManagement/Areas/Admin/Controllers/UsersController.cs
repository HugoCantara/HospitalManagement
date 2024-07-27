/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Web.Areas.Admin.Controllers
{
    using HospitalManagement.Services;
    using Microsoft.AspNetCore.Mvc;

    [Area("admin")]
    public class UsersController : Controller
    {
        private IApplicationUserService _applicationUserService;

        public UsersController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_applicationUserService.GetAll(pageNumber, pageSize));
        }
    }
}

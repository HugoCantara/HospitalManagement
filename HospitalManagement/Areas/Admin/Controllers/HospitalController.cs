/// <summary>Hospital Controller</summary>
namespace HospitalManagement.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HospitalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

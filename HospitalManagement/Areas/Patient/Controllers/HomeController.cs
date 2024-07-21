/// <summary>Patient Home Controller</summary>
namespace HospitalManagement.Web.Areas.Patient.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Area("Patient")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

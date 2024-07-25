/// <summary>Hospital Controller</summary>
namespace HospitalManagement.Web.Areas.Admin.Controllers
{
    using HospitalManagement.Services;
    using HospitalManagement.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    [Area("admin")]
    public class HospitalController : Controller
    {
        private IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_hospitalService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var viewModel = _hospitalService.GetHospitalById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(HospitalViewModel vm) 
        {
            _hospitalService.UpdateHospital(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HospitalViewModel vm) 
        {
            _hospitalService.InsertHospital(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            _hospitalService.DeleteHospital(id);
            return RedirectToAction("Index");
        }

    }
}

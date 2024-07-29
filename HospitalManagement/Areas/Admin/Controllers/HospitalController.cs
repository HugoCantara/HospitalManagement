/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Web.Areas.Admin.Controllers
{
    using HospitalManagement.Repositories.Interfaces.Models;
    using HospitalManagement.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>Hospital Controller</summary>
    [Area("admin")]
    public class HospitalController : Controller
    {
        private IHospitalRepository _hospitalRepository;

        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_hospitalRepository.GetAllWithPagination(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HospitalViewModel viewModel)
        {
            _hospitalRepository.InsertHospital(viewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var viewModel = _hospitalRepository.GetHospitalById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(HospitalViewModel viewModel) 
        {
            _hospitalRepository.UpdateHospital(viewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            _hospitalRepository.DeleteHospital(id);
            return RedirectToAction("Index");
        }

    }
}

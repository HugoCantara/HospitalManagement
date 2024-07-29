/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Web.Areas.Doctor.Controllers
{
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interfaces.Models;
    using HospitalManagement.Utilities.Constants;
    using HospitalManagement.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Security.Claims;

    /// <summary>Doctor Timing Controller</summary>
    [Area("DoctorTiming")]
    public class DoctorController : Controller
    {
        private IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_doctorRepository.GetAllWithPagination(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var timing = new Timing();
            var morningShiftStart = new List<SelectListItem>();
            var morningShiftEnd = new List<SelectListItem>();
            var afternoonShiftStart = new List<SelectListItem>();
            var afternoonShiftEnd = new List<SelectListItem>();

            for(int i = 1; i <= 11; i++) 
            {
                morningShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            for (int i = 1; i <= 13; i++)
            {
                morningShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            for (int i = 13; i <= 16; i++)
            {
                afternoonShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            for (int i = 13; i <= 18; i++)
            {
                afternoonShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            ViewBag.morningStart = new SelectList(morningShiftStart, "Value", "Text");
            ViewBag.morningEnd = new SelectList(morningShiftEnd, "Value", "Text");
            ViewBag.evenStart = new SelectList(afternoonShiftStart, "Value", "Text");
            ViewBag.evenEnd = new SelectList(afternoonShiftEnd, "Value", "Text");

            var viewModel = new TimingViewModel();
            viewModel.ScheduleDate = DateTime.Now;
            viewModel.ScheduleDate = viewModel.ScheduleDate.AddDays(1);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(TimingViewModel viewModel)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            
            if(claims != null) 
            {
                viewModel.Doctor.Id = claims.Value;
                _doctorRepository.InsertTiming(viewModel);
            }
            
            return RedirectToAction(ActionNameConstants.INDEX_ACTION);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //ViewBag.timing = new SelectList(_doctorRepository.GetAll(), "Id", "Name");
            return View(_doctorRepository.GetTimingById(id));
        }

        [HttpPost]
        public IActionResult Edit(TimingViewModel viewModel)
        {
            _doctorRepository.UpdateTiming(viewModel);
            return RedirectToAction(ActionNameConstants.INDEX_ACTION);
        }

        public IActionResult Delete(int id)
        {
            _doctorRepository.DeleteTiming(id);
            return RedirectToAction(ActionNameConstants.INDEX_ACTION);
        }
    }
}

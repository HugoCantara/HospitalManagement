/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Web.Areas.Admin.Controllers
{
    using HospitalManagement.Repositories.Interfaces.Models;
    using HospitalManagement.Utilities.Constants;
    using HospitalManagement.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>Contact Controller</summary>
    [Area("admin")]
    public class ContactController : Controller
    {
        private IContactRepository _contactRepository;
        private IHospitalRepository _hospitalRepository;

        public ContactController(IContactRepository contactRepository, IHospitalRepository hospitalRepository)
        {
            _contactRepository = contactRepository;
            _hospitalRepository = hospitalRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_contactRepository.GetAllWithPagination(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.hospital = new SelectList(_hospitalRepository.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactViewModel viewModel)
        {
            _contactRepository.InsertContact(viewModel);
            return RedirectToAction(ActionNameConstants.INDEX_ACTION);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //ViewBag.hospital = new SelectList(_hospitalRepository.GetAll(), "Id", "Name");
            return View(_contactRepository.GetContactById(id));
        }

        [HttpPost]
        public IActionResult Edit(ContactViewModel viewModel)
        {
            _contactRepository.UpdateContact(viewModel);
            return RedirectToAction(ActionNameConstants.INDEX_ACTION);
        }

        public IActionResult Delete(int id)
        {
            _contactRepository.DeleteContact(id);
            return RedirectToAction(ActionNameConstants.INDEX_ACTION);
        }
    }
}

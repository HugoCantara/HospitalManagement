/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Web.Areas.Admin.Controllers
{
    using HospitalManagement.Services;
    using HospitalManagement.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>Contact Controller</summary>
    [Area("admin")]
    public class ContactController : Controller
    {
        /// <summary>Contact Service Interface</summary>
        private IContactService _contactService;

        /// <summary>Index Action Name</summary>
        private const string INDEX_ACTION = "Index";

        /// <summary>Constructor</summary>
        /// <param name="contactService">Contact Service Interface</param>
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>Index Action Result</summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>IActionResult</returns>
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_contactService.GetAll(pageNumber, pageSize));
        }

        /// <summary>GET - Create Action Result</summary>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>POST - Create Action Result</summary>
        /// <param name="viewModel">Contact View Model</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult Create(ContactViewModel viewModel)
        {
            _contactService.InsertContact(viewModel);
            return RedirectToAction(INDEX_ACTION);
        }

        /// <summary>GET - Edit Action Result</summary>
        /// <param name="id">Contact Identifier</param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_contactService.GetContactById(id));
        }

        /// <summary>POST - Edit Action Result</summary>
        /// <param name="viewModel">Contact View Model</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult Edit(ContactViewModel viewModel)
        {
            _contactService.UpdateContact(viewModel);
            return RedirectToAction(INDEX_ACTION);
        }

        /// <summary>Delete Action Result</summary>
        /// <param name="id">Contact Identifier</param>
        /// <returns>IActionResult</returns>
        public IActionResult Delete(int id)
        {
            _contactService.DeleteContact(id);
            return RedirectToAction(INDEX_ACTION);
        }
    }
}

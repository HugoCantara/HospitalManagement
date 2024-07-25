﻿/// <summary>Hospital Management - Version 1.0</summary>
namespace HospitalManagement.Web.Areas.Admin.Controllers
{
    using HospitalManagement.Services;
    using HospitalManagement.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>Room Controller</summary>
    [Area("admin")]
    public class RoomController : Controller
    {
        /// <summary>Room Service Interface</summary>
        private IRoomService _roomService;

        /// <summary>Index Action Name</summary>
        private const string INDEX_ACTION = "Index";

        /// <summary>Constructor</summary>
        /// <param name="roomService">Room Service Interface</param>
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        /// <summary>Index Action Result</summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>IActionResult</returns>
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_roomService.GetAll(pageNumber, pageSize));
        }

        /// <summary>GET - Create Action Result</summary>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>POST - Create Action Result</summary>
        /// <param name="viewModel">Room View Model</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult Create(RoomViewModel viewModel)
        {
            _roomService.InsertRoom(viewModel);
            return RedirectToAction(INDEX_ACTION);
        }

        /// <summary>GET - Edit Action Result</summary>
        /// <param name="id">Room Identifier</param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_roomService.GetRoomById(id));
        }

        /// <summary>POST - Edit Action Result</summary>
        /// <param name="viewModel">Room View Model</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult Edit(RoomViewModel viewModel)
        {
            _roomService.UpdateRoom(viewModel);
            return RedirectToAction(INDEX_ACTION);
        }

        /// <summary>Delete Action Result</summary>
        /// <param name="id">Room Identifier</param>
        /// <returns>IActionResult</returns>
        public IActionResult Delete(int id)
        {
            _roomService.DeleteRoom(id);
            return RedirectToAction(INDEX_ACTION);
        }
    }
}

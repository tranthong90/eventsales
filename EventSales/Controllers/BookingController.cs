using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventSales.Models;
using EventSales.Services;
using Microsoft.AspNetCore.Mvc;


namespace EventSales.Controllers
{
    public class BookingController : Controller
    {
        private IDataService _dataService;

        public BookingController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        [Route("/Booking/{id}")]
        public async Task<IActionResult> Index(int id, int amount)
        {
            var e = await _dataService.GetEventByID(id);

            return View(new BookingIndexModel
            {
                Event = e,
                Amount = amount
            });
        }
    }
}

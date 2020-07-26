using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventSales.Models;
using EventSales.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventSales.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        private IDataService _dataService;
        private IDataMapper _dataMapper;

        public HomeController(ILogger<HomeController> logger,IDataService dataService, IDataMapper dataMapper)
        {
            _logger = logger;
            _dataService = dataService;
            _dataMapper = dataMapper;
        }


        public async Task<IActionResult> Index()
        {
            var eventList = await _dataService.GetAllEvents();
            var model = new HomeIndexModel
            {
                EventList = eventList.Select(x => _dataMapper.Map(x))
            };
            return View(model);
        }
    }
}

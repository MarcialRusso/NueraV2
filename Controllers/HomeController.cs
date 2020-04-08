using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Main.Domain.HouseholdItems.Commands;
using Main.Models;
using Main.Models.HouseholdItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;  
        
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        // TODO - Move to it's own controller
        [HttpPost]
        public async Task<ActionResult> AddHouseholdItem(HouseholdItem item)  
        {
            try
            {
                var command = new AddHouseholdItemForClientCommand(item.Name, item.Value, item.Category);
                await _mediator.Send(command);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e, "Unable to modify client items");
                return RedirectToAction("Index");
            }
            
            return View();  
        }  

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

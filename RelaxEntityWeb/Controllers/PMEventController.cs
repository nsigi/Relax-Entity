using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using System.Diagnostics;

namespace RelaxEntityWeb.Controllers
{
    public class PMEventController : Controller
    {
        private readonly ILogger<PMEventController> _logger;

        public PMEventController(ILogger<PMEventController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
			var model = new OrderHelper();
			model.CurrentEventId = int.Parse(RouteData.Values["id"] as string);
			return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
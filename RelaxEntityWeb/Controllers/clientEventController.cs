using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Routing;

namespace RelaxEntityWeb.Controllers
{
    public class clientEventController : Controller
    {
        private readonly ILogger<clientEventController> _logger;

        public clientEventController(ILogger<clientEventController> logger)
        {
            _logger = logger;
        }

        public object Index()
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
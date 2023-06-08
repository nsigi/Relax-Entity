using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using System.Diagnostics;

namespace RelaxEntityWeb.Controllers
{
    public class PMEventsInvalidController : Controller
    {
        private readonly ILogger<PMEventsInvalidController> _logger;

        public PMEventsInvalidController(ILogger<PMEventsInvalidController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (RouteData.Values.ContainsKey("id"))
            {
                var eventId = int.Parse(RouteData.Values["id"] as string);
                using (var context = new RelaxEntityContext())
                {
                    var curEvent = context.Events.Where(x => x.Id == eventId).FirstOrDefault();
                    context.SaveChanges();
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
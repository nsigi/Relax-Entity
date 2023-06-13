using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using System.Diagnostics;

namespace RelaxEntityWeb.Controllers
{
    public class PMLocationsController : Controller
    {
        private readonly ILogger<PMLocationsController> _logger;

        public PMLocationsController(ILogger<PMLocationsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddLocation(LocationDataHelper model)
        {
            using (var context = new RelaxEntityContext())
            {
				var client = context.Clients.Where(x => x.Email == UserSession.CurrentUserEmail).FirstOrDefault();
				var pm = context.ProjectManagers.Where(x => x.Client == client.Email).FirstOrDefault();
				var organization = context.Organizations.Where(x => x.Name == pm.Organization).FirstOrDefault();
				var newLocation = new Location(model.Name, model.Capaciousness, model.Equipment, organization.Name);
                context.Locations.Add(newLocation);
                context.SaveChanges();
                return View("Index");
            }
        }

        [HttpPost]
        public IActionResult EditLocation(LocationDataHelper model)
        {
            using (var context = new RelaxEntityContext())
            {
                var client = context.Clients.Where(x => x.Email == UserSession.CurrentUserEmail).FirstOrDefault();
                var pm = context.ProjectManagers.Where(x => x.Client == client.Email).FirstOrDefault();
                var organization = context.Organizations.Where(x => x.Name == pm.Organization).FirstOrDefault();
                var curLocation = context.Locations.Where(x => x.Id == model.CurrentLocationId).FirstOrDefault();
                curLocation.Name = model.Name;
                curLocation.Capaciousness = model.Capaciousness;
                curLocation.Equipment = model.Equipment;
                curLocation.Organization = organization.Name;
                context.SaveChanges();
                return View("Index");
            }
        }

        [HttpPost]
        public IActionResult DeleteLocation(LocationDataHelper model)
        {
            using (var context = new RelaxEntityContext())
            {
                if (context.Events.Where(x => x.LocationId == model.CurrentLocationId).FirstOrDefault() == null)
                {
                    context.Locations.Remove(context.Locations.Where(x => x.Id == model.CurrentLocationId).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            return View("Index");
        }

        public IActionResult Index()
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
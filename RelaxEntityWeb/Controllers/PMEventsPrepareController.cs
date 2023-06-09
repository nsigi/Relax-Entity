using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using System.Diagnostics;

namespace RelaxEntityWeb.Controllers
{
    public class PMEventsPrepareController : Controller
    {
        private readonly ILogger<PMEventsPrepareController> _logger;

        public PMEventsPrepareController(ILogger<PMEventsPrepareController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddEvent(EventDataHelper model)
        {
            using (var context = new RelaxEntityContext())
            {
				var client = context.Clients.Where(x => x.Email == UserSession.CurrentUserEmail).FirstOrDefault();
				var pm = context.ProjectManagers.Where(x => x.Client == client.Email).FirstOrDefault();
				var programm = context.Programms.Where(x => x.Name == model.Programm).FirstOrDefault();
                var location = context.Locations.Where(x => x.Name == model.Location).FirstOrDefault();
				var newEvent = new Event(model.Name,model.Date,model.Date.TimeOfDay, model.CountMax, 0, model.Note, model.Price, pm.Id, 
                    (int)EventStatus.Prepared,location.Id, programm.Id);
                context.Events.Add(newEvent);
                context.SaveChanges();
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult ActivateEvent()
        {
            var eventId = int.Parse(RouteData.Values["id"] as string);
            using (var context = new RelaxEntityContext())
            {
                var curEvent = context.Events.Where(x => x.Id == eventId).FirstOrDefault();
                curEvent.Status = (int)EventStatus.Actived;
                context.SaveChanges();
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult EditEvent(EventDataHelper model)
        {
            using (var context = new RelaxEntityContext())
            {
                var curEvent = context.Events.Where(x => x.Id == model.CurrentEventId).FirstOrDefault();
                var location = context.Locations.Where(x => x.Name == model.Location).FirstOrDefault();
                curEvent.Name = model.Name;
                //curEvent.Date = model.Date;
                //curEvent.StartTime = model.Date.TimeOfDay;
                if (curEvent.CountCurrent < model.CountMax)
                    curEvent.CountMax = model.CountMax;
                curEvent.Note = model.Note;
                curEvent.Price = model.Price;
                curEvent.LocationId = location.Id;
                context.SaveChanges();
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult DeleteEvent(EventDataHelper model)
        {
            using (var context = new RelaxEntityContext()) {
                context.Events.Remove(context.Events.Where(x => x.Id == model.CurrentEventId).FirstOrDefault());
                context.SaveChanges();
            }
            return View("Index");
        }

        public IActionResult Index()
        {
            if (RouteData.Values.ContainsKey("id"))
            {
                var eventId = int.Parse(RouteData.Values["id"] as string);
                using (var context = new RelaxEntityContext())
                {
                    var curEvent = context.Events.Where(x => x.Id == eventId).FirstOrDefault();
                    curEvent.Status = (int)EventStatus.Actived;
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
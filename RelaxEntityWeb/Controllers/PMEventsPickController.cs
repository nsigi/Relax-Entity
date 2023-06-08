using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using System.Diagnostics;

namespace RelaxEntityWeb.Controllers
{
    public class PMEventsPickController : Controller
    {
        private readonly ILogger<PMEventsPickController> _logger;

        public PMEventsPickController(ILogger<PMEventsPickController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult ChangeEventStatus(OrderHelper model)
        {
            using (var context = new RelaxEntityContext())
            {
                var curEvent = context.Events.Where(x => x.Id == model.CurrentEventId).FirstOrDefault();
                if (curEvent.Status == (int)EventStatus.Actived)
                {
                    curEvent.Status=(int)EventStatus.Deleted;
                }
                else
                {
                    curEvent.Status=(int)EventStatus.Canceled;
                }
                context.SaveChanges();
            }
            return View("Index");
        }

        public IActionResult Index()
        {
            //if (RouteData.Values.ContainsKey("id"))
            //{
            //    var eventId = int.Parse(RouteData.Values["id"] as string);
            //    using (var context = new RelaxEntityContext())
            //    {
            //        var curEvent = context.Events.Where(x => x.Id == eventId).FirstOrDefault();
            //        if (eventId == (int)EventStatus.Actived)
            //        {
            //            curEvent.Status=(int)EventStatus.Deleted;
            //        }
            //        else
            //        {
            //            curEvent.Status=(int)EventStatus.Canceled;
            //        }
            //        context.SaveChanges();
            //    }
            //}
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
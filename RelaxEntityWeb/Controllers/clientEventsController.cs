using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using static RelaxEntityWeb.Models.OtherModels.StatusOrderHelper;
using System.Diagnostics;

namespace RelaxEntityWeb.Controllers
{
    public class clientEventsController : Controller
    {
        private readonly ILogger<clientEventsController> _logger;

        public clientEventsController(ILogger<clientEventsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddOrder(OrderHelper model)
        {
            if (model.CurrentEventId == -1)
            {
                model.CurrentEventId = int.Parse(RouteData.Values["id"] as string);
            }
			using (var context = new RelaxEntityContext())
            {
				var newOrder = new Order(model.QuantityOfPeople, UserSession.CurrentUserEmail, model.CurrentEventId, Payed, DateTime.Now);
                var curEvent = context.Events.Where(x => x.Id == newOrder.EventId).FirstOrDefault();
                if (model.QuantityOfPeople > curEvent.CountCurrent)
                {
                   return View("AddOrderError");
                }
                else 
                {
                    if (curEvent.CountMax == curEvent.CountCurrent)
                    {
                        curEvent.Status = (int)EventStatus.Pick;
                    }
                    curEvent.CountCurrent -= model.QuantityOfPeople;
					context.Orders.Add(newOrder);
					context.SaveChanges();
                    return RedirectToAction("Index", "clientOrders");
				}
			}
        }

        public IActionResult Index(OrderHelper model)
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
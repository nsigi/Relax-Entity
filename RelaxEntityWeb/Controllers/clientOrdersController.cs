using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace RelaxEntityWeb.Controllers
{
    public class clientOrdersController : Controller
    {
        private readonly ILogger<clientOrdersController> _logger;

        public clientOrdersController(ILogger<clientOrdersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult DeleteOrder(OrderHelper model)
        {
            var orderId = model.CurrentOrderId;
            using (var context = new RelaxEntityContext())
            {
                var curOrder = context.Orders.Where(x => x.Id == orderId).FirstOrDefault();
                var curEvent = context.Events.Where(x => x.Id == curOrder.EventId).FirstOrDefault();
                curEvent.CountCurrent += curOrder.Count;
                context.Orders.Remove(curOrder);
				if (curEvent.CountCurrent==curEvent.CountMax)
				{
                    curEvent.Status = (int)EventStatus.Actived;
				}
                context.SaveChanges();
            }
                return View("Index");
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
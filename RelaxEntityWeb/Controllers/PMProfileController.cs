using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using System.Diagnostics;
using System.Data;

namespace RelaxEntityWeb.Controllers
{
    public class PMProfileController : Controller
    {
        private readonly ILogger<PMProfileController> _logger;

        public PMProfileController(ILogger<PMProfileController> logger)
        {
            _logger = logger;
        }

		[HttpPost]
		public IActionResult UpdateClientData(UserDataHelper model)
		{
			using (var context = new RelaxEntityContext())
			{
				//model.Email = UserSession.CurrentUserEmail;
				var client = context.Clients.Where(x => x.Email == UserSession.CurrentUserEmail).FirstOrDefault();
				client.Phone = model.Phone;
				client.Name = model.Name;
				context.SaveChanges();
			}
			return RedirectToAction("Index", "PMProfile", model);
		}

		public IActionResult Index(UserDataHelper model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
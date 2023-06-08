using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace RelaxEntityWeb.Controllers
{
    public class clientProfileController : Controller
    {
        private readonly ILogger<clientProfileController> _logger;
        public clientProfileController(ILogger<clientProfileController> logger)
        {
            _logger = logger;
        }

		[HttpPost]
		public IActionResult UpdateClientData(UserDataHelper model)
		{
			using (var context = new RelaxEntityContext())
			{
				model.Email = UserSession.CurrentUserEmail;
				var client = context.Clients.Where(x => x.Email == UserSession.CurrentUserEmail).FirstOrDefault();
				client.Phone = model.Phone;
				client.Name = model.Name;
				context.SaveChanges();
			}
			return RedirectToAction("Index", "ClientProfile", model);
		}

		//[HttpPost]
		//public string RegisterClient(Client model)
		//{
		//	using (var context = new RelaxEntityContext())
		//	{
		//		context.Clients.Add(model);
		//		context.SaveChanges();
		//	}
		//	return "Успешно";
		//}

		//[HttpPost]
		//public string RegisterPM(ProjectManager model)
		//{
		//	using (var context = new RelaxEntityContext())
		//	{
		//		context.ProjectManagers.Add(model);
		//		context.SaveChanges();
		//	}
		//	return "Успешно";
		//}

		public IActionResult ConfiguringData(string userEmail)
		{
			//if (HttpContext.Session.GetString("userEmail") == null)
			//{
			//	HttpContext.Session.SetString("userEmail", userEmail);
			//}
			var model = new UserDataHelper() { Email = UserSession.CurrentUserEmail };
			return View("Index", model);
			//HttpContext.Session.SetString("UserEmail", userEmail);
		}

		public IActionResult Index(UserDataHelper model)
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
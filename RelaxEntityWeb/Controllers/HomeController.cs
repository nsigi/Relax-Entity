using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using System.Diagnostics;

namespace RelaxEntityWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public string userEmail;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult RegisterUser(UserDataHelper model)
        {
            if (ModelState.IsValid)
            {
                var account = new AccountService(_logger);
                var password = HashPasswordHelper.HashPassword(model.Password);
                Client client = new Client(model.Name, model.Phone, model.Email, password);
                account.RegisterClient(client);
                if (model.Organization != "Нет")
                {
                    var pm = new ProjectManager(model.Organization, client.Email);
                    account.RegisterPM(pm);
                }
            }
            return RedirectToAction("Index", "Home");
        }

		[HttpPost]
		public IActionResult Authorize(UserDataHelper model)
		{
			using (var context = new RelaxEntityContext())
			{
				var client = context.Clients.Where(x => x.Email == model.Email).FirstOrDefault();
				if (client == null)
				{
					return RedirectToAction("Index", "Home"); //Неверный логин или пароль
				}
				else
				{
					var realPass = client.Password;
                    var enteredPass = HashPasswordHelper.HashPassword(model.Password);
					if (enteredPass != realPass)
					{
						return RedirectToAction("Index", "Home"); //Неверный логин или пароль
					}
					var pm = context.ProjectManagers.Where(row => row.Client == client.Email).FirstOrDefault();
					if (pm == null)
					{
                        UserSession.CurrentUserEmail = client.Email;
                        userEmail = client.Email;
                        //HttpContext.Session.SetString("UserEmail", client.Email);
                        return RedirectToAction("Index", "ClientProfile");
					}
					else
					{
                        UserSession.CurrentUserEmail = client.Email;
						//HttpContext.Session.SetString("UserEmail", client.Email);
						return RedirectToAction("Index", "PMProfile");
					}
				}
			}
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
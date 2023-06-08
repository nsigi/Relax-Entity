using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;
using RelaxEntityWeb.Models.Entities;
using System.Diagnostics;

namespace RelaxEntityWeb.Controllers
{
    public class PMProgramsController : Controller
    {
        private readonly ILogger<PMProgramsController> _logger;

        public PMProgramsController(ILogger<PMProgramsController> logger)
        {
            _logger = logger;
        }

		[HttpPost]
		public IActionResult AddProgram(ProgramDataHelper model)
		{
			using (var context = new RelaxEntityContext())
			{
				var client = context.Clients.Where(x => x.Email == UserSession.CurrentUserEmail).FirstOrDefault();
				var pm = context.ProjectManagers.Where(x => x.Client == client.Email).FirstOrDefault();
				var newProgram = new Programm(model.Name, model.Description, model.Duration, model.Age, pm.Organization);
				context.Programms.Add(newProgram);
				context.SaveChanges();
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
using RelaxEntityWeb.Controllers;
using RelaxEntityWeb.Models.Entities;
using Microsoft.Extensions.Configuration.Json;

namespace RelaxEntityWeb.Models.OtherModels
{
    public class AccountService
	{
		private readonly ILogger<HomeController> _logger;

		public AccountService(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public void UpdateClient(Client client)
		{

			using (var context = new RelaxEntityContext())
			{
				context.Clients.Update(client);
				context.SaveChanges();
			}
		}

		public void RegisterClient(Client client)
		{
			using (var context = new RelaxEntityContext())
			{
				context.Clients.Add(client);
				context.SaveChanges();
				//try
				//{
				//context.Clients.Add(client);
				//context.SaveChanges();
				//}
				//catch (Exception)
				//}
			}
		}

		public void RegisterPM(ProjectManager pm)
		{
			using (var context = new RelaxEntityContext())
			{
				context.ProjectManagers.Add(pm);
				context.SaveChanges();
			}
		}
	}
}

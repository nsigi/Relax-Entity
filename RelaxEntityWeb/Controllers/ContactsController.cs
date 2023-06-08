using Microsoft.AspNetCore.Mvc;
using RelaxEntityWeb.Models.OtherModels;

namespace RelaxEntityWeb.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(Contact contact)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View("Index");
        }
    }
}

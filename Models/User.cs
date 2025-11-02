using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace LoginExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Account");

            ViewBag.User = Session["User"];
            return View();
        }
    }
}

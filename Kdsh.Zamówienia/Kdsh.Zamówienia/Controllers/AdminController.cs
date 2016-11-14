using System.Web.Mvc;

namespace Kdsh.Zamówienia.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            Session["admin"] = true;

            return RedirectToAction("Index", "Zamówienia");
        }

        public ActionResult BrakDostępu()
        {
            return View();
        }
    }
}
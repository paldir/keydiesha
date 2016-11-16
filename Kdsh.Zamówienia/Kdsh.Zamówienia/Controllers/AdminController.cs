using System.Linq;
using System.Web.Mvc;
using Kdsh.Zamówienia.Models.Encje;

namespace Kdsh.Zamówienia.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult BrakDostępu()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Administrator model)
        {
            Administrator administrator;

            using (Kontekst kontekst = new Kontekst())
                administrator = kontekst.Administratorzy.SingleOrDefault(a => (a.Nazwa == model.Nazwa) && (a.Hasło == model.Hasło));

            if (administrator == null)
            {
                ModelState.AddModelError("Błąd logowania", "Nazwa użytkownika i/lub hasło są nieprawidłowe.");

                return View(model);
            }

            Session["admin"] = administrator;

            return RedirectToAction("Index", "Zamówienia");
        }

        public ActionResult Wyloguj()
        {
            Session.Clear();

            return RedirectToAction("Index");
        }
    }
}
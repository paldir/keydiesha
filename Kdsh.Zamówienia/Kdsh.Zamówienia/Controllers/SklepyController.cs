using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kdsh.Zamówienia.Models.Encje;
using Kdsh.Zamówienia.Models.Widok.Sklepy;

namespace Kdsh.Zamówienia.Controllers
{
    public class SklepyController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Index model = new Index();

            using (Kontekst kontekst = new Kontekst())
                model.Sklepy = kontekst.Sklepy.ToArray();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Index model)
        {
            return RedirectToAction("Wybierz", new {idSklepu = model.IdWybranegoSklepu});
        }

        [Route("Sklepy/{idSklepu:int}")]
        public ActionResult Wybierz(long idSklepu)
        {
            const string idCiastka = "idSklepu";
            HttpCookieCollection ciastkaOdpowiedzi = Response.Cookies;
            HttpCookieCollection ciastkaŻądania = Request.Cookies;
            DateTime dziś = DateTime.Now;

            if (ciastkaŻądania[idCiastka] != null)
            {
                HttpCookie ciastkoUsuwające = new HttpCookie(idCiastka) {Expires = dziś.AddDays(-1)};

                ciastkaOdpowiedzi.Add(ciastkoUsuwające);
            }

            HttpCookie ciastko = new HttpCookie(idCiastka, idSklepu.ToString()) {Expires = dziś.AddMonths(1)};

            ciastkaOdpowiedzi.Add(ciastko);

            return RedirectToAction("Index", "Zamówienia");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kdsh.Zamówienia.Models.Encje;
using Kdsh.Zamówienia.Models.Widok.Zamówienia;

namespace Kdsh.Zamówienia.Controllers
{
    public class ZamówieniaController : Controller
    {
        [HttpGet]
        public ActionResult Dodaj()
        {
            Dodaj model = new Dodaj();

            UzupełnijModelDodawania(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Dodaj(Dodaj model)
        {
            if (ModelState.IsValid)
            {
                Zamówienie zamówienie = model.Zamówienie;
                zamówienie.DataZłożenia = DateTime.Now;

                using (Kontekst kontekst = new Kontekst())
                {
                    kontekst.Zamówienia.Add(zamówienie);
                    kontekst.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            UzupełnijModelDodawania(model);

            return View(model);
        }

        public ActionResult Index()
        {
            Zamówienie[] zamówienia;

            using (Kontekst kontekst = new Kontekst())
            {
                Sklep sklep = kontekst.Sklepy.Find(Session["idSklepu"]);
                zamówienia = sklep.Zamówienia.ToArray();
            }

            return View(zamówienia);
        }

        private static void UzupełnijModelDodawania(Dodaj model)
        {
            model.ZasóbNaKolory = new Dictionary<Zasób, Kolor[]>();

            using (Kontekst kontekst = new Kontekst())
            {
                Zasób[] zasoby = kontekst.Zasoby.ToArray();
                model.Zasoby = zasoby;

                foreach (Zasób zasób in zasoby)
                    model.ZasóbNaKolory.Add(zasób, zasób.Kolory.ToArray());
            }
        }
    }
}
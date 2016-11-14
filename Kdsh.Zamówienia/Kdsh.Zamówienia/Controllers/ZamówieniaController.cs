using System;
using System.Data.Entity;
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
            long? idSklepu = Session["idSklepu"] as long?;

            using (Kontekst kontekst = new Kontekst())
            {
                IQueryable<Zamówienie> zamówieniaPośrednie = kontekst.Zamówienia;

                if (idSklepu.HasValue)
                    zamówieniaPośrednie = zamówieniaPośrednie.Where(z => z.SklepId == idSklepu);

                zamówienia = zamówieniaPośrednie.Include(z => z.Kolor).Include(z => z.Status).Include(z => z.Zasób).OrderBy(z => z.StatusId).ThenByDescending(z => z.DataZłożenia).ToArray();
            }

            return View(zamówienia);
        }

        public ActionResult Usuń(long id)
        {
            using (Kontekst kontekst = new Kontekst())
            {
                DbSet<Zamówienie> zamówienia = kontekst.Zamówienia;
                Zamówienie zamówienie = zamówienia.Find(id);

                if (zamówienie != null)
                {
                    zamówienia.Remove(zamówienie);
                    kontekst.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        private static void UzupełnijModelDodawania(Dodaj model)
        {
            using (Kontekst kontekst = new Kontekst())
            {
                model.Sklepy = kontekst.Sklepy.ToArray();
                model.Zasoby = kontekst.Zasoby.Include(z => z.Kolory).ToArray();
            }
        }
    }
}
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
            bool admin = Session["admin"] != null;

            using (Kontekst kontekst = new Kontekst())
            {
                IQueryable<Zamówienie> zamówieniaPośrednie = kontekst.Zamówienia;

                if (!admin)
                {
                    HttpCookie ciastko = Request.Cookies["idSklepu"];

                    if (ciastko == null)
                        return RedirectToAction("Index", "Sklepy");

                    long idSklepu = Convert.ToInt64(ciastko.Value);
                    zamówieniaPośrednie = zamówieniaPośrednie.Where(z => z.SklepId == idSklepu);
                }

                zamówienia = zamówieniaPośrednie.Include(z => z.Kolor).Include(z => z.Status).Include(z => z.Zasób).Include(z => z.Zasób.Kolory).OrderBy(z => z.StatusId).ThenByDescending(z => z.DataZłożenia).ToArray();
            }

            return View(zamówienia);
        }

        public ActionResult PotwierdźOdbiór(long id)
        {
            using (Kontekst kontekst = new Kontekst())
            {
                Zamówienie zamówienie = kontekst.Zamówienia.Find(id);

                if (zamówienie != null)
                {
                    zamówienie.StatusId = 3;
                    kontekst.Entry(zamówienie).State = EntityState.Modified;

                    kontekst.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Status(long id)
        {
            Status model = new Status();

            using (Kontekst kontekst = new Kontekst())
                model.Zamówienie = kontekst.Zamówienia.Include(z => z.Kolor).Include(z => z.Zasób).Single(z => z.Id == id);

            UzupełnijModelStatusu(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Status(Status model)
        {
            using (Kontekst kontekst = new Kontekst())
            {
                Zamówienie noweZamówienie = model.Zamówienie;
                Zamówienie dotychczasoweZamówienie = kontekst.Zamówienia.Find(noweZamówienie.Id);
                dotychczasoweZamówienie.StatusId = noweZamówienie.StatusId;
                kontekst.Entry(dotychczasoweZamówienie).State = EntityState.Modified;

                kontekst.SaveChanges();
            }

            return RedirectToAction("Index");
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

        private static void UzupełnijModelStatusu(Status model)
        {
            using (Kontekst kontekst = new Kontekst())
                model.Statusy = kontekst.StatusyZamówień.ToArray();
        }
    }
}
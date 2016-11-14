using System.Linq;
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
            Session["idSklepu"] = idSklepu;

            return RedirectToAction("Index", "Zamówienia");
        }
    }
}
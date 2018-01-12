using PruebaSumatoriaCubo.BO;
using PruebaSumatoriaCubo.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaSumatoriaCubo.Web.Controllers
{
    public class OperacionesController : Controller
    {
        // GET: Operaciones
        public ActionResult Index()
        {
            InicioViewModel model = new InicioViewModel();
            return View();
        }

       [HttpPost]
        public ActionResult Index(InicioViewModel model)
        {
            model.Salida = OperacionesBO.EvaluarEntrada(model.Operaciones);
            return View(model);
        }
    }
}

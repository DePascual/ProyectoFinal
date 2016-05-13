using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitocracyFinal.Controllers
{
    public class PartialsViewsController : Controller
    {
        
        public ActionResult ServicesPV()
        {
            return View();
        }

        public ActionResult EntrenamientoSmall()
        {
            return View();
        }
    }
}
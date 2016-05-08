using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitocracyFinal.Controllers
{
    public class CoachController : Controller
    {
        // GET
        //View que trabaja a modo de Layout de la sección
        public ActionResult Index()
        {
            return View();
        }


        //PartialsViews
        public ActionResult Home()
        {
            return View();
        }
    }
}
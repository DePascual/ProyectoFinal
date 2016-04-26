using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FITOCRACY.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //Carga la página inicial. Servirá a modo de Layout
        public ActionResult Index()
        {
            return View();
        }

        //Partials
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}
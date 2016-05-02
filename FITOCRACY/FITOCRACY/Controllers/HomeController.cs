using FITOCRACY.Models;
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

        //Partials GET
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

        //Partials POST
        //[HttpPost]
        //public ActionResult Login(usuario usuario)
        //{

        //}

        public void existeUsu(usuarioLogin usu)
        {

        }
    }
}
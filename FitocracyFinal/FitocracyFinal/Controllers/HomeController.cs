using FitocracyFinal.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitocracyFinal.Controllers
{
    public class HomeController : Controller
    {
        //Acceso a Base de Datos
        private MongoDBcontext _dbContext;
        public HomeController()
        {
            _dbContext = new MongoDBcontext();
        }

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
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult messages()
        {
            return View();
        }



        //Metodos
        [HttpPost]
        public bool Logeo(Usuario usuario)
        {
            var existeUsu = false;
            var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
            return existeUsu = collection.AsQueryable().Where(x => x.Username == usuario.Username && x.Password == usuario.Password).Any() ? existeUsu = true : existeUsu = false;
        }
    }
}
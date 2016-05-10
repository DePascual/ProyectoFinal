using FitocracyFinal.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

        #region Partials Views => Carga con Angular
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
        #endregion


        #region Metodos POST 
        //Metodos
        [HttpPost]
        public bool Logeo(Usuario usuario)
        {
            var existeUsu = false;
            var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");           
            return existeUsu = collection.AsQueryable().Where(x => x.Username == usuario.Username && x.Password == usuario.Password).Any() ? existeUsu = true : existeUsu = false;
        }

        [HttpPost]
        public bool Registro (Usuario usuario)
        {
            usuario.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Profiles//nophoto.png")));
            try
            {
                var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
                collection.Insert(usuario);
                return true;
            }
            catch (Exception)
            {
                Console.Write("Error en la inserción del nuevo usuario");
                return false;
            }         
        }
        #endregion

        #region Metodos auxiliares
        //Metodos Auxiliares
        private byte[] ImgToDb(FileInfo info)
        {
            byte[] content = new byte[info.Length];
            FileStream imagestream = info.OpenRead();
            imagestream.Read(content, 0, content.Length);
            imagestream.Close();
            return content;
        }
        #endregion
    }
}
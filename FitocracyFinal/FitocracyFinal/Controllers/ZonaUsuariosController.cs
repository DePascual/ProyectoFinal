using FitocracyFinal.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitocracyFinal.Controllers
{
    public class ZonaUsuariosController : Controller
    {
        //Acceso a Base de Datos
        private MongoDBcontext _dbContext;
        public ZonaUsuariosController()
        {
            _dbContext = new MongoDBcontext();
        }

        // GET: ZonaUsuarios
        //View que trabaja a modo de Layout de la sección
        //public ActionResult Index()
        //{
        //    Usuario usuario = (Usuario)Session["infoUsuario"];
        //    return View(usuario);
        //}

        //Partials Views
        public ActionResult Home()
        {
            Usuario usuario = (Usuario)Session["infoUsuario"];
            return PartialView(usuario);
        }
        public ActionResult You()
        {
            Usuario usuario = (Usuario)Session["infoUsuario"];
            return View(usuario);
        }
        public ActionResult Track()
        {
            Usuario usuario = (Usuario)Session["infoUsuario"];
            return View(usuario);
        }
        public ActionResult Connect()
        {
            return View();
        }
        public ActionResult Leaders()
        {
            return View();
        }


        public void SignOut(string idUsuario)
        {
            Session["infoUsuario"] = null;
        }

        [HttpPost]
        public ActionResult uploadPhoto(HttpPostedFileBase file, string idUsu)
        {

            var url = Url.RequestContext.RouteData.Values["id"];
            if (file != null)
            {
                string pic = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Imagenes/Profiles"), pic);
                file.SaveAs(path);

                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();

                    try
                    {
                        var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
                        var usu = collection.AsQueryable().Where(x => x._id == idUsu).FirstOrDefault();
                        var fotoInicial = usu.Foto;
                        usu.Foto = array;
                        collection.Save(usu);
                    
                        //var usuMod = collection.AsQueryable().Where(x => x._id == idUsu).FirstOrDefault();
                        //var fotoFinal = usuMod.Foto;

                    }
                    catch (Exception e)
                    {
                        string exc = e.ToString();             
                    }
                 
               }

                System.IO.File.Delete(path);
            }

            return Redirect("http://localhost:2841/#/You");
        }

    }
}
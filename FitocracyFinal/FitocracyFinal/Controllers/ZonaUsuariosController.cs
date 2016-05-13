using FitocracyFinal.Models;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            Usuario usu = (Usuario)Session["infoUsuario"];
            return View(usu);
        }

        #region Metodos CAJON DESASTRE
        //public ActionResult downloadPhoto(string id)
        //{
        //    var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
        //    var img = collection.AsQueryable().Where(x => x._id == id).Select(x => x.Foto).FirstOrDefault();
        //    return File(img, "image/jpg");
        //}
        #endregion
    }
}
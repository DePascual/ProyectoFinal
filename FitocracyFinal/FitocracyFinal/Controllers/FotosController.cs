using FitocracyFinal.Models;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitocracyFinal.Controllers
{
    public class FotosController : Controller
    {
        //Acceso a Base de Datos
        private MongoDBcontext _dbContext;
        public FotosController()
        {
            _dbContext = new MongoDBcontext();
        }

        //Download foto por id de usuario
        public ActionResult downloadPhoto(string id)
        {
            var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
            var img = collection.AsQueryable().Where(x => x._id == id).Select(x => x.Foto).FirstOrDefault();
            return File(img, "image/jpg");
        }


        public ActionResult showFotoEntrenamiento(string id)
        {
            var collection = _dbContext.GetDatabase().GetCollection<Entrenamientos>("entrenamientos");
            var img = collection.AsQueryable().Where(x => x._id == id).Select(x => x.Foto).FirstOrDefault();
            return File(img, "image/jpg");
        }


        public ActionResult showEntrenador(string id)
        {
            var collection = _dbContext.GetDatabase().GetCollection<Entrenadores>("entrenadores");
            var img = collection.AsQueryable().Where(x => x._id == id).Select(x => x.Foto).FirstOrDefault();
            return File(img, "image/jpg");
        }
    }
}
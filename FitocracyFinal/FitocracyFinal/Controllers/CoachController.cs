using FitocracyFinal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitocracyFinal.Controllers
{
    public class CoachController : Controller
    {
        //Acceso a Base de Datos
        private MongoDBcontext _dbContext;
        public CoachController()
        {
            _dbContext = new MongoDBcontext();
        }

        // GET
        //View que trabaja a modo de Layout de la sección
        public ActionResult Index()
        {
            return View();
        }

        //PartialsViews
        public ActionResult Home()
        {
            CargaCoach();
            return View();
        }

        public void CargaCoach()
        {
            Entrenadores nuevoEntrenador = new Entrenadores();
            nuevoEntrenador.Nombre = "Berzinator";
            nuevoEntrenador.Apellidos = "Ator";
            nuevoEntrenador.Descripcion = "Tim Berzins (Berzinator) owns and operates Berzinator Fitness Designs, a training and online coaching company based just outside of Philadelphia. With a focus on maximizing aesthetics, Tim is never satisfied with the status quo.";
            nuevoEntrenador.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Berzinator.jpg")));

            var collection = _dbContext.GetDatabase().GetCollection<Usuario>("entrenadores");
            collection.Insert(nuevoEntrenador);


        }

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
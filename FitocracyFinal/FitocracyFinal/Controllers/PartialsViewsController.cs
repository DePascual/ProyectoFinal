using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitocracyFinal.Models;
using FitocracyFinal.ViewModels;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;

namespace FitocracyFinal.Controllers
{
    public class PartialsViewsController : Controller
    {

        //Acceso a Base de Datos
        private MongoDBcontext _dbContext;
        public PartialsViewsController()
        {
            _dbContext = new MongoDBcontext();
        }


        public ActionResult ServicesPV()
        {
            return View();
        }

        public ActionResult EntrenamientoSmall()
        {
            return View();
        }

        public ActionResult TablaDatosWorkout(Workouts workout, Tracks[] tracks)
        {
            WorkoutTracksTablaDatosVM datosVM = new WorkoutTracksTablaDatosVM();
            datosVM.workoutVM = workout;
            datosVM.tracksVM = tracks;

            return View(datosVM);
        }

        public ActionResult WorkoutCarruselPV()
        {
            WorkoutTracksTablaDatosVM datosVM = new WorkoutTracksTablaDatosVM();
            if (TempData["workOut"] != null)
            {
                datosVM = (WorkoutTracksTablaDatosVM)TempData["workOut"];
            }
            return View(datosVM);
        }

        public ActionResult UserInfo()
        {
            Usuario usuario = (Usuario)Session["infoUsuario"];
            var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
            var usuCollection = collection.AsQueryable().Where(x => x._id == usuario._id).FirstOrDefault();
            return View(usuCollection);
        }

        public ActionResult UserChangePass()
        {
            Usuario usuario = (Usuario)Session["infoUsuario"];
            return View(usuario);
        }

        public ActionResult UserWorkouts()
        {
            return View();
        }
        public ActionResult UserEvolution()
        {
            return View();
        }
        public ActionResult SummaryLevels()
        {
            var collection = _dbContext.GetDatabase().GetCollection<Levels>("levels");
            var levels = collection.FindAll().ToList();

            return View(levels);
        }

        [HttpGet]
        public string evolucionUsu()
        {
            List<Evolution> datos = new List<Evolution>();

            Usuario usuario = (Usuario)Session["infoUsuario"];
            var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
            var usuCollection = collection.AsQueryable().Where(x => x._id == usuario._id).FirstOrDefault();


            string yearActual = DateTime.Today.Year.ToString();

            foreach (var dicAnyos in usuCollection.EvolutionUser)
            {
                if (dicAnyos.Key.Equals(yearActual))
                {
                    foreach (var mes in dicAnyos.Value)
                    {
                        Evolution ev = new Evolution();
                        ev.Mes = mes.Key;
                        ev.Puntos = mes.Value;
                        datos.Add(ev);
                    }
                }                     
            }

         return JsonConvert.SerializeObject(datos);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitocracyFinal.Models;
using FitocracyFinal.ViewModels;

namespace FitocracyFinal.Controllers
{
    public class PartialsViewsController : Controller
    {
        
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
           
            //WorkoutTracksTablaDatosVM datosVM = new WorkoutTracksTablaDatosVM();
            //datosVM.workoutVM = workout;
            //datosVM.tracksVM = tracks;
            return View(datosVM);
        }
    }
}
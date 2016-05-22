using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitocracyFinal.Models;

namespace FitocracyFinal.ViewModels
{
    public class WorkoutTracksTablaDatosVM
    {
        public Workouts workoutVM { get; set; }
        public Tracks[] tracksVM { get; set; }
    }
}
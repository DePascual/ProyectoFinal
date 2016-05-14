﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitocracyFinal.Models;
namespace FitocracyFinal.ViewModels
{
    public class EntrenamientoEntrenadoresVM
    {
       
        public List<Entrenadores> entrenadoresList { get; set; }
        public List<Entrenamientos> entrenamientosList { get; set; }

        public Entrenadores entrenador { get; set; }
        public Entrenamientos entrenamiento { get; set; }

        public EntrenamientoEntrenadoresVM(List<Entrenadores> entrenadoresList, List<Entrenamientos> entrenamientosList)
        {
            this.entrenadoresList = entrenadoresList;
            this.entrenamientosList = entrenamientosList;
        }
        public EntrenamientoEntrenadoresVM(Entrenadores entrenador, Entrenamientos entrenamiento)
        {
            this.entrenador = entrenador;
            this.entrenamiento = entrenamiento;
        }
    }
}
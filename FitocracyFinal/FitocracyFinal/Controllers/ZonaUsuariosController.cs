using FitocracyFinal.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
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
            Usuario usuario = (Usuario)Session["infoUsuario"];
            return View(usuario);
        }

        public ActionResult WorkoutDoneAlert()
        {
            Usuario usuario = (Usuario)Session["infoUsuario"];
            return View(usuario);
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

        
        [HttpPost]
        public ActionResult workoutDone(string _idWorkout)
        {
            Usuario usuario = (Usuario)Session["infoUsuario"];

            EntrenamientosUsuarios eUsu = new EntrenamientosUsuarios();
            eUsu.idUsuario = usuario._id;
            eUsu.idWorkout = _idWorkout;

            try
            {
                var collection = _dbContext.GetDatabase().GetCollection<EntrenamientosUsuarios>("entrenamientosUsuarios");
                collection.Insert(eUsu);
            }
            catch (Exception e)
            {
                string ex = e.ToString();
            }
            return Redirect("http://localhost:2841/#/WorkoutDoneAlert");
        }


        [HttpPost]
        public string recuperaWorkouts()
        {
            try
            {
                var collection = _dbContext.GetDatabase().GetCollection<Workouts>("workouts");
                var workouts = collection.FindAll().ToList();
                return JsonConvert.SerializeObject(workouts);
            }
            catch (Exception)
            {

                return null;
            }
        }

        [HttpPost]
        public string recuperaWorkoutsUsu()
        {
            Usuario usuario = (Usuario)Session["infoUsuario"];
            List<Workouts> workoutsUsu = new List<Workouts>();

            try
            {
                var collection = _dbContext.GetDatabase().GetCollection<EntrenamientosUsuarios>("entrenamientosUsuarios");
                var idWorkouts = collection.AsQueryable().Where(x => x.idUsuario == usuario._id).Select(x => x).ToList();

                var collectionWorkouts = _dbContext.GetDatabase().GetCollection<Workouts>("workouts");
                foreach (var workout in idWorkouts)
                {
                    workoutsUsu.Add(collectionWorkouts.AsQueryable().Where(x => x._id == workout.idWorkout).Select(x => x).SingleOrDefault());
                }

                return JsonConvert.SerializeObject(workoutsUsu);
            }
            catch (Exception)
            {

                return null;
            }
        }

        [HttpPost]
        public string recuperaAllTracks()
        {
            try
            {
                var collection = _dbContext.GetDatabase().GetCollection<Tracks>("tracks");
                var tracks = collection.FindAll().ToList();
                return JsonConvert.SerializeObject(tracks);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public string buscadorTracks(string textoBusqueda)
        {
            try
            {
                var collection = _dbContext.GetDatabase().GetCollection<Tracks>("tracks");
                var tracksEncontrados = collection.AsQueryable().Where(x => x.Nombre.Contains(textoBusqueda)).Select(x => x).ToList();
                return JsonConvert.SerializeObject(tracksEncontrados);
            }
            catch (Exception e)
            {
                string ex = e.ToString();
                return null;
            }
        }

        [HttpPost]
        public string UpdateUser(Usuario user)
        {
            Usuario usuario = (Usuario)Session["infoUsuario"];

            try
            {
                var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
                var usuCollection = collection.AsQueryable().Where(x => x._id == usuario._id).FirstOrDefault();

                usuCollection.Username = user.Username != null ? user.Username : usuCollection.Username;
                usuCollection.Birthday = user.Birthday != null ? user.Birthday : usuCollection.Birthday;
                usuCollection.Description = user.Description != null ? user.Description : usuCollection.Description;

                collection.Save(usuCollection);

                var usuChanged = collection.AsQueryable().Where(x => x._id == usuario._id).FirstOrDefault();
                return JsonConvert.SerializeObject(usuChanged);

            }
            catch (Exception e)
            {
                string exc = e.ToString();
                return null;
            }

        }


        #region Carga collection "tracks" MongoDB
        public void cargaTracks()
        {
            var collection = _dbContext.GetDatabase().GetCollection<Tracks>("tracks");

            Tracks t1 = new Tracks();
            t1.Nombre = "Jumping Jacks";
            t1.Link = "https://www.youtube.com/embed/lMOJlsYJKXc";
            t1.Series = 3;
            t1.Repeticiones = 15;

            Tracks t2 = new Tracks();
            t2.Nombre = "Push_Up";
            t2.Link = "https://www.youtube.com/embed/FF4xFb-aLfU";
            t2.Series = 3;
            t2.Repeticiones = 15;

            Tracks t3 = new Tracks();
            t3.Nombre = "Body Weight Squat";
            t3.Link = "https://www.youtube.com/embed/AT-DJd0ZpD0";
            t3.Series = 3;
            t3.Repeticiones = 15;

            Tracks t4 = new Tracks();
            t4.Nombre = "Bench Dips";
            t4.Link = "https://www.youtube.com/embed/efuIA5uPdZE";
            t4.Series = 3;
            t4.Repeticiones = 15;

            Tracks t5 = new Tracks();
            t5.Nombre = "Body Weight Lunge";
            t5.Link = "https://www.youtube.com/embed/uRgtZ1ZfXXI";
            t5.Series = 3;
            t5.Repeticiones = 15;

            Tracks t6 = new Tracks();
            t6.Nombre = "Burpee";
            t6.Link = "https://www.youtube.com/embed/J9e_rAM1KNw";
            t6.Series = 3;
            t6.Repeticiones = 15;

            Tracks t7 = new Tracks();
            t7.Nombre = "Standing Dumbbel Shoulder Press";
            t7.Link = "https://www.youtube.com/embed/lH5eU1vk9XM";
            t7.Series = 3;
            t7.Repeticiones = 12;

            Tracks t8 = new Tracks();
            t8.Nombre = "Standing Dumbbell Upright Row";
            t8.Link = "https://www.youtube.com/embed/Vol9MoFquLc";
            t8.Series = 3;
            t8.Repeticiones = 12;

            Tracks t9 = new Tracks();
            t9.Nombre = "Dumbbell Side Lateral Risew";
            t9.Link = "https://www.youtube.com/embed/KwxJ6_M45ak";
            t9.Series = 3;
            t9.Repeticiones = 12;

            Tracks t10 = new Tracks();
            t10.Nombre = "Front Dumbbell Raise";
            t10.Link = "https://www.youtube.com/embed/iL2YEipjE6Y";
            t10.Series = 3;
            t10.Repeticiones = 12;

            Tracks t11 = new Tracks();
            t11.Nombre = "Dumbbell Bicep Curl";
            t11.Link = "https://www.youtube.com/embed/d6t-P_0Q5TI";
            t11.Series = 3;
            t11.Repeticiones = 12;

            Tracks t12 = new Tracks();
            t12.Nombre = "Hammer Dumbbell Curl";
            t12.Link = "https://www.youtube.com/embed/El9fbXdh-8w";
            t12.Series = 3;
            t12.Repeticiones = 12;

            Tracks t13 = new Tracks();
            t13.Nombre = "Concentrations Curls";
            t13.Link = "https://www.youtube.com/embed/hNRKnqZVOVM";
            t13.Series = 3;
            t13.Repeticiones = 12;

            Tracks t14 = new Tracks();
            t14.Nombre = "Jump Squat (Toyotas)";
            t14.Link = "https://www.youtube.com/embed/JsX6qU1-pfE";
            t14.Series = 1;
            t14.Repeticiones = 20;

            Tracks t15 = new Tracks();
            t15.Nombre = "Side Lunges";
            t15.Link = "https://www.youtube.com/embed/igefioGFrUM";
            t15.Series = 1;
            t15.Repeticiones = 20;

            Tracks t16 = new Tracks();
            t16.Nombre = "Flat Knee Raise";
            t16.Link = "https://www.youtube.com/embed/zWw3FvB9LTc";
            t16.Series = 1;
            t16.Repeticiones = 20;

            Tracks t17 = new Tracks();
            t17.Nombre = "Mountain Climber";
            t17.Link = "https://www.youtube.com/embed/yNk6nfcMdnQ";
            t17.Series = 1;
            t17.Repeticiones = 20;

            Tracks t18 = new Tracks();
            t18.Nombre = "Wide Arm Push-Up";
            t18.Link = "https://www.youtube.com/embed/9wT49ZdqxvE";
            t18.Series = 2;
            t18.Repeticiones = 20;

            Tracks t19 = new Tracks();
            t19.Nombre = "Plank";
            t19.Link = "https://www.youtube.com/embed/0YvVHLJsN3k";
            t19.Series = 3;
            t19.Repeticiones = 30;

            Tracks t20 = new Tracks();
            t20.Nombre = "Alternative Body Weight Reverse Lunge";
            t20.Link = "https://www.youtube.com/embed/V2TDMKu8JmI";
            t20.Series = 4;
            t20.Repeticiones = 8;

            Tracks t21 = new Tracks();
            t20.Nombre = "Glute Bridge";
            t20.Link = "https://www.youtube.com/embed/-_yZY7sirrE";
            t20.Series = 3;
            t20.Repeticiones = 15;

            Tracks t22 = new Tracks();
            t22.Nombre = "Incline Push-Up";
            t22.Link = "https://www.youtube.com/embed/TFcMqG6lPpo";
            t22.Series = 3;
            t22.Repeticiones = 10;

            try {

                collection.Insert(t1);
                collection.Insert(t2);
                collection.Insert(t3);
                collection.Insert(t4);
                collection.Insert(t5);
                collection.Insert(t6);
                collection.Insert(t7);
                collection.Insert(t8);
                collection.Insert(t9);
                collection.Insert(t10);
                collection.Insert(t11);
                collection.Insert(t12);
                collection.Insert(t13);
                collection.Insert(t14);
                collection.Insert(t15);
                collection.Insert(t16);
                collection.Insert(t17);
                collection.Insert(t18);
                collection.Insert(t19);
                collection.Insert(t20);
                collection.Insert(t21);
                collection.Insert(t22);
            }catch (Exception e)
            {
                var ex = e;
            }

        }

        #endregion

        #region Carga collection "workouts" MongoDB
        public void cargaWorkouts()
        {
            var collection = _dbContext.GetDatabase().GetCollection<Workouts>("workouts");
            var collectionTracks = _dbContext.GetDatabase().GetCollection<Tracks>("tracks");

            Workouts w2 = new Workouts();
            w2.Nombre = "Bye Bye Belly Fat Bodyweight Challenge";
            w2.Puntos = 150;

            List<Tracks> l2 = new List<Tracks>();
            var t11 = collectionTracks.AsQueryable().Where(x => x._id == "574019fd29d04719f856f07c").Select(x => x).SingleOrDefault();
            var t21 = collectionTracks.AsQueryable().Where(x => x._id == "574019fd29d04719f856f07e").Select(x => x).SingleOrDefault();
            var t31 = collectionTracks.AsQueryable().Where(x => x._id == "574019fe29d04719f856f087").Select(x => x).SingleOrDefault();
            var t41 = collectionTracks.AsQueryable().Where(x => x._id == "574019fe29d04719f856f088").Select(x => x).SingleOrDefault();
            var t51 = collectionTracks.AsQueryable().Where(x => x._id == "574019fc29d04719f856f07a").Select(x => x).SingleOrDefault();
            var t61 = collectionTracks.AsQueryable().Where(x => x._id == "574019fd29d04719f856f07b").Select(x => x).SingleOrDefault();
            var t71 = collectionTracks.AsQueryable().Where(x => x._id == "574019ff29d04719f856f089").Select(x => x).SingleOrDefault();
            var t81 = collectionTracks.AsQueryable().Where(x => x._id == "574019fd29d04719f856f07c").Select(x => x).SingleOrDefault();
            var t91 = collectionTracks.AsQueryable().Where(x => x._id == "574019fd29d04719f856f07f").Select(x => x).SingleOrDefault();
            var t101 = collectionTracks.AsQueryable().Where(x => x._id == "574019ff29d04719f856f08a").Select(x => x).SingleOrDefault();

            l2.Add(t11);
            l2.Add(t21);
            l2.Add(t31);
            l2.Add(t41);
            l2.Add(t51);
            l2.Add(t61);
            l2.Add(t71);
            l2.Add(t81);
            l2.Add(t91);
            l2.Add(t101);

            w2.Tracks = l2;


            Workouts w3 = new Workouts();
            w3.Nombre = "Bye Bye Belly Fat Bodyweight Challenge";
            w3.Puntos = 150;

            List<Tracks> l3 = new List<Tracks>();
            var t12 = collectionTracks.AsQueryable().Where(x => x._id == "574019fd29d04719f856f07c").Select(x => x).SingleOrDefault();
            var t22 = collectionTracks.AsQueryable().Where(x => x._id == "574019ff29d04719f856f08b").Select(x => x).SingleOrDefault();
            var t32 = collectionTracks.AsQueryable().Where(x => x._id == "574019ff29d04719f856f08c").Select(x => x).SingleOrDefault();
            var t42 = collectionTracks.AsQueryable().Where(x => x._id == "574019ff29d04719f856f08d").Select(x => x).SingleOrDefault();
            var t52 = collectionTracks.AsQueryable().Where(x => x._id == "574019ff29d04719f856f08e").Select(x => x).SingleOrDefault();
            var t62 = collectionTracks.AsQueryable().Where(x => x._id == "57401a0029d04719f856f08f").Select(x => x).SingleOrDefault();
            var t72 = collectionTracks.AsQueryable().Where(x => x._id == "574019ff29d04719f856f08c").Select(x => x).SingleOrDefault();

            l3.Add(t12);
            l3.Add(t22);
            l3.Add(t32);
            l3.Add(t42);
            l3.Add(t52);
            l3.Add(t62);
            l3.Add(t72);

            w3.Tracks = l3;

            try
            {
                collection.Insert(w2);
                collection.Insert(w3);
            }
            catch (Exception e)
            {
                var ex = e;
            }
        }
        
        #endregion

    }
}
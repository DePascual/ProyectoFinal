﻿using FitocracyFinal.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

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

        private Usuario _usuario;
        public Usuario usuario
        {
            get
            {
                return _usuario = (Usuario)Session["infoUsuario"];
            }
            set
            {
                this._usuario = value;
            }
        }


        //View que trabaja a modo de Layout de la sección
        public ActionResult Index()
        {
            return View(usuario);
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

        public ActionResult ChangePass()
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

        public string loginRecupUsuario(Usuario usuario)
        {
            EncriptacionClass encriptar = new EncriptacionClass();
            string passEncriptada = encriptar.Encrit(usuario.Password);

            Usuario usu = new Usuario();
            try
            {
                var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
                var datosUsu = collection.AsQueryable()
                    .Where(x => x.Username == usuario.Username && x.Password == passEncriptada)
                    .Select(x => new Usuario
                    {
                        _id = (string)x._id,
                        Username = (string)x.Username,
                        Email = (string)x.Email
                    }).SingleOrDefault();

                Session["infoUsuario"] = datosUsu;

                return JsonConvert.SerializeObject(datosUsu);
            }
            catch (Exception)
            {
                return null;
            }
        }


        [HttpPost]
        public string Registro(Usuario usuario)
        {
            EncriptacionClass encriptar = new EncriptacionClass();
            string passEncriptada = encriptar.Encrit(usuario.Password);

            usuario.Password = passEncriptada;
            usuario.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Profiles//nophoto.png")));
            usuario.WorkoutsUser = new Dictionary<string, Workouts>();
            usuario.CustomWorkouts = new Dictionary<string, Workouts>();

            int yearActual = DateTime.Today.Year;
            int mesActual = DateTime.Today.Month;

            Dictionary<string, Dictionary<string, int>> nuevoDicAnyo = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> nuevoDicMeses = new Dictionary<string, int>();

            for (int i = 0; i < 12; i++)
            {
                nuevoDicMeses.Add((i + 1).ToString(), 0);
            }

            nuevoDicAnyo.Add(yearActual.ToString(), nuevoDicMeses);

            usuario.EvolutionUser = nuevoDicAnyo;

            try
            {
                var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
                var existe = collection.AsQueryable().Where(x => x.Email == usuario.Email).Any();
                if (!existe)
                {
                    collection.Insert(usuario);
                    Session["infoUsuario"] = usuario;

                    return JsonConvert.SerializeObject(usuario);
                }
                else
                {
                    return null;
                }


            }
            catch (Exception e)
            {
                String ex = e.ToString();
                Console.Write("Error en la inserción del nuevo usuario");
                return null;
            }
        }

        [HttpPost]
        public bool ForgotPassword(string Email)
        {
            var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
            var usu = collection.AsQueryable().Where(x => x.Email == Email).Select(x => x).FirstOrDefault();

            try
            {
                string newPass = generaNuevaPassword();
                bool ok = UpdatePassword(newPass, usu);
                SendEmailClass.EmailChangePass(usu, newPass);
                return true;
            }
            catch (Exception e)
            {
                string ex = e.ToString();
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


        public string generaNuevaPassword()
        {
            string newPass = "";
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int n = caracteres.Length;

            Random r = new Random();

            for (int i = 0; i < 12; i++)
            {
                newPass += caracteres[r.Next(n)];
            }
            return newPass;
        }


        public bool UpdatePassword(string passNew, Usuario usuario)
        {
            EncriptacionClass encriptar = new EncriptacionClass();
            string passEncriptadaNew = encriptar.Encrit(passNew);

            try
            {
                var collection = _dbContext.GetDatabase().GetCollection<Usuario>("usuarios");
                var usuCollection = collection.AsQueryable().Where(x => x._id == usuario._id).FirstOrDefault();
                usuCollection.Password = passEncriptadaNew;
                collection.Save(usuCollection);
                return true;

            }
            catch (Exception e)
            {
                string exc = e.ToString();
                return false;
            }
        }
        #endregion
    }
}
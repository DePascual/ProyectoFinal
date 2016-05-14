using FitocracyFinal.Models;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitocracyFinal.ViewModels;

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


        //Post
        [HttpPost]
        public JsonResult GetEntrenadores()
        {
            var collection = _dbContext.GetDatabase().GetCollection<Entrenadores>("entrenadores");
            var ret = collection.AsQueryable().Select(x => (Entrenadores)x).ToList();
            return Json(ret);           
        }

        //PartialsViews
        public ActionResult Home()
        {
            var collection = _dbContext.GetDatabase().GetCollection<Entrenamientos>("entrenamientos");
            List<Entrenamientos> entrenamientosList = collection.AsQueryable().Select(x => (Entrenamientos)x).ToList();

            var collection2 = _dbContext.GetDatabase().GetCollection<Entrenadores>("entrenadores");
            List<Entrenadores> entrenadoresList = collection2.AsQueryable().Select(x => (Entrenadores)x).ToList();

            EntrenamientoEntrenadoresVM vM = new EntrenamientoEntrenadoresVM(entrenadoresList, entrenamientosList);

            return View(vM);
        }

        public ActionResult detalleEntrenamiento(EntrenamientoEntrenadoresVM datos)
        {
            return View(datos);
        }

        #region Carga collection "Entrenadores" MongoDb
        public void CargaCoach()
        {
            var collection = _dbContext.GetDatabase().GetCollection<Usuario>("entrenadores");

            Entrenadores e1 = new Entrenadores();
            e1.Nombre = "Jason";
            e1.Apellidos = "Anyman Fitness";
            e1.Descripcion = "I am an Online Fitness Consultant from Michigan, and the founder of Anyman Fitness, LLC. I'm also a Husband, Father, Algebra Teacher, and All-American Living Room Fort Maker. I've helped thousands get lean and mean. Without cardio.";
            e1.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenadores//Jason.jpg")));

            Entrenadores e2 = new Entrenadores();
            e2.Nombre = "Stacy";
            e2.Apellidos = "Dishman";
            e2.Descripcion = "Hi, I'm Stacy, your Certified Personal Trainer. I have a passion for health and fitness, and helping my clients reach their goals. My workouts are fun, sweat-drenching, and never the same!";
            e2.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenadores//Stacy.jpg")));

            Entrenadores e3 = new Entrenadores();
            e3.Nombre = "Tanner";
            e3.Apellidos = "Baze";
            e3.Descripcion = "Whoever said fitness had to be all about douchebags can gtfo. I like to lift weights, watch romcoms, cuddle with humans and my dog Bowser. Lover of all things Star Wars and Harry Potter. If you take Superman over Batman, we aren't friends.";
            e3.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenadores//tanner.jpg")));

            Entrenadores e4 = new Entrenadores();
            e4.Nombre = "Mike";
            e4.Apellidos = "Yanda";
            e4.Descripcion = "I am an Attorney and nutrition/fitness consultant from the great state of Texas. I lift heavy, eat big, and work hard. My goal is show people how to make fitness work with their busy schedules.";
            e4.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenadores//mike.jpg")));

            Entrenadores e5 = new Entrenadores();
            e5.Nombre = "Jordan";
            e5.Apellidos = "Pagel";
            e5.Descripcion = "A NSCA Certified Personal Trainer, my passion is helping others reach their fitness goals. With 3 years of fat loss & strength training experience, my mission is to help you sculpt the body you want and become the best possible version of yourself!";
            e5.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenadores//pagel.jpg")));

            Entrenadores e6 = new Entrenadores();
            e6.Nombre = "Allison";
            e6.Apellidos = "Padget";
            e6.Descripcion = "Allison is a certified Personal Trainer and weight loss expert. She will help you reach a healthier and more active lifestyle. She is passionate about fitness and helping others find balance.";
            e6.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenadores//Allison.jpg")));

            Entrenadores e7 = new Entrenadores();
            e6.Nombre = "Shelley";
            e6.Apellidos = "Murray";
            e6.Descripcion = "I am a lifelong athlete turned strength & conditioning specialist & I help clients get stronger, faster & look better naked. I'm also a litigation attorney, a rugby junkie & an all around social butterfly known around the Fito world as Justass. :)";
            e6.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenadores//shelley.jpg")));

            Entrenadores e8 = new Entrenadores();
            e8.Nombre = "Berzinator";
            e8.Apellidos = "Ator";
            e8.Descripcion = "Tim Berzins (Berzinator) owns and operates Berzinator Fitness Designs, a training and online coaching company based just outside of Philadelphia. With a focus on maximizing aesthetics, Tim is never satisfied with the status quo.";
            e8.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenadores//berzinator.jpg")));

            collection.Insert(e1);
            collection.Insert(e2);
            collection.Insert(e3);
            collection.Insert(e4);
            collection.Insert(e5);
            collection.Insert(e6);
            collection.Insert(e7);
            collection.Insert(e8);
        }
        #endregion

        #region Carga collection "Entrenamientos" MongoDb
        public void CargaEntrenamiento()
        {

            //Entrenamientos e1 = new Entrenamientos();
            //e1.Familia = "Weight Loss";
            //e1.NombreEntrenamiento = "Shredded in '16 2.0";
            //e1.Id_Entrenador = "5735afbd29d047287cd95199";
            //e1.Precio = "39";
            //e1.Duracion = "16";
            //e1.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenamientos//WL_1.jpg")));
            //e1.Descripcion = "Shredded in '16 is the only program you need this year. Don't give up on your resolution just yet! This program is designed to help you shred fat, build lean muscle, and get you sexier than ever.";
            //e1.Who = "A beginner to advanced course for men and women that requires gym access";
            //e1.Goals = "A lean, sexy physique.A body designed to do anything.Become the most confident version of yourself";
            //e1.Requirements = "Access to barbells, dumbbells, and kettlebells.Experience with basic movements, such as squats, deadlifts, pressing, rowing, and swings.Ability to train 3 - 4x per week for approx, 1 hour.Ability to count calories and macronutrients, or willingness to learn.Desire to make meaningful, long - lasting, positive changes in your life";
            //e1.WhatYouGet = "New workouts each month designed to help you shred fat, gain strength, and become all kinds of sexy.Updated plan each month based on client progress, feedback, measurements, and progress pictures.Personalized nutrition plan based on your current eating habits and preferences.Unlimited email and social media support to answer your questions and provide support 24 / 7.Weekly Q & A's and article discussions to help increase your fitness knowledge.Confidence like you've never had before!";

            //Entrenamientos e2 = new Entrenamientos();
            //e2.Familia = "Weight Loss";
            //e2.NombreEntrenamiento = "Total Body HIIT!";
            //e2.Id_Entrenador = "5735afbd29d047287cd95196";
            //e2.Precio = "45";
            //e2.Duracion = "12";
            //e2.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenamientos//WL_2.jpg")));
            //e2.Descripcion = "Ready to lose fat and tone at the same time in as little as 30 minutes a workout? HIIT (high intensity interval training) is the perfect program to get you maximum results in a short amount of time!";
            //e2.Who = "A beginner to advanced course for men and women that requires gym access";
            //e2.Goals = "Lose Fat.Gain Strength.Gain Endurance.Gain Athletic Performance";
            //e2.Requirements = "30-40 minutes; 4-5x per week.Access to dumbbells, kettle bells, stability ball, jump rope, and resistance band.Dedication to stick to the program!";
            //e2.WhatYouGet = "Nutritional Guidance.Weekly Customized Fitness Plan.24/7 Support and Guidance";

            //Entrenamientos e3 = new Entrenamientos();
            //e3.Familia = "Weight Loss";
            //e3.NombreEntrenamiento = "Fitness Over 40 II";
            //e3.Id_Entrenador = "5735afbd29d047287cd9519a";
            //e3.Precio = "65";
            //e3.Duracion = "16";
            //e3.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenamientos//WL_3.jpg")));
            //e3.Descripcion = "Getting & staying in shape as we get older can be a challenge, but with the right mix of training & nutrition you can become the leanest, strongest & healthiest that you've ever been.. even over 40!";
            //e3.Who = "A beginner to advanced course for men and women that requires gym access";
            //e3.Goals = "Improve overall fitness.Gain strength.Lose bodyfat.Learn a lifetime of healthy habits.Feel like a kid again";
            //e3.Requirements = "Gym access.Willing to track calories/macros.Willing to strength train 3 days per week.Must be over 40 but young at heart!!";
            //e3.WhatYouGet = "A customized nutrition plan for each group member.A workout plan designed to fit your goals.Access to our own Fitocracy group.Google hangouts with the group, plus unlimited email and PM access to me.Fun group challenges and contests.A cool new body and more energy then you've had since your 20's!";

            //Entrenamientos e4 = new Entrenamientos();
            //e4.Familia = "Weight Loss";
            //e4.NombreEntrenamiento = "Custom Physique 1 on 1 coaching";
            //e4.Id_Entrenador = "5735afc429d047287cd9519c";
            //e4.Precio = "99";
            //e4.Duracion = "16";
            //e4.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenamientos//WL_4.jpg")));
            //e4.Descripcion = "Specializing in aesthetics and performance, my unique hybrid training approach will get you leaner than ever. Includes 100% custom workouts, weekly macro adjustments, monthly Skype call, and more.";
            //e4.Who = "A beginner to advanced course for men and women that requires gym access";
            //e4.Goals = "Lose Fat.Build Muscle.Gain an aesthetic physique";
            //e4.Requirements = "Access to barbells/dumbbells.Familiar with basic movements - squat, deadlift, etc.Basic experience tracking macros preferred (not necessary)";
            //e4.WhatYouGet = "100% customized workout program, updated as needed.100% customized nutrition plan.Weekly check-in with macro/training adjustments as needed.Unlimited individual support. I respond to messages within 24 hours, usually much sooner, and weekly check-ins are done via email every weekend.Monthly Skype call to discuss your program, if needed.Extensive and unlimited form critique if you are able to send me videos.";

            //Entrenamientos e5 = new Entrenamientos();
            //e5.Familia = "Weight Loss";
            //e5.NombreEntrenamiento = "Von Blanco Fitness-Elite 1:1";
            //e5.Id_Entrenador = "5735afbd29d047287cd95197";
            //e5.Precio = "197";
            //e5.Duracion = "20";
            //e5.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenamientos//WL_5.jpg")));
            //e5.Descripcion = "[LIMITED SPOTS] If you're looking for a no-BS approach to your training and nutrition, this 1:1 private coaching program with Slyvon Blanco is for you. Sign up now to claim your spot.";
            //e5.Who = "A beginner to advanced course for men and women that requires gym access";
            //e5.Goals = "Shred fat.Build muscle and strength.Develop long-term nutrition habits";
            //e5.Requirements = "General knowledge of macronutrients (protein, carbs, fat).Access to weights.Commitment and dedication to get better every day.Have an open mind";
            //e5.WhatYouGet = "Individualized macronutrient targets optimized for your goal.Individualized training program designed for fat loss and/or muscle gain.Updated workout routines every 4 weeks.Weekly lessons on how to simplify your fitness (and life).Monthly Q&A video chats/webinars.Unlimited email and text messaging support";

            //Entrenamientos e6 = new Entrenamientos();
            //e6.Familia = "Muscle Gain";
            //e6.NombreEntrenamiento = "1:1 Strength and Aesthetics";
            //e6.Id_Entrenador = "5735afbc29d047287cd95195";
            //e6.Precio = "100";
            //e6.Duracion = "20";
            //e6.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenamientos//MG_Strength.jpg")));
            //e6.Descripcion = "This is my 1:1 offering for clients who want a completely personalized approach to resistance training and nutrition.";
            //e6.Who = "A beginner to advanced one on one training program for men and women that requires gym access";
            //e6.Goals = "Gain strength.Gain muscle.Burn fat.Learn the intricacies of the exercises prescribed to you.Education on a variety of nutritional aspects personalized to your individual needs";
            //e6.Requirements = "Gym access is suggested but with the right home equipment you will be good to go.Dumbbells/Barbells.Flat Bench.Full power rack/half power rack/squat uprights.Experience or willingness to count and track macros.The inclination to learn about basic lifts and nutrition.Chin-up station/lat pull-down";
            //e6.WhatYouGet = "Weekly customized workouts based on preferences.Weekly program/nutrition check-ins.Personalized macronutrients targets to hit your goals.Example Meals.Example Templates.Customized Conditioning Routines.Support From Yours Truly.Engaging and Detailed Discussion on Fitness related subjects.Exclusive Form Instructional Videos for the Squat, Bench and Deadlift.Video form critique";

            //Entrenamientos e7 = new Entrenamientos();
            //e7.Familia = "Muscle Gain";
            //e7.NombreEntrenamiento = "Aesthetic Build One on One";
            //e7.Id_Entrenador = "5735afbc29d047287cd95195";
            //e7.Precio = "70";
            //e7.Duracion = "20";
            //e7.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenamientos//MG_One.jpg")));
            //e7.Descripcion = "Customized programs, nutrition protocols, and unlimited Fitocracy PM messages to your 'Aesthetic Build' coach for questions and program updates and changes.";
            //e7.Who = "A beginner to advanced one on one training program for men and women that requires gym access";
            //e7.Goals = "Tailored to YOUR specific goal, This is 100% personalized, one on one coaching based on what YOU need for YOUR specific goal.Muscle Gain.Fat Loss.Strength.Performance.Weight Management";
            //e7.Requirements = "Requirements depend on individual goal.MUST have experience counting and tracking calories and macronutrients.Familiarity with basic barbell and dumbell movements preferred but not required";
            //e7.WhatYouGet = "One on one, 100% personalized coaching for your specific goal.Guaranteed response to your questions within 48 hours (often less).Complete training program for your unique situation.Complete diet program including macros for your unique goal.Unlimited Fitocracy PM interaction with coach for program updates and changes";

            //Entrenamientos e8 = new Entrenamientos();
            //e8.Familia = "Muscle Gain";
            //e8.NombreEntrenamiento = "Enigma Training Private 1 on 1";
            //e8.Id_Entrenador = "5735afc429d047287cd9519c";
            //e8.Precio = "79";
            //e8.Duracion = "25";
            //e8.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenamientos//MG_Enigma.jpg")));
            //e8.Descripcion = "The do anything coaching program. You tell me your goals, and I make them a reality. Fitter, faster, stronger, leaner, meaner, healthier, rehab, I do it all. Truly custom training, 10 clients max.";
            //e8.Who = "A beginner to advanced one on one training program for men and women that requires gym access";
            //e8.Goals = "Reach the targets we have set. Nothing more, nothing less. (Well, hopefully more!).To build a greater understanding of your body and how to program for yourself.To enjoy your training, and more so the results!";
            //e8.Requirements = "Being completely honest about your lifestyle and training history.Being completely honest about any programming/diet concerns.Just be honest with me. We can work through anything";
            //e8.WhatYouGet = "Custom training and nutrition plan specific to your goals and history.Weekly adjustments if needed.Bio-mechanical lift/gait video analysis - as often as desired.Individualized weak point/posture/rehab work.A deeper understanding of programming for your goals.24 hour response to questions and queries";

            Entrenamientos e9 = new Entrenamientos();
            e9.Familia = "One";
            e9.NombreEntrenamiento = "Stress Free Private Coaching";
            e9.Id_Entrenador = "5735afbd29d047287cd95196";
            e9.Precio = "99";
            e9.Duracion = "20";
            e9.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenamientos//One_Stress.jpg")));
            e9.Descripcion = "This program is strictly 'one on one'. You'll get a weekly workout plan with nutritional guidance that's customized to your own individual needs/goals, and 24/7 direct access to the coach.";
            e9.Who = "A beginner to intermediate one on one training program for women only that requires minimal home equipment";
            e9.Goals = "Each individual is different, so each member will get a personalized plan after we have discussed what your goals are.Fat Loss.Build Muscle.Gain Strength";
            e9.Requirements = "Your program will be customized to what you have available ie Dumbells, Kettlebells, Stability ball, gym (if you have a membership), etc We can also do totally body weight It's your choice!.The time to train 30-45 minutes; 4-5 x per week.Dedication to stick to the program";
            e9.WhatYouGet = "A 100% personalized workout plan.Private, one on one coaching.Direct, unlimited access to your coach.Nutritional guidance";

            Entrenamientos e10 = new Entrenamientos();
            e10.Familia = "One";
            e10.NombreEntrenamiento = "Transformations Simplified";
            e10.Id_Entrenador = "5735afbd29d047287cd95197";
            e10.Precio = "99";
            e10.Duracion = "20";
            e10.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenamientos//One_Transformation.jpg")));
            e10.Descripcion = "[1-on-1 Coaching]I've lost 200+lbs which I've kept off for 7+years. Work with me to achieve your OWN transformation of mind and body through habits, nutrition, and weight lifting.";
            e10.Who = "A beginner to intermediate one on one training program for women only that requires minimal home equipment";
            e10.Goals = "Fast and sustainable weight loss.Feel full while losing weight.Get stronger, get more muscle, get toned";
            e10.Requirements = "Gym access (barbells AND dumbbells).3 hours per week for training.Experience with weight lifting (or willing to learn).Willingness to count calories and macronutrients.Before and after photos";
            e10.WhatYouGet = "Direct email access with 24-48hr response time!.Uniquely created nutrition plan based on your individual goals.Free Fitocracy Hero!.Access to weekly video Q&A hangout for your questions you'd prefer to be answered in video form!.Form critique (you record and send me video via youtube).Access to community of like-minded people on the same journey";

            Entrenamientos e11 = new Entrenamientos();
            e11.Familia = "One";
            e11.NombreEntrenamiento = "NCFS-Elite";
            e11.Id_Entrenador = "5735afbc29d047287cd95195";
            e11.Precio = "240";
            e11.Duracion = "30";
            e11.Foto = ImgToDb(new FileInfo(Server.MapPath("~//Content//Imagenes//Entrenamientos//One_NCFS.jpg")));
            e11.Descripcion = "No Cardio Fat Shredding Program - Fitocracy's most popular program - in a personalized, 1:1 format.";
            e11.Who = "A beginner to intermediate one on one training program for women only that requires minimal home equipment";
            e11.Goals = "Fat loss with full muscular retention - strength maintenance at the minimum - substantial strength gain is the norm.To look good naked Sexy factor = 7,000.To gain confidence and conquer your domain";
            e11.Requirements = "Willingness to count macronutrients.One hour of training, 3 times per week, cardio not necessary.Access to a new wardrobe upon completion";
            e11.WhatYouGet = "Personalized macronutrient target and fat loss goals.Optimal training program with specific programming instructions.Skills and strategies to handle social situations through the holidays.Exclusive email access and all support as needed for your goals.100% personalized documentation and communication - no 'open forums', no 'DMs', everything through private email communication";

            var collection = _dbContext.GetDatabase().GetCollection<Usuario>("entrenamientos");
            //collection.Insert(e1);
            //collection.Insert(e2);
            //collection.Insert(e3);
            //collection.Insert(e4);
            //collection.Insert(e5);
            //collection.Insert(e6);
            //collection.Insert(e7);
            //collection.Insert(e8);
            collection.Insert(e9);
            collection.Insert(e10);
            collection.Insert(e11);

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
        #endregion
    }
}
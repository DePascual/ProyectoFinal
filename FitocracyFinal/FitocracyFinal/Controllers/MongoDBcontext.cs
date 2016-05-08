using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitocracyFinal.Controllers
{
    public class MongoDBcontext
    {
        private MongoDatabase database;

        //Aquí habría que hashear la contraseña de acceso a la BD
        public MongoDBcontext()
        {
            var uri = "mongodb://DePascual:Magarza22@ds011880.mlab.com:11880/pimerapruebacarol";
            var client = new MongoClient(uri);
            var server = client.GetServer();
            this.database = server.GetDatabase("FitocracyMDB");
        }


        public MongoDatabase GetDatabase()
        {
            return database;
        }
    }
}
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
            var uri = "mongodb://root:Fitocracy1234@ds017582.mlab.com:17582/fitocracymdb";
            var client = new MongoClient(uri);
            var server = client.GetServer();
            this.database = server.GetDatabase("fitocracymdb");
        }


        public MongoDatabase GetDatabase()
        {
            return database;
        }
    }
}
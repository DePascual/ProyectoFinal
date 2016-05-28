using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitocracyFinal.Controllers;

namespace FitocracyFinal.Controllers
{
    public class MongoDBcontext
    {
        private MongoDatabase database;

        //Aquí habría que hashear la contraseña de acceso a la BD
        public MongoDBcontext()
        {
            var uriEncriptada = "mongodb://Tpg17pT9vKIqVbqze4zKltGiQ1fcC/a36ZLWMPnYQLk=@ds017582.mlab.com:17582/fitocracymdb";

            EncriptacionClass encryt = new EncriptacionClass();
            var credencialesEncriptadas = uriEncriptada.Split(new[] { '@' })[0].Split(new[] { "mongodb://" }, StringSplitOptions.None)[1];
            string credencialesOK = encryt.Desencrit(credencialesEncriptadas);

            var uri = "mongodb://" + credencialesOK + "@ds017582.mlab.com:17582/fitocracymdb";
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
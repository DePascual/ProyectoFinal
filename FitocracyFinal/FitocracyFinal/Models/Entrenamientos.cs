using FitocracyFinal.Controllers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitocracyFinal.Models
{
    [BsonIgnoreExtraElements(true)]
    public class Entrenamientos
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string Familia { get; set; }
        public string NombreEntrenamiento { get; set; }
        public string Id_Entrenador { get; set; }
        public string Precio { get; set; }
        public string Duracion { get; set; }
        public string Descripcion { get; set; }
        public byte[] Foto { get; set; }
        public string Who { get; set; }
        public string Goals { get; set; }
        public string Requirements { get; set; }
        public string WhatYouGet { get; set; }

        public Entrenamientos entrenamientoById(string id)
        {
            try
            {
                MongoDBcontext _dbContext = new MongoDBcontext();
                var collection = _dbContext.GetDatabase().GetCollection<Entrenamientos>("entrenamientos");
                return collection.AsQueryable().Where(x => x._id == id).Select(x => (Entrenamientos)x).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
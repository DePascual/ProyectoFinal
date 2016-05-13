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
    public class Entrenadores
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Descripcion { get; set; }
        public byte[] Foto { get; set; }

        public Entrenadores entrenadorById(string id)
        {
            try
            {
                MongoDBcontext _dbContext = new MongoDBcontext();
                var collection = _dbContext.GetDatabase().GetCollection<Entrenadores>("entrenadores");
                return collection.AsQueryable().Where(x => x._id == id).Select(x => (Entrenadores)x).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitocracyFinal.Models
{
    [BsonIgnoreExtraElements(true)]
    public class EntrenamientosUsuarios
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string idUsuario { get; set; }
        public string idWorkout { get; set; }
    }
}
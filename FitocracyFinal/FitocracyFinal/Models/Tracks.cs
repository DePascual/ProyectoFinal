using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitocracyFinal.Models
{
    [BsonIgnoreExtraElements(true)]
    public class Tracks
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string Nombre { get; set; }
        public string Link { get; set; }
        public string Series { get; set; }
        public string Repeticiones { get; set; }
    }
}
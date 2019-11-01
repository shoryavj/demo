using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Assignment
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }

        public string ProblemStatement { get; set; }

        public string InputFormat { get; set; }

        public string OutputFormat { get; set; }

        public string Constraints { get; set; }

        public  string Tags { get; set; }
    }
}

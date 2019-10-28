using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace FacebookApi.Models
{
    public class User: MongoCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }
        
        [BsonElement("birthdate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Birthdate { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}

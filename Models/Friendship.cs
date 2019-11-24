using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FacebookApi.Models
{
    public class Friendship : MongoCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userAId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserAId { get; set; }

        [BsonElement("userBId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserBId { get; set; }
        
    }
}

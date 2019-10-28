using FacebookApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FacebookApi.Services
{
    public class LikeService : CollectionManager<Like>
    {
        private readonly IMongoCollection<Like> _collection;

        public LikeService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Like>(settings.LikesCollectionName);
        }
        
        override protected IMongoCollection<Like> getCollection() {
            return _collection;
        }
    }
}
using FacebookApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FacebookApi.Services
{
    public class FriendshipService : CollectionManager<Friendship>
    {
        private readonly IMongoCollection<Friendship> _collection;

        public FriendshipService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Friendship>(settings.FriendshipsCollectionName);
        }
        
        override protected IMongoCollection<Friendship> getCollection() {
            return _collection;
        }
    }
}

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

        public List<string> GetWithPostId(string id) {
            var allLikes = Get();
            var likes =
                from like in allLikes
                where like.PostId == id
                select like.Id;
            return likes.ToList();
        }

        public bool IsDuplicate(Like like) {
            var allLikes = Get();
            var duplicates =
                from _like in allLikes
                where _like.PostId == like.PostId && _like.UserId == like.UserId
                select _like.Id;
            return duplicates.Any();
        }
    }
}

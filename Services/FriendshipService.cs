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

        public List<string> GetFriendsOf(string userId) {
            var allFriendships = Get();
            var friendIds =
                from friendship in allFriendships
                where userId == friendship.UserAId || userId == friendship.UserBId
                select friendship.UserAId == userId ? friendship.UserBId : friendship.UserAId;
            return friendIds.ToList();
        }

        public bool IsDuplicate(Friendship friendship) {
            if(GetFriendsOf(friendship.UserAId).Contains(friendship.UserBId)) {
                return true;
            }
            return false;
        }
    }
}

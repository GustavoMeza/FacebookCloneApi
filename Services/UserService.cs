using FacebookApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FacebookApi.Services
{
    public class UserService : CollectionManager<User>
    {
        private readonly IMongoCollection<User> _collection; 

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<User>(settings.UsersCollectionName);
        }

        override protected IMongoCollection<User> getCollection() {
            return _collection;
        }

        public string IsRegistered(User candidate) {
            var allUsers = Get();
            var userIds =
                from user in allUsers
                where user.Email == candidate.Email && user.Password == candidate.Password
                select user.Id;
            return userIds.FirstOrDefault();
        }
    }
}

using FacebookApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FacebookApi.Services
{
    public class PostService : CollectionManager<Post>
    {
        private readonly IMongoCollection<Post> _collection;

        public PostService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Post>(settings.PostsCollectionName);
        }

        override protected IMongoCollection<Post> getCollection() {
            return _collection;
        }

        public List<string> GetFromAuthors(List<string> userIds) {
            var allPosts = Get();
            var postIds =
                from post in allPosts
                where userIds.Contains(post.UserId)
                select post.Id;
            return postIds.ToList();
        }
    }
}

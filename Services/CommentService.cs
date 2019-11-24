using FacebookApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FacebookApi.Services
{
    public class CommentService : CollectionManager<Comment>
    {
        private protected readonly IMongoCollection<Comment> _collection;
        
        public CommentService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Comment>(settings.CommentsCollectionName);
        }

        override protected IMongoCollection<Comment> getCollection() {
            return _collection;
        }

        public List<string> GetWithPostId(string id) {
            var allComments = Get();
            var comments =
                from comment in allComments
                where comment.PostId == id
                select comment.Id;
            return comments.ToList();
        }
    }
}

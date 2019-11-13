using FacebookApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FacebookApi.Services
{
    public abstract class CollectionManager<T> where T : MongoCollection
    {
        abstract protected IMongoCollection<T> getCollection();
        
        public List<T> Get() =>
            getCollection().Find(document => true).ToList();

        public T Get(string id) =>
            getCollection().Find<T>(document => document.Id == id).FirstOrDefault();

        public T Create(T document)
        {
            getCollection().InsertOne(document);
            return document;
        }

        public void Update(string id, T documentIn) =>
            getCollection().ReplaceOne(document => document.Id == id, documentIn);

        public void Remove(T documentIn) =>
            getCollection().DeleteOne(document => document.Id == documentIn.Id);

        public void Remove(string id) => 
            getCollection().DeleteOne(document => document.Id == id);
    }
}

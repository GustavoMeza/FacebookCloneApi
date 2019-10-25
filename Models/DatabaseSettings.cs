namespace FacebookApi.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string FriendshipsCollectionName { get; set; }
        public string PostsCollectionName { get; set; }
        public string CommentsCollectionName { get; set; }
        public string LikesCollectionName { get; set; }
        
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string FriendshipsCollectionName { get; set; }
        string PostsCollectionName { get; set; }
        string CommentsCollectionName { get; set; }
        string LikesCollectionName { get; set; }
        
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

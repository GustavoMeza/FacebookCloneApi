namespace FacebookApi.Models
{
    public class SecretSettings : ISecretSettings
    {
        public string Secret { get; set; }
    }

    public interface ISecretSettings
    {
        string Secret { get; set; }
    }
}

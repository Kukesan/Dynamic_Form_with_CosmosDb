using Newtonsoft.Json;

namespace Dynamic_Form_with_CosmosDb.Models
{
    public class UserFillForm
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title {  get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        private Dictionary<string, object> metadata = new Dictionary<string, object>();
      
        public void AddMetadata(string key, object value)
        {
            metadata[key] = value;
        }

        public object GetMetadata(string key)
        {
            if (metadata.ContainsKey(key))
            {
                return metadata[key];
            }
            else
            {
                return null;
            }
        }
    }
}

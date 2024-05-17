using Newtonsoft.Json;

namespace Dynamic_Form_with_CosmosDb.Models
{
    public class UserFillForm
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

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

        public Dictionary<string, object> GetAllMetadata()
        {
            return metadata;
        }
    }
}

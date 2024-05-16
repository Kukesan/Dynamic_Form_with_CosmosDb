using Newtonsoft.Json;

namespace Dynamic_Form_with_CosmosDb.Models
{
    public class EmployeeCreatedForm
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public RowDetail Phone { get; set; }

        [JsonProperty(PropertyName = "nationality")]
        public RowDetail Nationality { get; set; }

        [JsonProperty(PropertyName = "currentResidence")]
        public RowDetail CurrentResidence { get; set; }

        [JsonProperty(PropertyName = "idNumber")]
        public RowDetail IdNumber { get; set; }

        [JsonProperty(PropertyName = "dateOfBirth")]
        public RowDetail DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public RowDetail Gender { get; set; }
    }

    public class RowDetail
    {
        [JsonProperty(PropertyName = "isInternal")]
        public bool IsInternal { get; set; } = false;

        [JsonProperty(PropertyName = "isHide")]
        public bool IsHide { get; set; } = false;
    }
}

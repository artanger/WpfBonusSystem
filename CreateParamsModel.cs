using Newtonsoft.Json;

namespace ClientBonusSystem.Models
{
    public class CreateParamsModel
    {
        [JsonProperty(PropertyName = "phone")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "expdate")]
        public string ExpirationDate { get; set; }

    }
}

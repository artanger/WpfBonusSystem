using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBonusSystem.Models
{
    public class AddParamsModel
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty (PropertyName ="lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string PhoneNumber { get; set; }
    }
}

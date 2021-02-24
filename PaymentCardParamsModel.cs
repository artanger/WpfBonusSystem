using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBonusSystem.Models
{
    public class PaymentCardParamsModel
    {
        [JsonProperty(PropertyName = "number")]
        public string CardNumber { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string  NewValue { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

    }
}

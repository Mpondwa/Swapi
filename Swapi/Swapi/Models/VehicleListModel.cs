using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swapi.Models
{
    public class VehicleListModel
    {
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<VehicleModel> Results { get; set; }
    }
}

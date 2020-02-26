using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swapi.Models
{
    public class PeopleModel
    {
        [JsonProperty("results")]
        public List<PersonModel> PeopleList { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string NextPage { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }
    }
}

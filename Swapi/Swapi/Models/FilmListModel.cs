using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swapi.Models
{
    public class FilmListModel
    {
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("next")]
        public object Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<FilmModel> Results { get; set; }
    }
}

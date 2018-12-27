using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesFromImdb
{
    public class Top100IMDb
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("id")]
        public string IMDbId { get; set; }


    }
}

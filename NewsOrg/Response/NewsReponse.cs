using System;
using System.Collections.Generic;
using NewsOrg.Models;
using Newtonsoft.Json;

namespace NewsOrg.Response
{
    public class NewsReponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }

        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }
    }
}

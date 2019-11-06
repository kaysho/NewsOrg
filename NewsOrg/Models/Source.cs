using System;
using Newtonsoft.Json;
using Realms;

namespace NewsOrg.Models
{
    public class Source
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

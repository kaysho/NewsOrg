using System;
using Newtonsoft.Json;
using SQLite;

namespace NewsOrg.Models
{
    public class Article
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [SQLite.Ignore]
        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urlToImage")]
        public string UrlToImage { get; set; }

        [JsonProperty("publishedAt")]
        public string PublishedAt { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        public int Saved { get; set; }
    }
}

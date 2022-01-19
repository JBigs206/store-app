using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace StoreWebApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        [JsonProperty("rating")]
        public RatingModel Rating { get; set; }
    }

    public class RatingModel
    {
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
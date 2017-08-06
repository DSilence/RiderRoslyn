using System;
using Newtonsoft.Json;

namespace RoslynResharper.Models
{
    public class ProjectProjectReference
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
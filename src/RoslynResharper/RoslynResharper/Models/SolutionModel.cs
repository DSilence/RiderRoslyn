using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RoslynResharper.Models
{
    public class SolutionModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("projects")]
        public List<ProjectModel> Projects { get; set; }
        
        [JsonProperty("filePath")]
        public string FilePath { get; set; }
    }
}
using Newtonsoft.Json;

namespace RoslynResharper.Models
{
    public class ProjectAssemblyReference
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("libraryPath")]
        public string LibraryPath { get; set; }
    }
}
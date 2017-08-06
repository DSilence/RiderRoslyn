using Newtonsoft.Json;

namespace RoslynResharper.Models
{
    public class DocumentModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
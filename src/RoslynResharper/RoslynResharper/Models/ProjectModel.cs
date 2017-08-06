using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RoslynResharper.Models
{
    public class ProjectModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("filePath")]
        public string FilePath { get; set; }

        [JsonProperty("assemblyName")]
        public string AssemblyName { get; set; }
        
        [JsonProperty("projectReferences")]
        public List<ProjectAssemblyReference> ProjectAssemblyReferences { get; set; }
        
        [JsonProperty("projectToProjectReferences")]
        public List<ProjectProjectReference> ProjectToProjectReferences { get; set; }
        
        [JsonProperty("projectReferences")]
        public List<ProjectAssemblyReference> AnalyzerReferences { get; set; }
        
        [JsonProperty("documents")]
        public List<DocumentModel> Documents { get; set; }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host.Mef;
using RoslynResharper.Models;

namespace Roslyn.Analysis.Host
{
    public class WorkspaceService
    {
        private readonly AdhocWorkspace _adhocWorkspace = new AdhocWorkspace(MefHostServices.DefaultHost);
        
        public async Task Init(SolutionModel solutionModel)
        {
            IList<ProjectInfo> projectInfos = new List<ProjectInfo>(solutionModel.Projects.Count);
            foreach (var projectModel in solutionModel.Projects)
            {
                var projectId = ProjectId.CreateFromSerialized(projectModel.Id);
                var documentInfos = new List<DocumentInfo>(projectModel.Documents.Count);
                var projectReferences = new List<ProjectReference>(projectModel.ProjectToProjectReferences.Count);
                var metadataReferences = new List<MetadataReference>(projectModel.ProjectAssemblyReferences.Count);

                foreach (var documentModel in projectModel.Documents)
                {
                    documentInfos.Add(DocumentInfo.Create(DocumentId.CreateNewId(projectId), documentModel.Name, null, SourceCodeKind.Regular, null, documentModel.Path));
                }
                foreach (var projectReference in projectModel.ProjectToProjectReferences)
                {
                    projectReferences.Add(new ProjectReference(ProjectId.CreateFromSerialized(projectReference.Id)));
                }
                foreach (var projectAssemblyReference in projectModel.ProjectAssemblyReferences)
                {
                    metadataReferences.Add(MetadataReference.CreateFromFile(projectAssemblyReference.LibraryPath));
                }

                var projectInfo = ProjectInfo.Create(projectId, VersionStamp.Default, projectModel.Name,
                    projectModel.AssemblyName, LanguageNames.CSharp, projectModel.FilePath, null, null, null,
                    documentInfos, projectReferences, metadataReferences, null);
                projectInfos.Add(projectInfo);
            }
            _adhocWorkspace.AddSolution(SolutionInfo.Create(SolutionId.CreateFromSerialized(solutionModel.Id),
                VersionStamp.Default, solutionModel.FilePath, projectInfos));
        }
    }
}
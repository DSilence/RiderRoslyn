using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.Impl;
using JetBrains.Util;
using RoslynResharper.Models;

namespace RoslynResharper.Component
{
    [SolutionComponent]
    public class RoslynComponent : IDisposable
    {
        private readonly ISolution _solution;

        public RoslynComponent(ISolution solution)
        {
            _solution = solution;
            ParseSolution(_solution);
        }

        private SolutionModel ParseSolution(ISolution solution)
        {
            var projects = solution.GetAllProjects();
            
            var resultSolution = new SolutionModel
            {
                FilePath = solution.SolutionFile?.Location.FullPath,
                Id = Guid.NewGuid(),
                Name = solution.Name,
                Projects = new List<ProjectModel>(projects.Count)
            };
            
            foreach (var project in projects)
            {
                var targetFrameworkId = project.GetCurrentTargetFrameworkId();
                var moduleReferences = project.GetModuleReferences(targetFrameworkId).ToArray();

                var projectFiles = project.GetAllProjectFiles().ToArray();

                var resultProject = new ProjectModel
                {
                    FilePath = project.ProjectFileLocation.FullPath,
                    Id = project.Guid,
                    Name = project.Name,
                    AssemblyName = project.GetOutputAssemblyName(targetFrameworkId),
                    Documents = new List<DocumentModel>(projectFiles.Length),
                    ProjectAssemblyReferences = new List<ProjectAssemblyReference>(),
                    ProjectToProjectReferences = new List<ProjectProjectReference>(),
                    AnalyzerReferences = new List<ProjectAssemblyReference>()
                };
                
                resultSolution.Projects.Add(resultProject);
                
                foreach (var packageReference in moduleReferences)
                {
                    var projectToAssemblyReference = packageReference as IProjectToAssemblyReference;
                    if (projectToAssemblyReference != null)
                    {
                        resultProject.ProjectAssemblyReferences.Add(new ProjectAssemblyReference
                        {
                            Name = projectToAssemblyReference.Name,
                            LibraryPath = projectToAssemblyReference.ReferenceTarget.AssemblyFileName
                        });
                    }
                    else
                    {
                        var projectToProjectReference = packageReference as GuidProjectReference;
                        if (projectToProjectReference != null)
                        {
                            resultProject.ProjectToProjectReferences.Add(new ProjectProjectReference
                            {
                                Name = projectToProjectReference.Name,
                                Id = projectToProjectReference.ReferencedProjectGuid
                            });
                        }
                    }
                }

                foreach (var projectFile in projectFiles)
                {
                    resultProject.Documents.Add(new DocumentModel
                    {
                        Name = projectFile.Name,
                        Path = projectFile.Location.FullPath
                    });
                }
            }
            
            return resultSolution;
        }

        public void Dispose()
        {
        }
    }
}
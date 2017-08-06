using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace Resharper.Host.Roslyn.Handler
{
    public class RoslynHandler : IDisposable
    {
        private readonly string _solutionPath;
        private readonly MSBuildWorkspace _workspace;
        private Solution _solution;
        private bool _initialized = false;
        private readonly SemaphoreSlim _initSemaphoreSlim = new SemaphoreSlim(1);
        
        public RoslynHandler(string solutionPath)
        {
            _workspace = MSBuildWorkspace.Create();
            _workspace.WorkspaceFailed += WorkspaceOnWorkspaceFailed;
            _solutionPath = solutionPath;
        }

        private void WorkspaceOnWorkspaceFailed(object sender, WorkspaceDiagnosticEventArgs workspaceDiagnosticEventArgs)
        {
            int t = 2;
        }

        public async Task Initialize()
        {
            if (!_initialized)
            {
                await _initSemaphoreSlim.WaitAsync();
                try
                {
                    {
                        if (!_initialized)
                        {
                            _solution = await _workspace.OpenSolutionAsync(_solutionPath);
                            _initialized = true;
                        }
                    }
                }
                finally
                {
                    _initSemaphoreSlim.Release();
                }
            }
        }

        public async Task CheckFile(string filePath)
        {
            foreach (var projectId in _solution.ProjectIds)
            {
                var project = _solution.GetProject(projectId);
                foreach (var projectDocumentId in project.DocumentIds)
                {
                    var document = project.GetDocument(projectDocumentId);
                }
            }            
        }

        public void Dispose()
        {
            _workspace.WorkspaceFailed -= WorkspaceOnWorkspaceFailed;
            _workspace?.Dispose();
        }
    }
}
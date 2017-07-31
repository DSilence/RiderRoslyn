using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.MSBuild;
using Roslyn.Analyzer.Host.HostService;

namespace Roslyn.Analyzer.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var workspace = new AdhocWorkspace(MefHostServices.DefaultHost);

            workspace.AddSolution(SolutionInfo.Create())
            var solution =
                workspace.OpenSolutionAsync(
                    @"C:\Projects\Work\usga.rm.app\src\server\Usga.ResourceManager\Usga.ResourceManager.sln").Result;
            foreach (var project in solution.Projects)
            {
                var analyizer = project.AnalyzerReferences;
                var compilation = project.GetCompilationAsync().Result;
            }
            Console.WriteLine("Hello World!");
        }
    }
}

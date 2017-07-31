using System;
using System.Linq;
using Microsoft.CodeAnalysis.MSBuild;

namespace Roslyn.Analyzer.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var workspace = MSBuildWorkspace.Create();

            var solution =
                workspace.OpenSolutionAsync(
                    @"");
            var project = solution.Result.Projects.First();
            var compilation = project.GetCompilationAsync().Result;
            Console.WriteLine("Hello World!");
        }
    }
}

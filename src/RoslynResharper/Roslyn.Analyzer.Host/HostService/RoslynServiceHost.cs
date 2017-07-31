using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host;

namespace Roslyn.Analyzer.Host.HostService
{
    public class RoslynServiceHost : HostServices
    {
        protected override HostWorkspaceServices CreateWorkspaceServices(Workspace workspace)
        {
            throw new NotImplementedException();
        }
    }
}

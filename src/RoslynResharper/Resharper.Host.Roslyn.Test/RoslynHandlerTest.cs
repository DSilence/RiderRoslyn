using System.Threading.Tasks;
using Resharper.Host.Roslyn.Handler;
using Xunit;

namespace Resharper.Host.Roslyn.Test
{
    public class RoslynHandlerTest
    {
        [Fact]
        public async Task ShouldCheckFile()
        {
            var handler = new RoslynHandler(@"C:\Projects\Work\usga.rm.app\src\server\Usga.ResourceManager\Usga.ResourceManager.sln");
            var file =
                @"C:\Projects\Work\usga.rm.app\src\server\Usga.ResourceManager\WebApps\Usga.Rma.WebApps.ResourceManager\Startup.cs";
            await handler.Initialize();
            await handler.CheckFile(file);
        }
    }
}
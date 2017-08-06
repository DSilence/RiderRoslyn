using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Resharper.Host.Roslyn.Handler;

namespace Resharper.Host.Roslyn
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            
            var handler = new RoslynHandler(@"C:\Projects\Work\usga.rm.app\src\server\Usga.ResourceManager\Usga.ResourceManager.sln");
            var file =
                @"C:\Projects\Work\usga.rm.app\src\server\Usga.ResourceManager\WebApps\Usga.Rma.WebApps.ResourceManager\Startup.cs";
            handler.Initialize().GetAwaiter().GetResult();
            handler.CheckFile(file).GetAwaiter().GetResult();

            host.Run();
        }
    }
}
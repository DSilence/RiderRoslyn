using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;

namespace RoslynResharper
{
    [ZoneMarker]
    public class ZoneMarker : IRequire<ILanguageCSharpZone>, IRequire<DaemonEngineZone>
    {
    }
}

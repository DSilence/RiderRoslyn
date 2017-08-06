using System.Collections.Generic;
using JetBrains.Application.Settings;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi;
using RoslynResharper.Component;

namespace RoslynResharper.Service
{
    [DaemonStage]
    public class RoslynDaemonStage : IDaemonStage 
    {
        private readonly RoslynComponent _roslynComponent;

        public RoslynDaemonStage(RoslynComponent roslynComponent)
        {
            _roslynComponent = roslynComponent;
        }

        public IEnumerable<IDaemonStageProcess> CreateProcess(IDaemonProcess process, IContextBoundSettingsStore settings, DaemonProcessKind processKind)
        {
            return new IDaemonStageProcess[]
            {
                new RoslynDaemonStageProcess(process)
            };
        }

        public ErrorStripeRequest NeedsErrorStripe(IPsiSourceFile sourceFile, IContextBoundSettingsStore settingsStore)
        {
            return ErrorStripeRequest.STRIPE_AND_ERRORS;
        }
    }
}

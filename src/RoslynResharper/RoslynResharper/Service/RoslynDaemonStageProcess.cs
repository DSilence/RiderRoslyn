using System;
using JetBrains.ReSharper.Feature.Services.Daemon;

namespace RoslynResharper.Service
{
    public class RoslynDaemonStageProcess : IDaemonStageProcess
    {
        public RoslynDaemonStageProcess(IDaemonProcess daemonProcess)
        {
            DaemonProcess = daemonProcess;
        }

        public void Execute(Action<DaemonStageResult> committer)
        {
            //This will do the actual analysis
        }

        public IDaemonProcess DaemonProcess { get; }
    }
}
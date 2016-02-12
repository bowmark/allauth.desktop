using System;
using System.Diagnostics;
using System.IO;
using AllAuth.Lib;

namespace AllAuth.Desktop.App
{
    internal class AutoUpdater
    {
        private readonly bool _enabled;

        public AutoUpdater()
        {
            if (Program.AppEnvDebug)
                return;

            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                return;

            if (!Config.AppAutoUpdate)
                return;

            _enabled = true;
        }

        public void Run()
        {
            if (!_enabled)
                return;

            /*
             * OK, so this is a botch job to temporarily get auto-updates working on Windows.
             * The UpdateManager within Squirrel kept crashing the entire app (on CheckUpdates), so we're having to 
             * execute the Update.exe ourselves until a proper solution is found.
             */

            var updateExeFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Update.exe");
            if (!File.Exists(updateExeFile))
            {
                Logger.Info("Could not find Update.exe. This is not an managed install program.");
                return;
            }

            var cmd = new Process
            {
                StartInfo =
                {
                    FileName = updateExeFile,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = "--update " + Config.AppUpdatesReleaseUrl
                }
            };
            cmd.Start();
        }
    }
}

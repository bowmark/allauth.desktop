using System;
using System.Diagnostics;
using System.Net;
using AllAuth.Desktop.App;
using AllAuth.Lib;

namespace AllAuth.Desktop
{
    internal static class Program
    {
#if DEBUG
        public static readonly bool AppEnvDebug = true;
#else
        public static readonly bool AppEnvDebug = false;
#endif

        public static bool Restart { get; set; }

        private static Controller _controller;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static int Main(string[] args)
        {
            if (AppEnvDebug)
            {
                Logger.ConsoleOut = true;
                Logger.LogOutLevel = TraceLevel.Verbose;

                // Allow self-signed SSL certs in debug mode
                ServicePointManager.ServerCertificateValidationCallback +=
                        (sender, certificate, chain, sslPolicyErrors) => true;
            }

            try
            {
                var logPath = Config.GetLogPath();
                if (!string.IsNullOrEmpty(logPath))
                    Logger.FileOut = logPath;

                if (!Config.LoadConfig())
                    return 1;

                if (Config.AppLogLevel == "Verbose")
                    Logger.LogOutLevel = TraceLevel.Verbose;

                var autoUpdate = new AutoUpdater();
                autoUpdate.Run();

                Model.Init();

                do
                {
                    Logger.Verbose("Starting application controller");
                    Restart = false;
                    _controller = new Controller();
                    _controller.Run();
                    Logger.Verbose("Stopping application controller");
                    _controller.Stop();
                } while (Restart);
            }
            catch (Exception e)
            {
                if (AppEnvDebug)
                    throw new Exception("Uncaught error", e);

                Logger.Error("There was an unexpected fatal error. " + e.Message);
                return 1;
            }

            return 0;
        }

        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }
    }
}

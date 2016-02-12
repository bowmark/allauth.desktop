using System.Net;
using System.Threading;

namespace AllAuth.Mobile.TestDevice
{
    public static class Program
    {
#if DEBUG
        public static bool AppEnvDebug = true;
#else
        public static bool AppEnvDebug = false;
#endif

        private static Controller _controller;
        public static readonly AutoResetEvent ProgramStopWait = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            /*var argsList = args.ToList();
            if (argsList.Contains("--seed"))
            {
                if (!AppEnvDebug)
                    throw new Exception("Running DB seeds is a debug only feature");

                var seedToRun = argsList.ElementAt(argsList.IndexOf("--seed") + 1);
                //AppDatabase.SeedsRunner.RunSeed(seedToRun);
                //AccountDatabase.SeedsRunner.RunSeed(seedToRun);
                return;
            }*/
            
            if (AppEnvDebug)
            {
                // Allow self-signed SSL certs in debug mode
                ServicePointManager.ServerCertificateValidationCallback +=
                        (sender, certificate, chain, sslPolicyErrors) => true;
            }

            AppModel.Init();
            
            _controller = new Controller();
            _controller.Start();
        }
    }
}

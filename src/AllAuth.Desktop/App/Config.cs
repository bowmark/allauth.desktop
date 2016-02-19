using System;
using System.IO;
using AllAuth.Lib;
using IniParser.Model;

namespace AllAuth.Desktop.App
{
    internal static class Config
    {
        public const int TrialLengthDays = 14;

        public static string AppLogLevel => _configData["Application"]["LogLevel"];
        public static bool AppAutoUpdate => _configData["Application"]["AutoUpdate"] == "true";
        public static string AppUpdatesReleaseUrl => _configData["Application"]["UpdatesReleaseUrl"];
        public static string AppAccountManagementUrl => _configData["Application"]["AccountManagementUrl"];
        
        public static string ManagementLabel = "AllAuth";
        public static bool   ManagementHttps => _configData["Management"]["Https"] == "true";
        public static string ManagementHost => _configData["Management"]["Host"];
        public static int    ManagementPort => int.Parse(_configData["Management"]["Port"]);
        public static int    ManagementApiVersion => int.Parse(_configData["Management"]["ApiVersion"]);

        private static IniData _configData;

        public static bool LoadConfig(string configFilePath = null)
        {
            if (string.IsNullOrEmpty(configFilePath))
            {
                configFilePath = GetConfigPath();
            }
            
            if (!string.IsNullOrEmpty(configFilePath))
            {
                try
                {
                    var loader = new ConfigLoader(configFilePath);
                    _configData = loader.ConfigData;
                }
                catch (Exception)
                {
                    Logger.Error("Could not find a configuration file. " +
                                 "Include one in the application directory or specify one with --config.");
                    return false;
                }
            }
            else
            {
                _configData = new IniData();
            }

            // Defaults. AddSection/AddKey take no action if they already exist.
            _configData.Sections.AddSection("Application");
            _configData["Application"].AddKey("LogLevel", "Info");
            _configData["Application"].AddKey("AutoUpdate", "true");
            _configData["Application"].AddKey(
                "UpdatesReleaseUrl", "https://downloads.allauthapp.com/allauth-desktop/win-update-pkgs");
            _configData["Application"].AddKey(
                "AccountManagementUrl", "https://account.allauthapp.com");

            _configData.Sections.AddSection("Management");
            _configData["Management"].AddKey("Https", "true");
            _configData["Management"].AddKey("Host", "management.api.allauthapp.com");
            _configData["Management"].AddKey("Port", "443");
            _configData["Management"].AddKey("ApiVersion", "1");

            //if (!Program.AppEnvDebug)
            //{
            //    // Immutable for release
            //    _configData["Management"]["Https"] = "true";
            //    _configData["Management"]["Host"] = "management.api.allauthapp.com";
            //    _configData["Management"]["Port"] = "443";
            //    _configData["Management"]["ApiVersion"] = "1";
            //}

            return true;
        }

        public static string GetLogPath()
        {
            if (Program.AppEnvDebug)
                return "_app.log";

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(appDataFolder, "AllAuth", "app.log");
            }

            return null;
        }

        private static string GetConfigPath()
        {
            var checkFolder = Path.Combine(Directory.GetCurrentDirectory(), "config.ini");
            Logger.Info("Checking for config.ini at [" + checkFolder + "]");
            if (File.Exists(checkFolder))
            {
                Logger.Info("Found config.ini file in app directory ["+ checkFolder + "]");
                return checkFolder;
            }

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                checkFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                checkFolder = Path.Combine(checkFolder, "AllAuth", "config.ini");
                Logger.Info("Checking for config.ini at [" + checkFolder + "]");
                if (File.Exists(checkFolder))
                {
                    Logger.Info("Found config.ini file in app directory [" + checkFolder + "]");
                    return checkFolder;
                }
            }

            Logger.Info("No config.ini found.");

            return null;
        }

        private static string GetDatabaseBasePath()
        {
            if (Program.AppEnvDebug)
                return "";
            
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                appDataFolder = Path.Combine(appDataFolder, "AllAuth");

                Directory.CreateDirectory(appDataFolder);

                return appDataFolder;
            }

            var homeDataFolder = Environment.GetEnvironmentVariable("HOME");

            if (homeDataFolder == null)
                throw new Exception("No HOME environment variable to determine where to store user data");

            homeDataFolder = Path.Combine(homeDataFolder, ".allauth");
            Directory.CreateDirectory(homeDataFolder);

            return homeDataFolder;
        }

        public static string GetDatabasePath()
        {
            if (Program.AppEnvDebug)
                return "_userdata.db3";

            return Path.Combine(GetDatabaseBasePath(), "userdata.db3");
        }

        public static string GetDatabaseKeyPath()
        {
            if (Program.AppEnvDebug)
                return "_userdata.key";

            return Path.Combine(GetDatabaseBasePath(), "userdata.key");
        }
    }
}

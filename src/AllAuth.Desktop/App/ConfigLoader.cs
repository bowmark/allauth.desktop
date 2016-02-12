using System;
using System.IO;
using AllAuth.Lib;
using IniParser.Exceptions;
using IniParser.Model;

namespace AllAuth.Desktop.App
{
    public class ConfigLoader
    {
        public readonly IniData ConfigData;

        public ConfigLoader(string configFilePath = null)
        {
            if (string.IsNullOrEmpty(configFilePath))
            {
                configFilePath = AppDomain.CurrentDomain.BaseDirectory + "config.ini";
                if (!File.Exists(configFilePath))
                {
                    throw new Exception("Could not find configuration file");
                }
            }

            Logger.Info("Loading configuration from: " + configFilePath);

            try
            {
                var parser = new IniParser.FileIniDataParser();
                ConfigData = parser.ReadFile(configFilePath);
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Could not find configuration file at: " + configFilePath);
            }
            catch (ParsingException e)
            {
                throw new Exception("Unable to parse configuration file [" + configFilePath + "]: " + e.Message);
            }

            foreach (var section in ConfigData.Sections)
                foreach (var item in section.Keys)
                {
                    item.Value = item.Value.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
                    item.Value = item.Value.Replace("{AppDataDir}", AppDomain.CurrentDomain.BaseDirectory);
                }
        }
    }
}

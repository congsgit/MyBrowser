using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MyBrowser.Data;

using Newtonsoft.Json;

namespace MyBrowser
{
    class Config
    {
        private const string DEFAULT_HOME_URL = "https://www.hw.ac.uk/";

        private string filePath = "./config.json";

        private ConfigData configData;

        private static Config instance = new Config();

        private Config() { }

        public static Config getInstance()
        {
            return instance;
        }

        public void load()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    configData = new ConfigData();
                    configData.homeUrl = DEFAULT_HOME_URL;
                    string str = JsonConvert.SerializeObject(configData, Formatting.Indented);
                    File.WriteAllText(filePath, str);
                }
                else
                {
                    string jsonContent = File.ReadAllText(filePath);
                    configData = JsonConvert.DeserializeObject<ConfigData>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"load config error:{ex.Message}");
            }
        }

        public string getHomeUrl()
        {
            return configData.homeUrl;
        }

        public void saveHomeUrl(string homeUrl)
        {
            configData.homeUrl = homeUrl;
            string str = JsonConvert.SerializeObject(configData, Formatting.Indented);
            File.WriteAllText(filePath, str);
        }
    }
}

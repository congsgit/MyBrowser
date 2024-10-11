using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using MyBrowser.Data;


namespace MyBrowser
{
    class HistoryForSave
    {
        private string filePath = "./history.json";

        private static HistoryForSave historyForSave = new HistoryForSave();

        public List<HistoryRowData> historyRowList { get; set; }

        private HistoryForSave() {
            load();
        }

        public static HistoryForSave getInstance()
        {
            return historyForSave;
        }

        
        public void save(DateTime dateTime, string title, string url)
        {
            removeDumplicated(url);
            historyRowList.Add(new HistoryRowData(dateTime, title, url));

            string jsonArray = JsonConvert.SerializeObject(historyRowList, Formatting.Indented);
            try
            {
                File.WriteAllText(filePath, jsonArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //need to be optimized if the history records is large
        private void removeDumplicated(string url)
        {
            for(int i=0; i<historyRowList.Count; i++)
            {
                HistoryRowData row = historyRowList[i];
                if (row.url.Equals(url))
                {
                    historyRowList.RemoveAt(i);
                    break;
                }
            }
        }

        public void load()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    //write empty json array
                    File.WriteAllText(filePath, "[]");
                    historyRowList = new List<HistoryRowData>();
                } 
                else
                {
                    string jsonContent = File.ReadAllText(filePath);
                    historyRowList = JsonConvert.DeserializeObject<List<HistoryRowData>>(jsonContent);
                }
            } catch(Exception ex)
            {
                Console.WriteLine($"load history error:{ex.Message}");
            }
        }
    }
}

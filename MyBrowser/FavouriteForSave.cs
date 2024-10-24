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
    class FavouriteForSave
    {
        private string filePath = "./favourite.json";

        private static FavouriteForSave favouriteForSave = new FavouriteForSave();

        private MainForm form1;

        public List<FavouriteRowData> favouriteRowList { get; set; }

        private FavouriteForSave()
        {
        }

        public static FavouriteForSave getInstance()
        {
            return favouriteForSave;
        }

        public void init(MainForm form1)
        {
            this.form1 = form1;
        }

        public void save(string name, string url)
        {
            removeDumplicated(url);
            favouriteRowList.Add(new FavouriteRowData(name, url));
            saveToFile();
            form1.refreshFavouriteListView();
        }

        public void remove(string url)
        {
            removeDumplicated(url);
            saveToFile();
            form1.refreshFavouriteListView();
        }
        

        private void removeDumplicated(string url)
        {
            for (int i = 0; i < favouriteRowList.Count; i++)
            {
                FavouriteRowData row = favouriteRowList[i];
                if (row.url.Equals(url))
                {
                    favouriteRowList.RemoveAt(i);
                    break;
                }
            }
        }

        private void saveToFile()
        {
            string jsonArray = JsonConvert.SerializeObject(favouriteRowList, Formatting.Indented);
            try
            {
                File.WriteAllText(filePath, jsonArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
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
                    favouriteRowList = new List<FavouriteRowData>();
                    Console.WriteLine("Favourite list initialed successfully!");
                }
                else
                {
                    string jsonContent = File.ReadAllText(filePath);
                    favouriteRowList = JsonConvert.DeserializeObject<List<FavouriteRowData>>(jsonContent);
                    Console.WriteLine("Favourite list loaded successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"load favourite error:{ex.Message}");
            }

            
            form1.refreshFavouriteListView();
        }
    }
}

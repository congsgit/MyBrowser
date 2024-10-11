using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBrowser.Data
{
    class HistoryRowData
    {
        public DateTime dateTime;
        public string title { get; set; }
        public string url { get; set; }

        public HistoryRowData(DateTime dateTime, string title, string url)
        {
            this.dateTime = dateTime;
            this.title = title;
            this.url = url;
        }
    }
}

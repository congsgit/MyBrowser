using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBrowser.Msg
{
    public class UrlFetchedMsg
    {
        public string html { get; set; }
        public string title { get; set; }
        public bool hasPrev { get; set; }
        public bool hasNext { get; set; }
        public string codeAndStatus { get; set; }

        public string url { get; set; }
    }
}

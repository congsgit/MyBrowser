using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBrowser
{
    class Node
    {
        public string url { get; set; }
        public string title { get; set; }
        public DateTime dateTime { get; set; }
        public Node prev { get; set; }
        public Node next { get; set; }

        public Node(string url, string title, DateTime dateTime)
        {
            this.url = url;
            this.title = title;
            this.dateTime = dateTime;
        }
    }
}

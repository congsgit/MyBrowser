using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBrowser
{
    
    class History
    {
        private static History history = new History();

        private Node curNode = new Node("http://www.google.com", "", DateTime.Now);

        private History()
        {

        }

        public static History getInstance()
        {
            return history;
        }

        public string getCurUrl()
        {
            return curNode.url;
        }
        public void newPage(string url)
        {
            Node node = new Node(url, "", DateTime.Now);

            node.prev = curNode;
            curNode.next = node;
            curNode = node;
        }

        public void movePrev()
        {
            if(hasPrev())
            {
                curNode = curNode.prev;
            }
        }

        public void moveNext()
        {
            if(hasNext())
            {
                curNode = curNode.next;
            }
        }

        public bool hasPrev()
        {
            return curNode.prev != null;
        }

        public bool hasNext()
        {
            return curNode.next != null;
        }


    }
}

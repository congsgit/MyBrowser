using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Text.RegularExpressions;
using MyBrowser.Msg;


namespace MyBrowser
{
    /**
     * Handles HTTP communication and navigation operations by maintaining a doubly linked list.
     * Notify the MainForm to refresh when the HTTP response is received.
     */
    class Engine
    {
        private static Engine engine = new Engine();

        // history for navigate
        private Node curNode;

        // can be modified to a list
        private UrlFetchedListener listener;

        private HttpClient client;

        private Engine()
        {
            client = new HttpClient();
        }

        public static Engine getInstance()
        {
            return engine;
        }

        public void setListener(UrlFetchedListener listener)
        {
            this.listener = listener;
        }

        public void load()
        {
            curNode = new Node(Config.getInstance().getHomeUrl(), "", DateTime.Now);
            fetchUrl(curNode.url);
        }
        

        //Trigger the event / send the msg to the listener
        private void trigger(UrlFetchedMsg msg)
        {
            listener.onUrlFetched(msg);
            Console.WriteLine("-------------trigger");
        }

        public string getCurUrl()
        {
            return curNode.url;
        }

        public string getCurTitle()
        {
            return curNode.title;
        }
        public void newPage(string url)
        {
            Node node = new Node(url, "", DateTime.Now);

            node.prev = curNode;
            curNode.next = node;
            curNode = node;

            fetchUrl(url);
        }

        public void movePrev()
        {
            if(hasPrev())
            {
                curNode = curNode.prev;
                fetchUrl(curNode.url);
            }
        }

        public void moveNext()
        {
            if(hasNext())
            {
                curNode = curNode.next;
                fetchUrl(curNode.url);
            }
        }

        private bool hasPrev()
        {
            return curNode.prev != null;
        }

        private bool hasNext()
        {
            return curNode.next != null;
        }

        private async void fetchUrl(string url)
        {
            try
            {
                UrlFetchedMsg msg = new UrlFetchedMsg();
                msg.url = url;
                msg.hasPrev = hasPrev();
                msg.hasNext = hasNext();

                HttpResponseMessage response = await client.GetAsync(url);
                int statusCodeInt = (int)response.StatusCode;
                msg.codeAndStatus = statusCodeInt + " " + response.StatusCode.ToString();
                Console.WriteLine(statusCodeInt + " " + response.StatusCode.ToString());

                //response.EnsureSuccessStatusCode(); // Throw if not a success code.

                string responseBody = await response.Content.ReadAsStringAsync();
                curNode.title = getTitle(responseBody);
                msg.title = curNode.title;
                msg.html=responseBody;

                //save history to file
                HistoryForSave.getInstance().save(DateTime.Now, msg.title, url);

                trigger(msg);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }

        private string getTitle(string response)
        {
            var match = Regex.Match(response, @"<title>\s*(.+?)\s*</title>", RegexOptions.IgnoreCase);
            return match.Success ? match.Groups[1].Value : "Cann't find title";
        }

        public async void renderDownloadUrls(string[] urls)
        {
            string result = "";
            foreach (string url in urls)
            {
                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, url);
                    HttpResponseMessage response = await client.SendAsync(request);

                    result += response.StatusCode;
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.Content.Headers.Contains("Content-Length"))
                        {
                            long fileSize = response.Content.Headers.ContentLength ?? 0;
                            result += " " + fileSize + " bytes";
                        }
                        else
                        {
                            result += " Can't find Content-Length in header";
                        }
                    }
                }
                catch (Exception ex)
                {
                    result += "Error when request:" + url;
                    Console.WriteLine($"Error: {ex.Message}");
                }

                result += " " + url + "\n";
            }

            UrlFetchedMsg msg = new UrlFetchedMsg();
            msg.html = result;
            msg.title = "bulk download";
            msg.hasPrev = hasPrev();
            msg.hasNext = hasNext();
            msg.codeAndStatus = "";
            msg.url = curNode.url;
            trigger(msg);

        }
    }
}

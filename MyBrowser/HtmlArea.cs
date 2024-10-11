using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MyBrowser.Data;

namespace MyBrowser
{
    class HtmlArea
    {
        private HttpClient client;
        private static HtmlArea htmlArea = new HtmlArea();
        private Form1 form1;

        private HtmlArea()
        {
            client = new HttpClient();
        }

        public void init(Form1 form1) {
            this.form1 = form1;
        }

        public static HtmlArea getHtmlArea()
        {
            return htmlArea;
        }

        public async void renderUrl(string url)
        {
            clear();

            try
            {
                
                HttpResponseMessage response = await client.GetAsync(url);
                int statusCodeInt = (int)response.StatusCode;
                form1.setStatus(statusCodeInt + " " + response.StatusCode.ToString());
                Console.WriteLine(statusCodeInt + " " + response.StatusCode.ToString());

                response.EnsureSuccessStatusCode(); // Throw if not a success code.

                string responseBody = await response.Content.ReadAsStringAsync();
                string title = getTitle(responseBody);
                form1.setHtmlRich(responseBody); 

                //save history to file
                HistoryForSave.getInstance().save(DateTime.Now, title, url);
                form1.refreshHistoryListBox();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }

        private void clear()
        {
            form1.setStatus("");
            form1.setHtmlRich("");
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
                    if(response.IsSuccessStatusCode)
                    {
                        if(response.Content.Headers.Contains("Content-Length"))
                        {
                            long fileSize = response.Content.Headers.ContentLength ?? 0;
                            result += " " + fileSize + " bytes";   
                        }
                        else
                        {
                            result += " Can't find Content-Length in header";
                        }
                    }
                } catch(Exception ex)
                {
                    result += "Error when request:"+url;
                    Console.WriteLine($"Error: {ex.Message}");
                }

                result += " " + url + "\n";
            }

            form1.setHtmlRich(result);
        }

        

    }
}

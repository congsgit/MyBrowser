using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Windows.Forms;

namespace MyBrowser
{
    class HtmlArea
    {
        private HttpClient client;
        private static HtmlArea htmlArea = new HtmlArea();
        private RichTextBox htmlRich;
        private Label statusLabel;

        private HtmlArea()
        {
            client = new HttpClient();
        }

        public void init(RichTextBox htmlRich, Label statusLabel) {
            this.htmlRich = htmlRich;
            this.statusLabel = statusLabel;
        }

        public static HtmlArea getHtmlArea()
        {
            return htmlArea;
        }

        public async void renderUrl(string url)
        {
            try
            {
                
                HttpResponseMessage response = await client.GetAsync(url);
                int statusCodeInt = (int)response.StatusCode;
                statusLabel.Text = statusCodeInt + " " + response.StatusCode.ToString();

                response.EnsureSuccessStatusCode(); // Throw if not a success code.

                //string responseBody = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(responseBody);

                string responseBody = await response.Content.ReadAsStringAsync();
                this.htmlRich.Text = responseBody;

                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }

    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using MyBrowser.Data;





namespace MyBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //init
            HtmlArea.getHtmlArea().init(this);
            refresh();
        }

        private void urlBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void prev_Click(object sender, EventArgs e)
        {
            History history = History.getInstance();
            history.movePrev();
            refresh();
        }

        private void next_Click(object sender, EventArgs e)
        {
            History history = History.getInstance();
            history.moveNext();
            refresh();
        }

        private void urlBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Check if the Enter key was pressed
            {
                e.SuppressKeyPress = true; // Prevent the ding sound
                                           // Your logic here (e.g., process the input)
                                           //MessageBox.Show("Enter pressed: " + urlBox.Text);

                //HtmlArea.getHtmlArea().renderUrl(urlBox.Text.Trim());
                History history = History.getInstance();
                history.newPage(urlBox.Text.Trim());
                refresh();
            }
        }

        public void refresh()
        {
            History history = History.getInstance();
     
            prevButton.Enabled = history.hasPrev() ? true : false;
            nextButton.Enabled = history.hasNext() ? true : false;

            urlBox.Text = history.getCurUrl();
            HtmlArea.getHtmlArea().renderUrl(history.getCurUrl());

        }

        public void setStatus(string str)
        {
            statusLabel.Text = str;
        }

        public void setHtmlRich(string str)
        {
            htmlRich.Text = str;
        }

        public void refreshHistoryListBox()
        {
            historyListBox.Items.Clear();

            List<HistoryRowData> list = HistoryForSave.getInstance().historyRowList;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                HistoryRowData row = list[i];
                historyListBox.Items.Add(row.dateTime + " " + row.title + " " + row.url);
            }
        }


        private void downloadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Text files (*.txt)|*.txt";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = dialog.FileName;

                try
                {
                    string[] allLines = File.ReadAllLines(filePath);
                    HtmlArea.getHtmlArea().renderDownloadUrls(allLines);
                    
                } catch(Exception ex)
                {
                    MessageBox.Show("Error when reading file:" + ex.Message);
                }
            }

        }

        private void historyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (historyListBox.SelectedItem != null)
            {
                string selectedLine = historyListBox.SelectedItem.ToString();
                MessageBox.Show("You selected: " + selectedLine);
            }
        }

        

        private void historyBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

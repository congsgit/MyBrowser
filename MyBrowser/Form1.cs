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


using MyBrowser.Msg;


namespace MyBrowser
{
    public partial class Form1 : Form, UrlFetchedListener
    {
        public Form1()
        {
            InitializeComponent();

            favouriteListView.MultiSelect = false;
            favouriteListView.FullRowSelect = true;
            favouriteListView.View = View.Details;
            favouriteListView.Columns.Add("name", 100);
            favouriteListView.Columns.Add("url", 300);

            historyListView.MultiSelect = false;
            historyListView.FullRowSelect = true;
            historyListView.View = View.Details;
            historyListView.Columns.Add("time", 120);
            historyListView.Columns.Add("title", 80);
            historyListView.Columns.Add("url", 150);

            //init
            FavouriteForSave.getInstance().init(this);
            History.getInstance().setListener(this);
        }

        private void shown(object sender, EventArgs e)
        {
            //Config need to be loaded first, other's might rely on it.
            Config.getInstance().load();
            FavouriteForSave.getInstance().load();
            History.getInstance().load();
        }

        //handle the custimized event / msg
        public void onUrlFetched(UrlFetchedMsg msg)
        {
            prevButton.Enabled = msg.hasPrev ? true : false;
            nextButton.Enabled = msg.hasNext ? true : false;
            urlBox.Text = msg.url;
            htmlRich.Text = msg.html;
            statusLabel.Text = msg.codeAndStatus;
            titleTextBox.Text = msg.title;

            refreshHistoryListView();

            favourBtn.Enabled = true;
        }

        private void urlBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void prev_Click(object sender, EventArgs e)
        {
            History history = History.getInstance();
            history.movePrev();
        }

        private void next_Click(object sender, EventArgs e)
        {
            History history = History.getInstance();
            history.moveNext();
        }

        private void urlBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Check if the Enter key was pressed
            {
                e.SuppressKeyPress = true; // Prevent the ding sound
                                           // Your logic here (e.g., process the input)
                                           //MessageBox.Show("Enter pressed: " + urlBox.Text);

                History history = History.getInstance();
                history.newPage(urlBox.Text.Trim());
            }

            //unable the favour button no matter which key was pressed
            favourBtn.Enabled = false;
        }

        public void refreshHistoryListView()
        {
            historyListView.Items.Clear();

            List<HistoryRowData> list = HistoryForSave.getInstance().historyRowList;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                HistoryRowData row = list[i];
                ListViewItem item = new ListViewItem(row.dateTime.ToString());
                item.SubItems.Add(row.title);
                item.SubItems.Add(row.url);
                historyListView.Items.Add(item);
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
                    History.getInstance().renderDownloadUrls(allLines);
                    
                } catch(Exception ex)
                {
                    MessageBox.Show("Error when reading file:" + ex.Message);
                }
            }

        }




        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            ListViewItem item = favouriteListView.SelectedItems[0];
            string url = item.SubItems[1].Text;
            History.getInstance().newPage(url);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            //name with blank is not allowed
            ListViewItem item = favouriteListView.SelectedItems[0];
            FavouriteForm form = new FavouriteForm(item.SubItems[0].Text, item.SubItems[1].Text);
            form.ShowDialog();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            ListViewItem item = favouriteListView.SelectedItems[0];
            string url = item.SubItems[1].Text;
            FavouriteForSave.getInstance().remove(url);
        }

        private void favourBtn_Click(object sender, EventArgs e)
        {
            FavouriteForSave.getInstance().save(History.getInstance().getCurTitle(), History.getInstance().getCurUrl());
        }

        public void refreshFavouriteListView()
        {
            favouriteListView.Items.Clear();

            List<FavouriteRowData> list = FavouriteForSave.getInstance().favouriteRowList;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                FavouriteRowData row = list[i];
                ListViewItem item = new ListViewItem(row.name);
                item.SubItems.Add(row.url);
                favouriteListView.Items.Add(item);
            }

            refreshFavouriteRelatedButtons();
        }

        private void favouriteSelectedIndexChanged(object sender, EventArgs e)
        {
            refreshFavouriteRelatedButtons();
        }

        private void refreshFavouriteRelatedButtons()
        {
            if (favouriteListView.SelectedItems.Count > 0)
            {
                goBtn.Enabled = true;
                editBtn.Enabled = true;
                deleteBtn.Enabled = true;
            }
            else
            {
                goBtn.Enabled = false;
                editBtn.Enabled = false;
                deleteBtn.Enabled = false;
            }
        }

        private void historyMouseHover(object sender, EventArgs e)
        {
            historyListView.Cursor = Cursors.Hand;
        }

        private void historyMouseLeave(object sender, EventArgs e)
        {
            historyListView.Cursor = Cursors.Default;
        }

        private void historyItemActivate(object sender, EventArgs e)
        {
            
        }

        private void historySelectedIndexChanged(object sender, EventArgs e)
        {
            if (historyListView.SelectedItems.Count > 0)
            {
                ListViewItem item = historyListView.SelectedItems[0];

                string url = item.SubItems[2].Text;
                History.getInstance().newPage(url);
            }
        }

        private void editHomeBtn_Click(object sender, EventArgs e)
        {
            EditHomeForm form = new EditHomeForm(Config.getInstance().getHomeUrl());
            form.ShowDialog();
        }
    }
}

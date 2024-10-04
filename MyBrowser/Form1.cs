using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace MyBrowser
{
    public partial class Form1 : Form
    {
        private HtmlArea htmlArea;

        public Form1()
        {
            InitializeComponent();

           
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
    }
}

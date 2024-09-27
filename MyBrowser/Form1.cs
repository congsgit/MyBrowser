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

        }

        private void next_Click(object sender, EventArgs e)
        {

        }

        private void urlBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Check if the Enter key was pressed
            {
                e.SuppressKeyPress = true; // Prevent the ding sound
                                           // Your logic here (e.g., process the input)
                                           //MessageBox.Show("Enter pressed: " + urlBox.Text);

                HtmlArea.getHtmlArea().renderUrl(urlBox.Text.Trim());
            }
        }
    }
}

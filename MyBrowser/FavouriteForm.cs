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
    public partial class FavouriteForm : Form
    {
        public FavouriteForm(string name, string url)
        {
            InitializeComponent();

            nameTextBox.Text = name;
            urlTextBox.Text = url;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            FavouriteForSave.getInstance().save(nameTextBox.Text, urlTextBox.Text);
            this.Close();
        }
    }
}

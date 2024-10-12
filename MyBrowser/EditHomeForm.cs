﻿using System;
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
    public partial class EditHomeForm : Form
    {
        public EditHomeForm(string url)
        {
            InitializeComponent();
            homeTextBox.Text = url;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Config.getInstance().saveHomeUrl(homeTextBox.Text.Trim());
            this.Close();
        }
    }
}

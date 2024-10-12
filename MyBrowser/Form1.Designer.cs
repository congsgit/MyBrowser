
namespace MyBrowser
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.urlBox = new System.Windows.Forms.TextBox();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.favourBtn = new System.Windows.Forms.Button();
            this.htmlRich = new System.Windows.Forms.RichTextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.favouriteListView = new System.Windows.Forms.ListView();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.goBtn = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.historyListView = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(157, 27);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(579, 20);
            this.urlBox.TabIndex = 0;
            this.urlBox.TextChanged += new System.EventHandler(this.urlBox_TextChanged);
            this.urlBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.urlBoxKeyDown);
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(35, 25);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(43, 23);
            this.prevButton.TabIndex = 1;
            this.prevButton.Text = "<-";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prev_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(93, 25);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(42, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "->";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.next_Click);
            // 
            // favourBtn
            // 
            this.favourBtn.Location = new System.Drawing.Point(752, 25);
            this.favourBtn.Name = "favourBtn";
            this.favourBtn.Size = new System.Drawing.Size(75, 23);
            this.favourBtn.TabIndex = 3;
            this.favourBtn.Text = "favour";
            this.favourBtn.UseVisualStyleBackColor = true;
            this.favourBtn.Click += new System.EventHandler(this.favourBtn_Click);
            // 
            // htmlRich
            // 
            this.htmlRich.Location = new System.Drawing.Point(35, 105);
            this.htmlRich.Name = "htmlRich";
            this.htmlRich.ReadOnly = true;
            this.htmlRich.Size = new System.Drawing.Size(560, 381);
            this.htmlRich.TabIndex = 4;
            this.htmlRich.Text = "hello world";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(548, 77);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "status";
            // 
            // downloadBtn
            // 
            this.downloadBtn.Location = new System.Drawing.Point(846, 23);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(75, 23);
            this.downloadBtn.TabIndex = 6;
            this.downloadBtn.Text = "download";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.historyListView);
            this.groupBox1.Location = new System.Drawing.Point(601, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 421);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.favouriteListView);
            this.groupBox2.Controls.Add(this.deleteBtn);
            this.groupBox2.Controls.Add(this.editBtn);
            this.groupBox2.Controls.Add(this.goBtn);
            this.groupBox2.Location = new System.Drawing.Point(897, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 421);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Favourite";
            // 
            // favouriteListView
            // 
            this.favouriteListView.HideSelection = false;
            this.favouriteListView.Location = new System.Drawing.Point(16, 25);
            this.favouriteListView.Name = "favouriteListView";
            this.favouriteListView.Size = new System.Drawing.Size(246, 381);
            this.favouriteListView.TabIndex = 4;
            this.favouriteListView.UseCompatibleStateImageBehavior = false;
            this.favouriteListView.SelectedIndexChanged += new System.EventHandler(this.favouriteSelectedIndexChanged);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(268, 242);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(268, 189);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(268, 136);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 23);
            this.goBtn.TabIndex = 1;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Enabled = false;
            this.titleTextBox.Location = new System.Drawing.Point(35, 74);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(498, 20);
            this.titleTextBox.TabIndex = 10;
            // 
            // historyListView
            // 
            this.historyListView.HideSelection = false;
            this.historyListView.Location = new System.Drawing.Point(14, 25);
            this.historyListView.Name = "historyListView";
            this.historyListView.Size = new System.Drawing.Size(261, 381);
            this.historyListView.TabIndex = 8;
            this.historyListView.UseCompatibleStateImageBehavior = false;
            this.historyListView.ItemActivate += new System.EventHandler(this.historyItemActivate);
            this.historyListView.SelectedIndexChanged += new System.EventHandler(this.historySelectedIndexChanged);
            this.historyListView.MouseLeave += new System.EventHandler(this.historyMouseLeave);
            this.historyListView.MouseHover += new System.EventHandler(this.historyMouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 497);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.htmlRich);
            this.Controls.Add(this.favourBtn);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.urlBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button favourBtn;
        private System.Windows.Forms.RichTextBox htmlRich;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.ListView favouriteListView;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.ListView historyListView;
    }
}


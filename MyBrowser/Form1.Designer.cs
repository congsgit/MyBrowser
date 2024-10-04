
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
            this.bookmarkButton = new System.Windows.Forms.Button();
            this.htmlRich = new System.Windows.Forms.RichTextBox();
            this.statusLabel = new System.Windows.Forms.Label();
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
            // bookmarkButton
            // 
            this.bookmarkButton.Location = new System.Drawing.Point(752, 25);
            this.bookmarkButton.Name = "bookmarkButton";
            this.bookmarkButton.Size = new System.Drawing.Size(75, 23);
            this.bookmarkButton.TabIndex = 3;
            this.bookmarkButton.Text = "favor";
            this.bookmarkButton.UseVisualStyleBackColor = true;
            // 
            // htmlRich
            // 
            this.htmlRich.Location = new System.Drawing.Point(35, 65);
            this.htmlRich.Name = "htmlRich";
            this.htmlRich.ReadOnly = true;
            this.htmlRich.Size = new System.Drawing.Size(992, 349);
            this.htmlRich.TabIndex = 4;
            this.htmlRich.Text = "hello world";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(32, 437);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 470);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.htmlRich);
            this.Controls.Add(this.bookmarkButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.urlBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();


            //init
            HtmlArea.getHtmlArea().init(htmlRich, statusLabel);
            refresh();
        }

        #endregion

        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button bookmarkButton;
        private System.Windows.Forms.RichTextBox htmlRich;
        private System.Windows.Forms.Label statusLabel;
    }
}


namespace AliScraperWindowsForms
{
    partial class AliExpressScraperForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AliExpressScraperForm));
            this.AliURLText = new System.Windows.Forms.TextBox();
            this.AliURLLabel = new System.Windows.Forms.Label();
            this.PagesBox = new System.Windows.Forms.GroupBox();
            this.PagesRadio100 = new System.Windows.Forms.RadioButton();
            this.PagesRadio50 = new System.Windows.Forms.RadioButton();
            this.PagesRadio10 = new System.Windows.Forms.RadioButton();
            this.ProgressLogBox = new System.Windows.Forms.TextBox();
            this.OutpurDirText = new System.Windows.Forms.TextBox();
            this.ChooseDirButton = new System.Windows.Forms.Button();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.OutputBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.PagesBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AliURLText
            // 
            this.AliURLText.Location = new System.Drawing.Point(12, 37);
            this.AliURLText.Name = "AliURLText";
            this.AliURLText.Size = new System.Drawing.Size(319, 20);
            this.AliURLText.TabIndex = 0;
            // 
            // AliURLLabel
            // 
            this.AliURLLabel.AutoSize = true;
            this.AliURLLabel.Location = new System.Drawing.Point(12, 21);
            this.AliURLLabel.Name = "AliURLLabel";
            this.AliURLLabel.Size = new System.Drawing.Size(83, 13);
            this.AliURLLabel.TabIndex = 1;
            this.AliURLLabel.Text = "AliExpress URL:";
            // 
            // PagesBox
            // 
            this.PagesBox.Controls.Add(this.PagesRadio100);
            this.PagesBox.Controls.Add(this.PagesRadio50);
            this.PagesBox.Controls.Add(this.PagesRadio10);
            this.PagesBox.Location = new System.Drawing.Point(12, 75);
            this.PagesBox.Name = "PagesBox";
            this.PagesBox.Size = new System.Drawing.Size(319, 45);
            this.PagesBox.TabIndex = 3;
            this.PagesBox.TabStop = false;
            this.PagesBox.Text = "Pages to download:";
            // 
            // PagesRadio100
            // 
            this.PagesRadio100.AutoSize = true;
            this.PagesRadio100.Checked = true;
            this.PagesRadio100.Location = new System.Drawing.Point(236, 19);
            this.PagesRadio100.Name = "PagesRadio100";
            this.PagesRadio100.Size = new System.Drawing.Size(76, 17);
            this.PagesRadio100.TabIndex = 2;
            this.PagesRadio100.TabStop = true;
            this.PagesRadio100.Text = "100 Pages";
            this.PagesRadio100.UseVisualStyleBackColor = true;
            // 
            // PagesRadio50
            // 
            this.PagesRadio50.AutoSize = true;
            this.PagesRadio50.Location = new System.Drawing.Point(121, 19);
            this.PagesRadio50.Name = "PagesRadio50";
            this.PagesRadio50.Size = new System.Drawing.Size(70, 17);
            this.PagesRadio50.TabIndex = 1;
            this.PagesRadio50.Text = "50 Pages";
            this.PagesRadio50.UseVisualStyleBackColor = true;
            // 
            // PagesRadio10
            // 
            this.PagesRadio10.AutoSize = true;
            this.PagesRadio10.Location = new System.Drawing.Point(6, 19);
            this.PagesRadio10.Name = "PagesRadio10";
            this.PagesRadio10.Size = new System.Drawing.Size(70, 17);
            this.PagesRadio10.TabIndex = 0;
            this.PagesRadio10.Text = "10 Pages";
            this.PagesRadio10.UseVisualStyleBackColor = true;
            // 
            // ProgressLogBox
            // 
            this.ProgressLogBox.Location = new System.Drawing.Point(12, 181);
            this.ProgressLogBox.Multiline = true;
            this.ProgressLogBox.Name = "ProgressLogBox";
            this.ProgressLogBox.ReadOnly = true;
            this.ProgressLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ProgressLogBox.ShortcutsEnabled = false;
            this.ProgressLogBox.Size = new System.Drawing.Size(319, 189);
            this.ProgressLogBox.TabIndex = 6;
            this.ProgressLogBox.WordWrap = false;
            // 
            // OutpurDirText
            // 
            this.OutpurDirText.Location = new System.Drawing.Point(12, 146);
            this.OutpurDirText.Name = "OutpurDirText";
            this.OutpurDirText.ReadOnly = true;
            this.OutpurDirText.ShortcutsEnabled = false;
            this.OutpurDirText.Size = new System.Drawing.Size(238, 20);
            this.OutpurDirText.TabIndex = 10;
            this.OutpurDirText.TabStop = false;
            // 
            // ChooseDirButton
            // 
            this.ChooseDirButton.Location = new System.Drawing.Point(256, 146);
            this.ChooseDirButton.Name = "ChooseDirButton";
            this.ChooseDirButton.Size = new System.Drawing.Size(75, 20);
            this.ChooseDirButton.TabIndex = 6;
            this.ChooseDirButton.Text = "Search";
            this.ChooseDirButton.UseVisualStyleBackColor = true;
            this.ChooseDirButton.Click += new System.EventHandler(this.ChooseDirButton_Click);
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(12, 130);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(58, 13);
            this.OutputLabel.TabIndex = 5;
            this.OutputLabel.Text = "Output Dir:";
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(256, 385);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(75, 20);
            this.DownloadButton.TabIndex = 11;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // AliExpressScraperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 417);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.ChooseDirButton);
            this.Controls.Add(this.OutpurDirText);
            this.Controls.Add(this.ProgressLogBox);
            this.Controls.Add(this.PagesBox);
            this.Controls.Add(this.AliURLLabel);
            this.Controls.Add(this.AliURLText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AliExpressScraperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AliExpress Scraper";
            this.PagesBox.ResumeLayout(false);
            this.PagesBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AliURLText;
        private System.Windows.Forms.Label AliURLLabel;
        private System.Windows.Forms.GroupBox PagesBox;
        private System.Windows.Forms.RadioButton PagesRadio10;
        private System.Windows.Forms.RadioButton PagesRadio100;
        private System.Windows.Forms.RadioButton PagesRadio50;
        private System.Windows.Forms.TextBox ProgressLogBox;
        private System.Windows.Forms.TextBox OutpurDirText;
        private System.Windows.Forms.Button ChooseDirButton;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.FolderBrowserDialog OutputBrowser;
        private System.Windows.Forms.Button DownloadButton;
    }
}


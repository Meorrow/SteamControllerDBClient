﻿namespace SteamControllerDBClient
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.steamLocationTextBox = new System.Windows.Forms.TextBox();
            this.steamLocationButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.steamUserComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.whatIsThisLinkLabel = new System.Windows.Forms.LinkLabel();
            this.configFileGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.configFileTextBox = new System.Windows.Forms.TextBox();
            this.configFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.gameNameTextBox = new System.Windows.Forms.TextBox();
            this.configNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.configDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.importConfigButton = new System.Windows.Forms.Button();
            this.configDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.fileImportTabPage = new System.Windows.Forms.TabPage();
            this.diagnosticsTabPage = new System.Windows.Forms.TabPage();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.configFileGroupBox.SuspendLayout();
            this.configDetailsGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.fileImportTabPage.SuspendLayout();
            this.diagnosticsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Steam Location:";
            // 
            // steamLocationTextBox
            // 
            this.steamLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.steamLocationTextBox.Location = new System.Drawing.Point(97, 24);
            this.steamLocationTextBox.Name = "steamLocationTextBox";
            this.steamLocationTextBox.ReadOnly = true;
            this.steamLocationTextBox.Size = new System.Drawing.Size(562, 20);
            this.steamLocationTextBox.TabIndex = 1;
            // 
            // steamLocationButton
            // 
            this.steamLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.steamLocationButton.Location = new System.Drawing.Point(665, 22);
            this.steamLocationButton.Name = "steamLocationButton";
            this.steamLocationButton.Size = new System.Drawing.Size(25, 23);
            this.steamLocationButton.TabIndex = 2;
            this.steamLocationButton.Text = "...";
            this.steamLocationButton.UseVisualStyleBackColor = true;
            this.steamLocationButton.Click += new System.EventHandler(this.steamLocationButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Steam User:";
            // 
            // steamUserComboBox
            // 
            this.steamUserComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.steamUserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.steamUserComboBox.FormattingEnabled = true;
            this.steamUserComboBox.Location = new System.Drawing.Point(97, 50);
            this.steamUserComboBox.Name = "steamUserComboBox";
            this.steamUserComboBox.Size = new System.Drawing.Size(519, 21);
            this.steamUserComboBox.TabIndex = 4;
            this.steamUserComboBox.SelectedIndexChanged += new System.EventHandler(this.steamUserComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.whatIsThisLinkLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.steamUserComboBox);
            this.groupBox1.Controls.Add(this.steamLocationTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.steamLocationButton);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 86);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // whatIsThisLinkLabel
            // 
            this.whatIsThisLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.whatIsThisLinkLabel.AutoSize = true;
            this.whatIsThisLinkLabel.Location = new System.Drawing.Point(622, 53);
            this.whatIsThisLinkLabel.Name = "whatIsThisLinkLabel";
            this.whatIsThisLinkLabel.Size = new System.Drawing.Size(68, 13);
            this.whatIsThisLinkLabel.TabIndex = 5;
            this.whatIsThisLinkLabel.TabStop = true;
            this.whatIsThisLinkLabel.Text = "What is this?";
            this.whatIsThisLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.whatIsThisLinkLabel_LinkClicked);
            // 
            // configFileGroupBox
            // 
            this.configFileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configFileGroupBox.Controls.Add(this.label3);
            this.configFileGroupBox.Controls.Add(this.configFileTextBox);
            this.configFileGroupBox.Controls.Add(this.configFileButton);
            this.configFileGroupBox.Location = new System.Drawing.Point(6, 98);
            this.configFileGroupBox.Name = "configFileGroupBox";
            this.configFileGroupBox.Size = new System.Drawing.Size(696, 57);
            this.configFileGroupBox.TabIndex = 6;
            this.configFileGroupBox.TabStop = false;
            this.configFileGroupBox.Text = "Controller Config";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Config File:";
            // 
            // configFileTextBox
            // 
            this.configFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configFileTextBox.Location = new System.Drawing.Point(97, 22);
            this.configFileTextBox.Name = "configFileTextBox";
            this.configFileTextBox.ReadOnly = true;
            this.configFileTextBox.Size = new System.Drawing.Size(562, 20);
            this.configFileTextBox.TabIndex = 4;
            // 
            // configFileButton
            // 
            this.configFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.configFileButton.Location = new System.Drawing.Point(665, 20);
            this.configFileButton.Name = "configFileButton";
            this.configFileButton.Size = new System.Drawing.Size(25, 23);
            this.configFileButton.TabIndex = 5;
            this.configFileButton.Text = "...";
            this.configFileButton.UseVisualStyleBackColor = true;
            this.configFileButton.Click += new System.EventHandler(this.configFileButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Steam Controller Database Config Files|*vdffz|Valve Config Files|*vdf";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Game:";
            // 
            // gameNameTextBox
            // 
            this.gameNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameNameTextBox.Location = new System.Drawing.Point(97, 22);
            this.gameNameTextBox.Name = "gameNameTextBox";
            this.gameNameTextBox.ReadOnly = true;
            this.gameNameTextBox.Size = new System.Drawing.Size(593, 20);
            this.gameNameTextBox.TabIndex = 7;
            // 
            // configNameTextBox
            // 
            this.configNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configNameTextBox.Location = new System.Drawing.Point(97, 48);
            this.configNameTextBox.Name = "configNameTextBox";
            this.configNameTextBox.ReadOnly = true;
            this.configNameTextBox.Size = new System.Drawing.Size(593, 20);
            this.configNameTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Config Name:";
            // 
            // configDescriptionTextBox
            // 
            this.configDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configDescriptionTextBox.Location = new System.Drawing.Point(97, 74);
            this.configDescriptionTextBox.Multiline = true;
            this.configDescriptionTextBox.Name = "configDescriptionTextBox";
            this.configDescriptionTextBox.ReadOnly = true;
            this.configDescriptionTextBox.Size = new System.Drawing.Size(593, 112);
            this.configDescriptionTextBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Description:";
            // 
            // importConfigButton
            // 
            this.importConfigButton.Location = new System.Drawing.Point(616, 193);
            this.importConfigButton.Name = "importConfigButton";
            this.importConfigButton.Size = new System.Drawing.Size(75, 23);
            this.importConfigButton.TabIndex = 12;
            this.importConfigButton.Text = "Import";
            this.importConfigButton.UseVisualStyleBackColor = true;
            this.importConfigButton.Click += new System.EventHandler(this.importConfigButton_Click);
            // 
            // configDetailsGroupBox
            // 
            this.configDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configDetailsGroupBox.Controls.Add(this.importConfigButton);
            this.configDetailsGroupBox.Controls.Add(this.label4);
            this.configDetailsGroupBox.Controls.Add(this.configNameTextBox);
            this.configDetailsGroupBox.Controls.Add(this.gameNameTextBox);
            this.configDetailsGroupBox.Controls.Add(this.label6);
            this.configDetailsGroupBox.Controls.Add(this.configDescriptionTextBox);
            this.configDetailsGroupBox.Controls.Add(this.label5);
            this.configDetailsGroupBox.Location = new System.Drawing.Point(6, 161);
            this.configDetailsGroupBox.Name = "configDetailsGroupBox";
            this.configDetailsGroupBox.Size = new System.Drawing.Size(696, 222);
            this.configDetailsGroupBox.TabIndex = 14;
            this.configDetailsGroupBox.TabStop = false;
            this.configDetailsGroupBox.Text = "Config Details";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.fileImportTabPage);
            this.tabControl1.Controls.Add(this.diagnosticsTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(716, 420);
            this.tabControl1.TabIndex = 15;
            // 
            // fileImportTabPage
            // 
            this.fileImportTabPage.Controls.Add(this.groupBox1);
            this.fileImportTabPage.Controls.Add(this.configDetailsGroupBox);
            this.fileImportTabPage.Controls.Add(this.configFileGroupBox);
            this.fileImportTabPage.Location = new System.Drawing.Point(4, 22);
            this.fileImportTabPage.Name = "fileImportTabPage";
            this.fileImportTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.fileImportTabPage.Size = new System.Drawing.Size(708, 394);
            this.fileImportTabPage.TabIndex = 0;
            this.fileImportTabPage.Text = "File Import";
            this.fileImportTabPage.UseVisualStyleBackColor = true;
            // 
            // diagnosticsTabPage
            // 
            this.diagnosticsTabPage.Controls.Add(this.logRichTextBox);
            this.diagnosticsTabPage.Controls.Add(this.label7);
            this.diagnosticsTabPage.Location = new System.Drawing.Point(4, 22);
            this.diagnosticsTabPage.Name = "diagnosticsTabPage";
            this.diagnosticsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.diagnosticsTabPage.Size = new System.Drawing.Size(708, 394);
            this.diagnosticsTabPage.TabIndex = 1;
            this.diagnosticsTabPage.Text = "Diagnostics";
            this.diagnosticsTabPage.UseVisualStyleBackColor = true;
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.Location = new System.Drawing.Point(9, 53);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.Size = new System.Drawing.Size(693, 335);
            this.logRichTextBox.TabIndex = 1;
            this.logRichTextBox.Text = "";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(6, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(696, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 444);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam Controller DB Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.configFileGroupBox.ResumeLayout(false);
            this.configFileGroupBox.PerformLayout();
            this.configDetailsGroupBox.ResumeLayout(false);
            this.configDetailsGroupBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.fileImportTabPage.ResumeLayout(false);
            this.diagnosticsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox steamLocationTextBox;
        private System.Windows.Forms.Button steamLocationButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox steamUserComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox configFileGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox configFileTextBox;
        private System.Windows.Forms.Button configFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox configDescriptionTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox configNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox gameNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button importConfigButton;
        private System.Windows.Forms.GroupBox configDetailsGroupBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage fileImportTabPage;
        private System.Windows.Forms.TabPage diagnosticsTabPage;
        private System.Windows.Forms.RichTextBox logRichTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel whatIsThisLinkLabel;
    }
}


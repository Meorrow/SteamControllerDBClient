namespace SteamControllerDBClient
{
    partial class ImportDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportDialog));
            this.steamGameGroupBox = new System.Windows.Forms.GroupBox();
            this.nonSteamGameGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shortcutsComboBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.importNonSteamGameButton = new System.Windows.Forms.Button();
            this.importSteamGameButton = new System.Windows.Forms.Button();
            this.steamGameGroupBox.SuspendLayout();
            this.nonSteamGameGroupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // steamGameGroupBox
            // 
            this.steamGameGroupBox.Controls.Add(this.importSteamGameButton);
            this.steamGameGroupBox.Controls.Add(this.label1);
            this.steamGameGroupBox.Location = new System.Drawing.Point(3, 3);
            this.steamGameGroupBox.Name = "steamGameGroupBox";
            this.steamGameGroupBox.Size = new System.Drawing.Size(266, 124);
            this.steamGameGroupBox.TabIndex = 0;
            this.steamGameGroupBox.TabStop = false;
            this.steamGameGroupBox.Text = "I own this game on Steam";
            // 
            // nonSteamGameGroupBox
            // 
            this.nonSteamGameGroupBox.Controls.Add(this.importNonSteamGameButton);
            this.nonSteamGameGroupBox.Controls.Add(this.shortcutsComboBox);
            this.nonSteamGameGroupBox.Controls.Add(this.label2);
            this.nonSteamGameGroupBox.Location = new System.Drawing.Point(275, 3);
            this.nonSteamGameGroupBox.Name = "nonSteamGameGroupBox";
            this.nonSteamGameGroupBox.Size = new System.Drawing.Size(332, 124);
            this.nonSteamGameGroupBox.TabIndex = 1;
            this.nonSteamGameGroupBox.TabStop = false;
            this.nonSteamGameGroupBox.Text = "This is a non-Steam game";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "If you bought this game on Steam, or if you bought a key that you redeemed on Ste" +
    "am, use this button.";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "If you don\'t own a Steam version of this game (you added it as a Non-Steam game)," +
    " select the shortcut below and click Import.";
            // 
            // shortcutsComboBox
            // 
            this.shortcutsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shortcutsComboBox.FormattingEnabled = true;
            this.shortcutsComboBox.Location = new System.Drawing.Point(9, 67);
            this.shortcutsComboBox.Name = "shortcutsComboBox";
            this.shortcutsComboBox.Size = new System.Drawing.Size(317, 21);
            this.shortcutsComboBox.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.steamGameGroupBox);
            this.flowLayoutPanel1.Controls.Add(this.nonSteamGameGroupBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(610, 141);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // importNonSteamGameButton
            // 
            this.importNonSteamGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importNonSteamGameButton.Location = new System.Drawing.Point(223, 95);
            this.importNonSteamGameButton.Name = "importNonSteamGameButton";
            this.importNonSteamGameButton.Size = new System.Drawing.Size(103, 23);
            this.importNonSteamGameButton.TabIndex = 2;
            this.importNonSteamGameButton.Text = "Import!";
            this.importNonSteamGameButton.UseVisualStyleBackColor = true;
            this.importNonSteamGameButton.Click += new System.EventHandler(this.importNonSteamGameButton_Click);
            // 
            // importSteamGameButton
            // 
            this.importSteamGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importSteamGameButton.Location = new System.Drawing.Point(157, 95);
            this.importSteamGameButton.Name = "importSteamGameButton";
            this.importSteamGameButton.Size = new System.Drawing.Size(103, 23);
            this.importSteamGameButton.TabIndex = 3;
            this.importSteamGameButton.Text = "Import!";
            this.importSteamGameButton.UseVisualStyleBackColor = true;
            this.importSteamGameButton.Click += new System.EventHandler(this.importSteamGameButton_Click);
            // 
            // ImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 165);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Controller Config";
            this.steamGameGroupBox.ResumeLayout(false);
            this.nonSteamGameGroupBox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox steamGameGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox nonSteamGameGroupBox;
        private System.Windows.Forms.ComboBox shortcutsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button importSteamGameButton;
        private System.Windows.Forms.Button importNonSteamGameButton;
    }
}
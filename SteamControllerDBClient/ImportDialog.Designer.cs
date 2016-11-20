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
            this.importSteamGameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nonSteamGameGroupBox = new System.Windows.Forms.GroupBox();
            this.importNonSteamGameButton = new System.Windows.Forms.Button();
            this.shortcutsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.steamGameGroupBox.SuspendLayout();
            this.nonSteamGameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // steamGameGroupBox
            // 
            this.steamGameGroupBox.Controls.Add(this.importSteamGameButton);
            this.steamGameGroupBox.Controls.Add(this.label1);
            this.steamGameGroupBox.Location = new System.Drawing.Point(12, 142);
            this.steamGameGroupBox.Name = "steamGameGroupBox";
            this.steamGameGroupBox.Size = new System.Drawing.Size(612, 87);
            this.steamGameGroupBox.TabIndex = 0;
            this.steamGameGroupBox.TabStop = false;
            this.steamGameGroupBox.Text = "I own this game on Steam";
            // 
            // importSteamGameButton
            // 
            this.importSteamGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importSteamGameButton.Location = new System.Drawing.Point(503, 58);
            this.importSteamGameButton.Name = "importSteamGameButton";
            this.importSteamGameButton.Size = new System.Drawing.Size(103, 23);
            this.importSteamGameButton.TabIndex = 3;
            this.importSteamGameButton.Text = "Import!";
            this.importSteamGameButton.UseVisualStyleBackColor = true;
            this.importSteamGameButton.Click += new System.EventHandler(this.importSteamGameButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "If you bought this game on Steam, or if you bought a key that you redeemed on Ste" +
    "am, use this button.";
            // 
            // nonSteamGameGroupBox
            // 
            this.nonSteamGameGroupBox.Controls.Add(this.importNonSteamGameButton);
            this.nonSteamGameGroupBox.Controls.Add(this.shortcutsComboBox);
            this.nonSteamGameGroupBox.Controls.Add(this.label2);
            this.nonSteamGameGroupBox.Location = new System.Drawing.Point(12, 12);
            this.nonSteamGameGroupBox.Name = "nonSteamGameGroupBox";
            this.nonSteamGameGroupBox.Size = new System.Drawing.Size(612, 124);
            this.nonSteamGameGroupBox.TabIndex = 1;
            this.nonSteamGameGroupBox.TabStop = false;
            this.nonSteamGameGroupBox.Text = "This is a non-Steam game";
            // 
            // importNonSteamGameButton
            // 
            this.importNonSteamGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importNonSteamGameButton.Location = new System.Drawing.Point(503, 95);
            this.importNonSteamGameButton.Name = "importNonSteamGameButton";
            this.importNonSteamGameButton.Size = new System.Drawing.Size(103, 23);
            this.importNonSteamGameButton.TabIndex = 2;
            this.importNonSteamGameButton.Text = "Import!";
            this.importNonSteamGameButton.UseVisualStyleBackColor = true;
            this.importNonSteamGameButton.Click += new System.EventHandler(this.importNonSteamGameButton_Click);
            // 
            // shortcutsComboBox
            // 
            this.shortcutsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shortcutsComboBox.FormattingEnabled = true;
            this.shortcutsComboBox.Location = new System.Drawing.Point(9, 67);
            this.shortcutsComboBox.Name = "shortcutsComboBox";
            this.shortcutsComboBox.Size = new System.Drawing.Size(597, 21);
            this.shortcutsComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(600, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "If you don\'t own a Steam version of this game (you added it as a Non-Steam game)," +
    " select the shortcut below and click Import.";
            // 
            // ImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 237);
            this.Controls.Add(this.steamGameGroupBox);
            this.Controls.Add(this.nonSteamGameGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Controller Config";
            this.steamGameGroupBox.ResumeLayout(false);
            this.nonSteamGameGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox steamGameGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox nonSteamGameGroupBox;
        private System.Windows.Forms.ComboBox shortcutsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button importSteamGameButton;
        private System.Windows.Forms.Button importNonSteamGameButton;
    }
}
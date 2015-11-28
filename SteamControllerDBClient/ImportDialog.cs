using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SteamControllerDBClient
{
    public partial class ImportDialog : Form
    {
        private string steamPathWithUser = "";
        private ConfigFile configFile = null;
        private MainForm mainForm = null;

        public ImportDialog(MainForm mainForm, string steamPathWithUser, ConfigFile configFile, List<SteamShortcut> steamShortcuts)
        {
            try
            {
                this.mainForm = mainForm;

                InitializeComponent();

                this.steamPathWithUser = steamPathWithUser;
                this.configFile = configFile;

                steamGameGroupBox.Visible = true;

                SteamShortcut emptyShortcut = new SteamShortcut();
                emptyShortcut.Name = "Select a shortcut";
                if (steamShortcuts.Count == 0)
                {
                    emptyShortcut.Name = "No shortcuts found";
                }
                shortcutsComboBox.Items.Add(emptyShortcut);
                shortcutsComboBox.Items.AddRange(steamShortcuts.ToArray());
                shortcutsComboBox.SelectedIndex = 0;

                foreach (SteamShortcut ss in shortcutsComboBox.Items)
                {
                    if (ss.Name.ToUpper().Trim() == configFile.GameName.ToUpper().Trim())
                    {
                        shortcutsComboBox.SelectedItem = ss;
                        break;
                    }
                }

                if (configFile.SteamAppId == null || configFile.SteamAppId <= 0)
                {
                    steamGameGroupBox.Visible = false;
                }
            }
            catch(Exception ex)
            {
                mainForm.GenericErrorHandler(ex);
            }
        }

        private void importSteamGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(steamPathWithUser, "241100" + Path.DirectorySeparatorChar + "remote" + Path.DirectorySeparatorChar + "controller_config" + Path.DirectorySeparatorChar + configFile.SteamAppId + Path.DirectorySeparatorChar + configFile.FileName);
                mainForm.Debug("Attempting to import config file as steam game, destination is " + path);

                ImportFile(path);
            }
            catch(Exception ex)
            {
                mainForm.GenericErrorHandler(ex);
            }
        }

        private void ImportFile(string path)
        {
            string pathNoFilename = Path.GetDirectoryName(path);
            if (!Directory.Exists(pathNoFilename))
            {
                Directory.CreateDirectory(pathNoFilename);
            }

            if(path.EndsWith(".vdffz"))
            {
                path = Path.ChangeExtension(path, "vdf");
            }

            using (FileStream fs = File.OpenWrite(path))
            {
                byte[] fileBytes = ASCIIEncoding.ASCII.GetBytes(configFile.ConfigData);
                fs.Write(fileBytes, 0, fileBytes.Length);
                fs.Flush();
            }
            MessageBox.Show("All done!");
            mainForm.Debug("Success");
            this.Hide();
        }

        private void importNonSteamGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                SteamShortcut ss = (SteamShortcut)shortcutsComboBox.SelectedItem;
                if (string.IsNullOrEmpty(ss.SHA1))
                {
                    MessageBox.Show("Please select a shortcut and try importing again");
                    return;
                }

                string path = Path.Combine(steamPathWithUser, "241100" + Path.DirectorySeparatorChar + "remote" + Path.DirectorySeparatorChar + "controller_config" + Path.DirectorySeparatorChar + ss.SHA1 + Path.DirectorySeparatorChar + configFile.FileName);
                mainForm.Debug("Attempting to import config file as non-steam game, destination is " + path);

                ImportFile(path);
            }
            catch (Exception ex)
            {
                mainForm.GenericErrorHandler(ex);
            }
        }
    }
}

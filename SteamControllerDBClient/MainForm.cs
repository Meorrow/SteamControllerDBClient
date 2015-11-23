using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SteamKit2;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SteamControllerDBClient
{
    public partial class MainForm : Form
    {
        private ConfigFile loadedConfigFile = null;

        public MainForm(string[] args)
        {
            InitializeComponent();

            folderBrowserDialog.ShowNewFolderButton = false;

            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");
            if (Directory.Exists(pathDownload))
            {
                openFileDialog.InitialDirectory = pathDownload;
            }
            openFileDialog.Multiselect = false;

            if (args != null && args.Length > 0)
            {
                configFileTextBox.Text = args[0];
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                if (!LoadSteamLocation()) return;

                if (!LoadSteamUser()) return;

                //EnableFileHandlingIfAppropriate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EnableFileHandlingIfAppropriate()
        {
            configNoticeLabel.Visible = true;
            configFileGroupBox.Visible = false;
            configDetailsGroupBox.Visible = false;
            if (ValidateSteamLocation(steamLocationTextBox.Text))
            {
                if (ValidateSteamUser(steamLocationTextBox.Text, (string)steamUserComboBox.SelectedItem))
                {
                    configNoticeLabel.Visible = false;
                    configFileGroupBox.Visible = true;

                    Properties.Settings.Default.SteamLocation = steamLocationTextBox.Text;
                    Properties.Settings.Default.SteamUser = (string)steamUserComboBox.SelectedItem;
                    Properties.Settings.Default.Save();

                    if (!string.IsNullOrWhiteSpace(configFileTextBox.Text) && File.Exists(configFileTextBox.Text))
                    {
                        LoadConfigFile();
                    }
                }
            }
        }

        private void LoadConfigFile()
        {
            try
            {
                configDetailsGroupBox.Visible = false;
                gameNameTextBox.Text = "";
                configNameTextBox.Text = "";
                configDescriptionTextBox.Text = "";

                string shortcutsPath = Path.Combine(steamLocationTextBox.Text, @"userdata\" + steamUserComboBox.SelectedItem + @"\config\shortcuts.vdf");

                using (StreamReader sr = File.OpenText(configFileTextBox.Text))
                {
                    string fileContents = sr.ReadToEnd();

                    try
                    {
                        loadedConfigFile = JsonConvert.DeserializeObject<ConfigFile>(fileContents);

                        gameNameTextBox.Text = loadedConfigFile.GameName;
                        configNameTextBox.Text = loadedConfigFile.Name;
                        configDescriptionTextBox.Text = loadedConfigFile.Description;
                        configDetailsGroupBox.Visible = true;

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Unable to parse config file, please re-download and try again");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool ValidateSteamLocation(string steamLocation)
        {
            if (!Directory.Exists(steamLocation)) return false;

            if (!File.Exists(Path.Combine(steamLocation, "steam.exe"))) return false;

            return true;
        }

        private bool ValidateSteamUser(string steamLocation, string steamUser)
        {
            if (!ValidateSteamLocation(steamLocation)) return false;

            if (!Directory.Exists(Path.Combine(steamLocation, @"userdata\" + steamUser)))
            {
                return false;
            }
            return true;
        }

        private bool LoadSteamLocation()
        {
            //Try to get the steam directory from the registry
            string steamLocation = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", @"C:\Program Files (x86)\Steam").ToString();
            if (!ValidateSteamLocation(steamLocation) && steamLocation.ToLower().StartsWith(@"c:\program files (x86)"))
            {
                //We probably didn't read the registry key, and our default value assumes a 64 bit system, try the 32 bit default location
                steamLocation = @"c:\program files\steam";
            }

            if (!ValidateSteamLocation(steamLocation))
            {
                MessageBox.Show("Unable to find your Steam installation, please select it to continue");
                return false;
            }
            else
            {
                steamLocationTextBox.Text = steamLocation;
                return true;
            }
        }

        private void LoadSteamUserName(string steamId3)
        {
            //Not implemented yet - this will be a call to the Steam Web API
        }

        private bool LoadSteamUser()
        {
            //There's a bunch of stuff to do here. First, pull the list of potential users from the file system
            string[] userDirectories = Directory.GetDirectories(Path.Combine(steamLocationTextBox.Text, "userdata"));

            steamUserComboBox.Items.Clear();
            foreach (string s in userDirectories)
            {
                string[] parts = s.Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
                string userId = parts[parts.Length - 1];
                string tempS = userId.Clone().ToString();
                steamUserComboBox.Items.Add(userId);

                //Try to get the usernames for each user, but do this on a background thread since we're dealing with the internet
                Task.Factory.StartNew(() => LoadSteamUserName(tempS));
            }

            //If there's only one item in the list, select it
            if(steamUserComboBox.Items.Count == 1)
            {
                steamUserComboBox.SelectedIndex = 0;
                return true;
            }

            //If Steam is running, there will be a registry key to let us know which one of the users found above is logged in
            int currentLoggedInUser = (int) Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam\ActiveProcess", "ActiveUser", 0);
            if (currentLoggedInUser != 0)
            {
                steamUserComboBox.SelectedItem = currentLoggedInUser.ToString();
                return true;
            }

            //Maybe the user has run this before - check the settings
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.SteamUser))
            {
                steamUserComboBox.SelectedItem = Properties.Settings.Default.SteamUser;
                if (steamUserComboBox.SelectedIndex >= 0)
                {
                    return true;
                }
            }

            //There are multiple users, we need the user to tell us which one they are...
            MessageBox.Show("Unable to determine which user you are. Please select it in the drop down, or close this app, start Steam and run it again");
            return false;
        }

        private void steamLocationButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (!ValidateSteamLocation(folderBrowserDialog.SelectedPath))
                {
                    MessageBox.Show("The selected folder doesn't appear to be your Steam installation, please select a different folder to continue");
                }
                else
                {
                    steamLocationTextBox.Text = folderBrowserDialog.SelectedPath;

                    if (!LoadSteamUser()) return;

                    EnableFileHandlingIfAppropriate();
                }
            }
        }

        private void configFileButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();
            if(dr == DialogResult.OK)
            {
                configFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void steamUserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ValidateSteamUser(steamLocationTextBox.Text, (string)steamUserComboBox.SelectedItem))
            {
                MessageBox.Show("The selected folder doesn't appear to be a valid user folder, please select a different user to continue");
            }

            EnableFileHandlingIfAppropriate();
        }
    }
}

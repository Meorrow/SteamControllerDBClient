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
using System.Security.Cryptography;
using System.Configuration;

namespace SteamControllerDBClient
{
    public partial class MainForm : Form
    {
        private ConfigFile loadedConfigFile = null;
        private List<SteamShortcut> steamShortcuts = new List<SteamShortcut>();
        private BindingList<SteamPlayer> steamUsers = new BindingList<SteamPlayer>();

        public void Debug(string message, Exception ex = null)
        {
            logRichTextBox.AppendText(message + "\r\n\r\n");
            if(ex != null)
            {
                logRichTextBox.AppendText(ex.ToString() + "\r\n\r\n");
            }
        }
        public void GenericErrorHandler(Exception ex = null)
        {
            string message = "Uh oh, something went wrong, please check the diagnostics tab for more info";
            if(ex != null)
            {
                message += ": " + ex.Message;
            }
            Debug(ex.ToString());
            MessageBox.Show(message);
        }

        public MainForm(string[] args)
        {
            try
            {
                InitializeComponent();

                folderBrowserDialog.ShowNewFolderButton = false;

                string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                Debug("User profile path is " + pathUser);
                if (string.IsNullOrEmpty(Properties.Settings.Default.DefaultFileOpenDirectory))
                {
                    Debug("No previous file open path found, using default");
                    string pathDownload = Path.Combine(pathUser, "Downloads");
                    Debug("Checking for directory " + pathDownload);
                    if (Directory.Exists(pathDownload))
                    {
                        Debug("Directory exists, using it as default file open directory");
                        openFileDialog.InitialDirectory = pathDownload;
                        Properties.Settings.Default.DefaultFileOpenDirectory = pathDownload;
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                    Debug("Using previous file open path of " + Properties.Settings.Default.DefaultFileOpenDirectory);
                    openFileDialog.InitialDirectory = Properties.Settings.Default.DefaultFileOpenDirectory;
                }
                openFileDialog.Multiselect = false;

                if (args != null && args.Length > 0)
                {
                    Debug("Command line arguments passed:");
                    foreach (string arg in args)
                    {
                        Debug("\t" + arg);
                    }
                    configFileTextBox.Text = args[0];
                }

                if (AppDomain.CurrentDomain.SetupInformation.ActivationArguments != null && AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData != null && AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData.Length > 0)
                {
                    Debug("Activation arguments passed:");
                    foreach (string commandLineFile in AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData)
                    {
                        Debug("\t" + commandLineFile);
                    }
                    configFileTextBox.Text = new Uri(AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData[0]).LocalPath;
                    //configFileTextBox.Text = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData[0];
                }
            }
            catch(Exception ex)
            {
                GenericErrorHandler(ex);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                LoadSteamLocation();

                LoadSteamUser();

                LoadConfigFile();
            }
            catch (Exception ex)
            {
                GenericErrorHandler(ex);
            }
        }

        private void LoadConfigFile()
        {
            gameNameTextBox.Text = "";
            configNameTextBox.Text = "";
            configDescriptionTextBox.Text = "";

            string shortcutsPath = Path.Combine(steamLocationTextBox.Text, @"userdata\" + ((SteamPlayer)steamUserComboBox.SelectedItem).id3 + @"\config\shortcuts.vdf");

            if (!string.IsNullOrWhiteSpace(configFileTextBox.Text))
            {
                Debug("Attempting to load config file " + configFileTextBox.Text);
                if (Path.GetExtension(configFileTextBox.Text).ToLower() == ".vdf")
                {
                    //This is a simple config file, nothing to parse
                    Debug("Simple config file loaded, nothing to parse");
                    loadedConfigFile = new ConfigFile();
                    loadedConfigFile.GameName = "<Simple Config Loaded>";
                    loadedConfigFile.Description = "";
                    loadedConfigFile.Name = Path.GetFileName(configFileTextBox.Text);
                    loadedConfigFile.FileName = Path.GetFileName(configFileTextBox.Text);
                    loadedConfigFile.ConfigData = File.ReadAllText(configFileTextBox.Text);
                }
                else
                {
                    using (StreamReader sr = File.OpenText(configFileTextBox.Text))
                    {
                        string fileContents = sr.ReadToEnd();

                        try
                        {
                            Debug("\tTrying parse config file");
                            loadedConfigFile = JsonConvert.DeserializeObject<ConfigFile>(fileContents);
                        }
                        catch (Exception parseException)
                        {
                            Debug("Error parsing config file", parseException);
                            MessageBox.Show("Unable to parse config file, please re-download and try again");
                        }
                    }
                }
                gameNameTextBox.Text = loadedConfigFile.GameName;
                configNameTextBox.Text = loadedConfigFile.Name;
                configDescriptionTextBox.Text = loadedConfigFile.Description;
            }
        }

        private bool ValidateSteamLocation(string steamLocation)
        {
            Debug("Trying to validate " + steamLocation + " as steam location");
            if (!Directory.Exists(steamLocation))
            {
                Debug("\tDirectory doesn't exist");
                return false;
            }

            if (!File.Exists(Path.Combine(steamLocation, "steam.exe")))
            {
                Debug("\tSteam.exe doesn't exist");
                return false;
            }

            Debug("\tLocation validated");
            Properties.Settings.Default.SteamLocation = steamLocation;
            Properties.Settings.Default.Save();

            return true;
        }

        private bool ValidateSteamUser(string steamLocation, string steamUser)
        {
            Debug("Trying to validate steam user " + steamUser + " in steam location " + steamLocation);

            if (!ValidateSteamLocation(steamLocation)) return false;

            if (!Directory.Exists(Path.Combine(steamLocation, @"userdata\" + steamUser)))
            {
                Debug("\tUser directory doesn't exist");
                return false;
            }

            Properties.Settings.Default.SteamUser = steamUser;
            Properties.Settings.Default.Save();
            return true;
        }

        private void LoadSteamLocation()
        {
            Debug("Attempting to load steam location");

            //Maybe the user has run this before - check the settings
            string steamLocation = "";
            bool valid = false;
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.SteamLocation))
            {
                steamLocation = Properties.Settings.Default.SteamLocation;
                valid = ValidateSteamLocation(steamLocation);
            }

            //Try to get the steam directory from the registry
            if (!valid)
            {
                steamLocation = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", @"C:\Program Files (x86)\Steam").ToString();
                valid = ValidateSteamLocation(steamLocation);
            }

            if (!valid && steamLocation.ToLower().StartsWith(@"c:\program files (x86)"))
            {
                //We probably didn't read the registry key, and our default value assumes a 64 bit system, try the 32 bit default location
                steamLocation = @"c:\program files\steam";
                valid = ValidateSteamLocation(steamLocation);
            }

            if (valid)
            {
                steamLocationTextBox.Text = steamLocation;
                return;
            }
        }

        private void LoadSteamUserName(string steamId3)
        {
            try
            {
                SteamKit2.SteamID steamId = new SteamID();
                string id3 = "[U:1:" + steamId3 + "]";
                Console.WriteLine(id3);
                steamId.SetFromSteam3String(id3);

                this.Invoke((MethodInvoker)delegate {
                    Debug("Attempting to load steam profile " + id3);
                });

                RestSharp.RestClient client = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiUrl"]);
                RestSharp.RestRequest request = new RestSharp.RestRequest("get_steam_profile/" + steamId.ConvertToUInt64());
                RestSharp.IRestResponse<SteamProfile> response = client.Execute<SteamProfile>(request);

                if (response.Data != null && response.Data.response != null && response.Data.response.players != null && response.Data.response.players.Count > 0)
                {
                    this.Invoke((MethodInvoker)delegate {
                        Debug(id3 + " is " + response.Data.response.players[0].personaname);

                        foreach(SteamPlayer s in steamUsers)
                        {
                            if(s.id3 == steamId3)
                            {
                                s.personaname = response.Data.response.players[0].personaname;
                                steamUsers.ResetBindings();
                            }
                        }
                    });
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //Debug("Unable to lookup steam profile " + steamId3 + ": " + ex.Message);
            }
        }

        private void LoadSteamUser()
        {
            //There's a bunch of stuff to do here. First, pull the list of potential users from the file system
            string[] userDirectories = Directory.GetDirectories(Path.Combine(steamLocationTextBox.Text, "userdata"));

            steamUserComboBox.Items.Clear();
            foreach (string s in userDirectories)
            {
                string[] parts = s.Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
                string userId = parts[parts.Length - 1];
                string tempS = userId.Clone().ToString();
                steamUsers.Add(new SteamPlayer { id3 = userId });

                //Try to get the usernames for each user, but do this on a background thread since we're dealing with the internet
                //LoadSteamUserName(tempS);
                Task.Factory.StartNew(() => LoadSteamUserName(tempS));
            }

            BindingSource source = new BindingSource();
            source.DataSource = steamUsers;
            steamUserComboBox.DataSource = source;

            //If there's only one item in the list, select it
            if(steamUserComboBox.Items.Count == 1)
            {
                steamUserComboBox.SelectedIndex = 0;
            }

            //If Steam is running, there will be a registry key to let us know which one of the users found above is logged in
            int currentLoggedInUser = (int) Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam\ActiveProcess", "ActiveUser", 0);
            if (currentLoggedInUser != 0)
            {
                foreach(SteamPlayer sp in steamUserComboBox.Items)
                {
                    if(sp.id3 == currentLoggedInUser.ToString())
                    {
                        steamUserComboBox.SelectedItem = sp;
                        break;
                    }
                }
            }

            //Maybe the user has run this before - check the settings
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.SteamUser))
            {
                foreach (SteamPlayer sp in steamUserComboBox.Items)
                {
                    if (sp.id3 == Properties.Settings.Default.SteamUser)
                    {
                        steamUserComboBox.SelectedItem = sp;
                        break;
                    }
                }
            }
        }

        private void steamLocationButton_Click(object sender, EventArgs e)
        {
            try
            {
                Debug("Showing steam location directory browser");
                DialogResult dr = folderBrowserDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Debug("\tUser chose " + folderBrowserDialog.SelectedPath);
                    if (!ValidateSteamLocation(folderBrowserDialog.SelectedPath))
                    {
                        MessageBox.Show("The selected folder doesn't appear to be your Steam installation, please select a different folder to continue");
                    }
                    else
                    {
                        steamLocationTextBox.Text = folderBrowserDialog.SelectedPath;

                        LoadSteamUser();
                    }
                }
            }
            catch(Exception ex)
            {
                GenericErrorHandler(ex);
            }
        }

        private void configFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                Debug("Showing config file picker");
                DialogResult dr = openFileDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Debug("\tUser chose " + openFileDialog.FileName);
                    configFileTextBox.Text = openFileDialog.FileName;
                    LoadConfigFile();
                }
            }
            catch(Exception ex)
            {
                GenericErrorHandler(ex);
            }
        }

        private void steamUserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateSteamUser(steamLocationTextBox.Text, ((SteamPlayer)steamUserComboBox.SelectedItem).id3))
                {
                    MessageBox.Show("The selected folder doesn't appear to be a valid user folder, please select a different user to continue");
                }
            }
            catch(Exception ex)
            {
                GenericErrorHandler(ex);
            }
        }

        private void importConfigButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateSteamLocation(steamLocationTextBox.Text))
                {
                    MessageBox.Show("It doesn't look like the selected folder is where Steam is installed. Select the correct folder and try importing again.");
                    return;
                }
                if (!ValidateSteamUser(steamLocationTextBox.Text, ((SteamPlayer)steamUserComboBox.SelectedItem).id3))
                {
                    MessageBox.Show("It doesn't look like the selected user is valid. Select your user in the drop down and try importing again.");
                    return;
                }
                if (loadedConfigFile == null)
                {
                    MessageBox.Show("No config file is loaded. Select a config file and try importing again.");
                }
                LoadShortcuts();
                ImportDialog dialog = new ImportDialog(this, Path.Combine(steamLocationTextBox.Text, "userdata" + Path.DirectorySeparatorChar + ((SteamPlayer)steamUserComboBox.SelectedItem).id3), loadedConfigFile, steamShortcuts);
                dialog.ShowDialog();
            }
            catch(Exception ex)
            {
                GenericErrorHandler(ex);
            }
        }

        private void LoadShortcuts()
        {
            steamShortcuts = new List<SteamShortcut>();
            if (!ValidateSteamLocation(steamLocationTextBox.Text) || !ValidateSteamUser(steamLocationTextBox.Text, ((SteamPlayer)steamUserComboBox.SelectedItem).id3))
            {
                return;
            }

            Debug("Attempting to load shortcuts");
            string pathToFile = Path.Combine(steamLocationTextBox.Text, "userdata" + Path.DirectorySeparatorChar + ((SteamPlayer)steamUserComboBox.SelectedItem).id3 + Path.DirectorySeparatorChar + "config" + Path.DirectorySeparatorChar + "shortcuts.vdf");
            Debug("\tPath to shortcuts file is " + pathToFile);

            if (!File.Exists(pathToFile))
            {
                Debug("\tNo shortcuts file exists");
                return;
            }

            Debug("\tOpening shortcuts file");
            using (FileStream fs = File.OpenRead(pathToFile))
            {
                byte[] allBytes = new byte[fs.Length];
                fs.Read(allBytes, 0, allBytes.Length);
                Debug("\tRead " + allBytes.Length + " bytes");

                int position = 0;
                for (int i = 0; i < allBytes.Length; i++)
                {
                    //We're looking for the first place where there are two 0's in a row
                    if (i == 0) continue;

                    if (allBytes[i] == 0 && allBytes[i - 1] == 0)
                    {
                        position = i;
                        break;
                    }
                }

                //Each entry is delimited by two 8's in a row
                List<byte[]> entries = new List<byte[]>();
                List<byte> thisEntry = new List<byte>();
                for (int i = position; i < allBytes.Length; i++)
                {
                    thisEntry.Add(allBytes[i]);
                    if (allBytes[i] == 8 && allBytes[i - 1] == 8)
                    {
                        if (thisEntry.Count > 2)
                        {
                            //The file itself is delimited with two 8's
                            entries.Add(thisEntry.ToArray());
                            thisEntry = new List<byte>();
                        }
                    }
                }

                Dictionary<string, Dictionary<string, string>> apps = new Dictionary<string, Dictionary<string, string>>();
                foreach (byte[] entry in entries)
                {
                    //Each field is delimited by 0 followed by 1, and the fields are strings
                    List<byte[]> fields = new List<byte[]>();
                    List<byte> thisField = new List<byte>();
                    position = 0;
                    while (entry[position] == 0) position++;

                    for (int i = position; i < entry.Length; i++)
                    {
                        if (entry[i] == 0 && entry[i + 1] == 1)
                        {
                            i = i + 1;
                            fields.Add(thisField.ToArray());
                            thisField = new List<byte>();
                        }
                        else
                        {
                            thisField.Add(entry[i]);
                        }
                    }

                    Dictionary<string, string> parsedFields = new Dictionary<string, string>();
                    foreach (byte[] field in fields)
                    {
                        string s = ASCIIEncoding.ASCII.GetString(field);
                        string[] parts = s.Split('\0');
                        if (parts.Length == 2)
                        {
                            parsedFields.Add(parts[0].ToLower(), parts[1]);
                        }
                    }

                    if (!parsedFields.ContainsKey("exe")) continue;

                    string exe = parsedFields["exe"];
                    string sha1Hash = CalculateSHA1(exe, Encoding.ASCII);
                    parsedFields.Add("sha1", sha1Hash.ToLower());

                    if (parsedFields.ContainsKey("appname"))
                    {
                        string key = parsedFields["appname"];
                        if(parsedFields.ContainsKey("exe"))
                        {
                            key += " (" + parsedFields["exe"] + ")";
                        }
                        if (!apps.ContainsKey(key))
                        {
                            apps.Add(key, parsedFields);
                        }
                    }
                }

                foreach (string key in apps.Keys)
                {
                    SteamShortcut shortcut = new SteamShortcut();
                    shortcut.Name = key;
                    shortcut.Path = apps[key]["exe"];
                    shortcut.SHA1 = apps[key]["sha1"];
                    steamShortcuts.Add(shortcut);
                }

                Debug("Found the following shortcuts:");
                foreach (var shortcut in steamShortcuts)
                {
                    Debug("\t" + shortcut.Name + ": " + shortcut.Path + " (" + shortcut.SHA1 + ")"); 
                }
            }
        }

        private string CalculateSHA1(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        }

        private void whatIsThisLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Steam supports multiple users per computer, so there may be multiple users listed here. If all that's showing are a bunch of numbers, you can figure out which user is yours by going to https://steamid.io/lookup and entering the numbers in the drop down.");
        }
    }
}

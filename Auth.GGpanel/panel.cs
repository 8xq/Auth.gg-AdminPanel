using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leaf.xNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auth.GGpanel
{
    public partial class panel : Form
    {
        //Auth key can be found here: https://auth.gg/dashboard/applications/settings.php 
        private static string AuthKey = ""; // Make sure you add auth key here
        Helper.Users users = new Helper.Users();
        Helper.Licences licence_ = new Helper.Licences();
        Helper.LicenceGenerator licenceGen = new Helper.LicenceGenerator();
        Helper.HWID hwid = new Helper.HWID();
        Helper.Info info = new Helper.Info();
        public panel()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Thread MainInfo = new Thread(GetMainInfo);
            MainInfo.Start();
        }
        #region display main stats (overview)
        private void GetMainInfo()
        {
            flatLabel2.Text = info.CountUsers(AuthKey);
            flatLabel3.Text = info.CountLicences(AuthKey);
            richTextBox1.Text = info.GrabInformation(AuthKey);
        }
        #endregion
        #region change user password
        private void flatButton3_Click(object sender, EventArgs e)
        {
            string username = flatTextBox3.Text;
            string password = flatTextBox2.Text;
            bool UsernameCheck = !string.IsNullOrEmpty(username);
            bool PasswordCheck = !string.IsNullOrEmpty(password);
            if(UsernameCheck && PasswordCheck == true)
            {
                richTextBox2.Text = "";
                Task.Factory.StartNew(() =>
                {
                    richTextBox2.Text = users.ChangePassword(username, password, AuthKey);
                });

            }
            else
            {
                MessageBox.Show("Please enter a username / password !", "Error - form input");
            }
        }
        #endregion
        #region grab user info
        private void flatButton1_Click(object sender, EventArgs e)
        {
            string username = flatTextBox1.Text;
            bool UsernameCheck = !string.IsNullOrEmpty(username);
            if(UsernameCheck == true)
            {
                richTextBox2.Text = "";
                Task.Factory.StartNew(() =>
                {
                    richTextBox2.Text = users.GrabUserInformation(username,AuthKey);
                });
            }
            else
            {
                MessageBox.Show("Please enter a username !", "Error - form input");
            }
        }
        #endregion
        #region delete user
        private void flatButton2_Click(object sender, EventArgs e)
        {
            string username = flatTextBox1.Text;
            bool UsernameCheck = !string.IsNullOrEmpty(username);
            if (UsernameCheck == true)
            {
                richTextBox2.Text = "";
                Task.Factory.StartNew(() =>
                {
                    richTextBox2.Text = users.DeleteUser(username, AuthKey);
                });
            }
            else
            {
                MessageBox.Show("Please enter a username !", "Error - form input");
            }
        }
        #endregion
        #region get licence info

        private void flatButton5_Click(object sender, EventArgs e)
        {
            string licence = flatTextBox4.Text;
            bool LicenceCheck = !string.IsNullOrEmpty(licence);
            if (LicenceCheck == true)
            {
                richTextBox3.Text = "";
                Task.Factory.StartNew(() =>
                {
                    richTextBox3.Text = licence_.GetLicenceInfo(licence, AuthKey);
                });
            }
            else
            {
                MessageBox.Show("Please enter a licence key !", "Error - form input");
            }
        }
        #endregion
        #region delete licence
        private void flatButton4_Click(object sender, EventArgs e)
        {
            string licence = flatTextBox4.Text;
            bool LicenceCheck = !string.IsNullOrEmpty(licence);
            if (LicenceCheck == true)
            {
                richTextBox3.Text = "";
                Task.Factory.StartNew(() =>
                {
                    richTextBox3.Text = licence_.DeleteLicence(licence, AuthKey);
                });
            }
            else
            {
                MessageBox.Show("Please enter a licence key !", "Error - form input");
            }
        }
        #endregion
        #region use licence
        private void flatButton7_Click(object sender, EventArgs e)
        {
            string licence = flatTextBox4.Text;
            bool LicenceCheck = !string.IsNullOrEmpty(licence);
            if (LicenceCheck == true)
            {
                richTextBox3.Text = "";
                Task.Factory.StartNew(() =>
                {
                    richTextBox3.Text = licence_.UseLicence(licence, AuthKey);
                });
            }
            else
            {
                MessageBox.Show("Please enter a licence key !", "Error - form input");
            }
        }
        #endregion
        #region unuse licence
        private void flatButton6_Click(object sender, EventArgs e)
        {
            string licence = flatTextBox4.Text;
            bool LicenceCheck = !string.IsNullOrEmpty(licence);
            if (LicenceCheck == true)
            {
                richTextBox3.Text = "";
                Task.Factory.StartNew(() =>
                {
                    richTextBox3.Text = licence_.UnuseLicence(licence, AuthKey);
                });
            }
            else
            {
                MessageBox.Show("Please enter a licence key !", "Error - form input");
            }
        }
        #endregion
        #region generate keys
        private void flatButton11_Click(object sender, EventArgs e)
        {
            string KeyDays = flatTextBox5.Text;
            string KeyAmount = flatTextBox6.Text;
            string KeyLevel = flatTextBox7.Text;
            bool KeyCheck = !string.IsNullOrEmpty(KeyDays);
            bool AmountCheck = !string.IsNullOrEmpty(KeyAmount);
            bool LevelCheck = !string.IsNullOrEmpty(KeyLevel);

            if (KeyCheck && AmountCheck && LevelCheck == true)
            {
                richTextBox4.Text = "";
                Task.Factory.StartNew(() =>
                {
                    richTextBox4.Text =  licenceGen.GenerateKeys(KeyDays , KeyAmount , KeyLevel, AuthKey);
                });
                flatButton8.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please ensure you have added amount of keys / day of keys !", "Error - form input");
            }
        }
        #endregion
        #region display keys only (parse json response)
        List<string> GeneratedKeys = new List<string>();
        private void flatButton8_Click(object sender, EventArgs e)
        {
            bool keys_text = !string.IsNullOrEmpty(richTextBox4.Text);
            if(keys_text == true)
            {
                if(GeneratedKeys.Count > 0)
                {
                    GeneratedKeys.Clear();
                }
                else
                {
                    string JSON_parse = richTextBox4.Text;
                    richTextBox4.Text = "";
                    JObject obj = JsonConvert.DeserializeObject<JObject>(JSON_parse);
                    var properties = obj.Properties();
                    foreach (var prop in properties)
                    {
                        string key = prop.Name;
                        object value = prop.Value;
                        GeneratedKeys.Add(value.ToString());
                        richTextBox4.Text = richTextBox4.Text + value  +"\n";
                    }
                    flatButton8.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please generate some keys first !", "Error - no keys to parse");
            }
        }
        #endregion
        #region get hwid information
        private void flatButton13_Click(object sender, EventArgs e)
        {
            string username = flatTextBox10.Text;
            bool UsernameCheck = !string.IsNullOrEmpty(username);
            if (UsernameCheck == true)
            {
                richTextBox5.Text = "";
                Task.Factory.StartNew(() =>
                {
                    richTextBox5.Text = hwid.HWIDinformation(username, AuthKey);
                });
            }
            else
            {
                MessageBox.Show("Please enter a licence !", "Error - form input");
            }
        }
        #endregion
        #region reset hwid
        private void flatButton12_Click(object sender, EventArgs e)
        {
            string username = flatTextBox10.Text;
            bool UsernameCheck = !string.IsNullOrEmpty(username);
            if (UsernameCheck == true)
            {
                richTextBox5.Text = "";
                Task.Factory.StartNew(() =>
                {
                    richTextBox5.Text = hwid.ResetHWID(username, AuthKey);
                });
            }
            else
            {
                MessageBox.Show("Please enter a licence !", "Error - form input");
            }
        }
        #endregion

        private void flatButton9_Click(object sender, EventArgs e)
        {
        }
    }
}

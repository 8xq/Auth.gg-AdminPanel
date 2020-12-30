using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.GGpanel.Helper
{
    class Users
    {
        public string ChangePassword(string username , string password,string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string ChangePassword = req.Post("https://developers.auth.gg/USERS/?type=changepw&authorization=" + AuthKey + "&user=" + username + "&password=" + password).ToString();
                return ChangePassword;
            }
            catch (Exception ex)
            {
                return "Error - " + ex;
            }
        }
        public string GrabUserInformation(string username,string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string GetUserInfo = req.Get("https://developers.auth.gg/USERS/?type=fetch&authorization=" + AuthKey + "&user=" + username).ToString();
                return GetUserInfo;
            }
            catch (Exception ex)
            {
                return "Error - " + ex;
            }
        }
        public string DeleteUser(string username, string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string DeleteUser = req.Get("https://developers.auth.gg/USERS/?type=delete&authorization=" + AuthKey + "&user=" + username).ToString();
                return DeleteUser;
            }
            catch (Exception ex)
            {
                return "Error - " + ex;
            }
        }
    }
}

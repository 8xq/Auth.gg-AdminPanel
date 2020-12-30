using Leaf.xNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.GGpanel.Helper
{
    class Info
    {
        public string CountUsers(string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string GetUserCount = req.Get("https://developers.auth.gg/USERS/?type=count&authorization=" + AuthKey).ToString();
                dynamic parse = JsonConvert.DeserializeObject(GetUserCount);
                string status = parse.status;
                if (status.ToLower() == "success")
                {
                    return parse.value;
                }
                else
                {
                    return "n/a";
                }
            }
            catch (Exception ex)
            {
                return "n/a";
            }
        }
        public string CountLicences(string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string GetLicenceCount = req.Get("https://developers.auth.gg/LICENSES/?type=count&authorization=" + AuthKey).ToString();
                dynamic parse = JsonConvert.DeserializeObject(GetLicenceCount);
                string status = parse.status;
                if (status.ToLower() == "success")
                {
                    return parse.value;
                }
                else
                {
                    return "n/a";
                }
            }
            catch (Exception ex)
            {
                return "n/a";
            }
        }
        // Grabs information and returns string
        public string GrabInformation(string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string Allusers = req.Get("https://developers.auth.gg/USERS/?type=fetchall&authorization=" + AuthKey).ToString();
                if (Allusers.Length > 0)
                {
                    return Allusers;
                }
                else
                {
                    return "No response detected";
                }
            }
            catch (Exception ex)
            {
                return "n/a - exception occured";
            }
        }
    }
}

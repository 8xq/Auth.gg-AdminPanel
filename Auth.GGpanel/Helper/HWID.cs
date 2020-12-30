using Leaf.xNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.GGpanel.Helper
{
    class HWID
    {
        public string HWIDinformation(string username, string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string LicenceInfo = req.Get("https://developers.auth.gg/HWID/?type=fetch&authorization="+AuthKey+"&user=" +username).ToString();
                return LicenceInfo;
            }
            catch (Exception ex)
            {
                return "Error - " + ex;
            }
        }
        public string ResetHWID(string username, string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string ResetLicence = req.Get("https://developers.auth.gg/HWID/?type=reset&authorization=" + AuthKey + "&user=" + username).ToString();
                return ResetLicence;
            }
            catch (Exception ex)
            {
                return "Error - " + ex;
            }
        }
    }
}

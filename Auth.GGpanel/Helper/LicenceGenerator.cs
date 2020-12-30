using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.GGpanel.Helper
{
    class LicenceGenerator
    {
        public string GenerateKeys(string KeyDays, string KeyAmount, string KeyLevel, string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string GenLicence = req.Get("https://developers.auth.gg/LICENSES/?type=generate&days=" + KeyDays + "&amount=" + KeyAmount + "&level=" + KeyLevel + "&authorization=" + AuthKey).ToString();
                return GenLicence;
            }
            catch (Exception ex)
            {
                return "n/a";
            }
        }
    }
}

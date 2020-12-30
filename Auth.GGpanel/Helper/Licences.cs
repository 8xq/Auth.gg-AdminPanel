using Leaf.xNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.GGpanel.Helper
{
    class Licences
    {
        public string GetLicenceInfo(string licence, string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string LicenceInfo = req.Get("https://developers.auth.gg/LICENSES/?type=fetch&authorization=" + AuthKey + "&license=" + licence).ToString();
                return LicenceInfo;
            }
            catch (Exception ex)
            {
                return "n/a";
            }
        }
        public string DeleteLicence(string licence, string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string DeleteLicence = req.Get("https://developers.auth.gg/LICENSES/?type=delete&authorization=" + AuthKey + "&license=" + licence).ToString();
                return DeleteLicence;
            }
            catch (Exception ex)
            {
                return "n/a";
            }
        }
        public string UnuseLicence(string licence, string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string UnuseLicence = req.Get("https://developers.auth.gg/LICENSES/?type=unuse&authorization=" + AuthKey + "&license=" + licence).ToString();
                return UnuseLicence;
            }
            catch (Exception ex)
            {
                return "n/a";
            }
        }
        public string UseLicence(string licence, string AuthKey)
        {
            try
            {
                HttpRequest req = new HttpRequest();
                string UseLicence = req.Get("https://developers.auth.gg/LICENSES/?type=use&authorization=" + AuthKey + "&license=" + licence).ToString();
                return UseLicence;
            }
            catch (Exception ex)
            {
                return "n/a";
            }
        }
    }
}

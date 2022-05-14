using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class Urls
    {
        static public string PM { get; set; }
        static public string Teacher { get; set; }
        static public string Theme { get; set; }

        public void RunUrl()
        {
            PM = "http://127.0.0.1:8000/PM/";
            Teacher = "http://127.0.0.1:8000/Teacher/";
            Theme = "http://127.0.0.1:8000/Themes/";
        }
        
    }
}
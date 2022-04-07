using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class Urls
    {
        public string PM { get; set; }

        public void RunUrl()
        {
            PM = "http://127.0.0.1:8000/PM/";
        }
        
    }
}
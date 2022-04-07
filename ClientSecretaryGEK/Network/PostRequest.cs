using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    internal class PostRequest
    {
        HttpWebRequest _request;
        string _adress;

        public string Response { get; set; }

        public PostRequest(string address)
        {
            _adress = address;
        }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress);
            _request.Method = "POST";


            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd();

            }
            catch (Exception ex)
            {

            }

        }
    }
}

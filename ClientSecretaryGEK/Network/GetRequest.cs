using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ClientSecretaryGEK.Network
{
    public class GetRequest
    {
        HttpWebRequest _request;
        string _adress;

        public string Response { get; set; }

        public GetRequest(string address)
        {
            _adress = address;
        }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress);
            _request.Method = "GET";


            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd();

            } catch (Exception ex)
            {

            }

        }
    }
}

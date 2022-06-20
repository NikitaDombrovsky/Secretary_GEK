using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class DeleteRequest
    {
        HttpWebRequest _request;
        string _adress;
        string Token;

        public string Response { get; set; }

        public DeleteRequest(string address, string Token_)
        {
            _adress = address;
            Token = Token_;
        }
        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress);
            _request.Method = "DELETE";
            _request.Headers["Authorization"] = Token;

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

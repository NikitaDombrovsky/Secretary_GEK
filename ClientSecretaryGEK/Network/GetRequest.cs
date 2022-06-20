using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientSecretaryGEK.Network
{
    internal class GetRequest
    {
        HttpWebRequest _request;
        string _adress;
        string _Token;

        public string Response { get; set; }

        public GetRequest(string address, string Token)
        {
            _adress = address;
            _Token = Token;
        }

        public void RunALL()
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress);
            _request.Method = "GET";
            _request.Headers["Authorization"] = _Token;

            try
            {
                var httpResponse = (HttpWebResponse)_request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Response = result;
                }
            }
            catch (Exception ex)
            {

            }

        }
        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress);
            _request.Method = "GET";
            _request.Headers["Authorization"] = _Token;

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                //return;
            }

        }

    }
}

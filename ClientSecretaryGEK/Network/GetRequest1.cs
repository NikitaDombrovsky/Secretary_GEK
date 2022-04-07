using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    internal class GetRequest1
    {
        HttpWebRequest _request;
        string _adress;

        public string Response { get; set; }

        public GetRequest1(string address)
        {
            _adress = address;
        }

        public void RunALL()
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress);
            _request.Method = "GET";

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

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
       // string _index;
       // string _name;
        string _url;
        string _data;
        string _method;

        public string Response { get; set; }

        public PostRequest(string address, string data, string url, string method )
        {
            _adress = address;
            _data = data;
            _url = url;
            _method = method;
        }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress);
            _request.Method = _method;
            _request.Headers["Authorization"] = "Basic QWRtaW46MTIzNDU2QWRtaW4=";
            
            _request.ContentType = "application/json";
            /*
            var data = $@"{{
                ""index_professional_module"": ""{index}"",
                ""name_professional_module"": ""{name}""
            }}";
            */


            try
            {
                using (var streamWriter = new StreamWriter(_request.GetRequestStream()))
                {
                    streamWriter.Write(_data);
                }
                HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
                using (var streamReader = new StreamReader(_response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                //HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                //var stream = response.GetResponseStream();
                //if (stream != null) Response = new StreamReader(stream).ReadToEnd();

            }
            catch (Exception ex)
            {

            }

        }
    }
}

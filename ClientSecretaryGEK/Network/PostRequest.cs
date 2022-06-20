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
    internal class PostRequest
    {
        HttpWebRequest _request;
        string _adress;
        string Token;
        string _data;
        string _method;
        Errors errors = new Errors();
        public string Response { get; set; }

        public PostRequest(string address, string data, string Token_, string method )
        {
            _adress = address;
            _data = data;
            Token = Token_;
            _method = method;
        }

        
        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress);
            _request.Method = _method;
            //_request.Headers["Authorization"] = "Basic QWRtaW46MTIzNDU2QWRtaW4=";            
            _request.Headers["Authorization"] = Token;        
            _request.ContentType = "application/json";

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
                    Response = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(errors.Error(ex));
                //return;
            }

        }
    }
}

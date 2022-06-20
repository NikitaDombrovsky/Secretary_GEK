using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientSecretaryGEK.Network.Auth
{
    public class LoginCreate
    {
        public string Create(string token, string method, string username, string password, string url)
        {
            string obj = "";
            try
            {
                var data = $@"{{
                ""username"": ""{username}"",
                ""password"": ""{password}""
            }}";
                var request = new PostRequest(url, data, token, method);
                request.Run();
                var response = request.Response;
                var objResponse = JsonConvert.DeserializeObject<AuthTable>(response);

                return obj = objResponse.Токен.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                //return;
                return obj;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.PD
{
    public class PDCreate
    {
        public void Create(string token, string method, string surname, string name, string patronymic, string url)
        {
            var data = $@"{{
                ""surname"": ""{surname}"",
                ""name"": ""{name}"",
                ""patronymic"": ""{patronymic}""
            }}";
            var request = new PostRequest(url, data, token, method);
            request.Run();
        }
    }
}

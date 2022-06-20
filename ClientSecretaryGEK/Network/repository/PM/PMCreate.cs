using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.repository.PM
{
    internal class PMCreate
    {
        public void Create(string token, string method, string index, string name, string url)
        {
            var data = $@"{{
                ""index_professional_module"": ""{index}"",
                ""name_professional_module"": ""{name}""
            }}";
            var request = new PostRequest(url, data, token, method);
            request.Run();
        }
    }

}

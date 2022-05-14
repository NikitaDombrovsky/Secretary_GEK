using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.repository.net.PM
{
    internal class PMTableCreateServiceIMPL: Service<PMTableCreate>
    {
        public PMTableCreate Create()
        {
            string method = "POST";
            string index =
            var data = $@"{{
                ""index_professional_module"": ""{index}"",
                ""name_professional_module"": ""{name}""
            }}";
            var request = new PostRequest(Urls.PM, data, token, method);
            request.Run();


        }
    }
}

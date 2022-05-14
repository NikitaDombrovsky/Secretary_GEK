using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.repository.net
{
    internal class PMTableServiceIMPL : Service<PMTable>
    {
        public List<PMTable> Start()
        {
            var request = new GetRequest1(Urls.PM);
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<PMTable>>(response);
            return (List<PMTable>)objResponse;
//            throw new NotImplementedException();
        }
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

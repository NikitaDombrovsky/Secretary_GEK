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

    }
}

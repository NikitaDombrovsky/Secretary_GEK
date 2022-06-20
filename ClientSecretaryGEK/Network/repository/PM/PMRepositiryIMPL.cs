//using ClientSecretaryGEK.Network.repository.net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.repository
{
    internal class PMRepositiryIMPL : PMRepository
    {
       // Service<PMTable> service;
       // PMTable service;
        public List<PMTable> Execute()
        {
            var request = new GetRequest(Urls.PM, Urls.Token); // Токен
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<PMTable>>(response);
            return objResponse;
            //return service.Start();
        }
       // public PMRepositiryIMPL(Service<PMTable> service) { this.service = service; }
        public PMRepositiryIMPL() {  }
/*        public void _Create(string token, string method, string index, string name, string urlPM)
        {
            service.Create(token, method,index,name, urlPM);
        }*/


    }
}

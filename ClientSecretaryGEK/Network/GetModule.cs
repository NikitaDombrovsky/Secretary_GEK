using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientSecretaryGEK.Network
{
    public class GetModule
    {
        int n = 1;
        int i = 1;
        string url = "http://127.0.0.1:8000/PM/";
        /*
        public GetModule(string url, List<> list)
        {
            this.url = url;
            this.list = list;
        }
        public void _GetModule()
        {
            while (n == 1)
            {
                var Data = (i + "/");
                var request = new GetRequest($"{url}{Data}");
                request.Run();
                var response = request.Response;
                if (response == null)
                {
                    n = 0;
                    break;
                }
                //PMTable myDeserializedClass1 = JsonConvert.DeserializeObject<PMTable>(response); //PM
                var resuxlt = JsonConvert.DeserializeObject<PMTable>(response); //PM
                list.Add(new PMTable(result.Id, result.index_professional_module, result.name_professional_module));
                i++;
            }
            
        }*/
    }
}

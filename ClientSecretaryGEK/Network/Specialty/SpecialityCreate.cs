using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.Specialty
{
    public class SpecialityCreate
    {
        public void Create(string token, string method, string name_speciality, string code_speciality, string url)
        {
            var data = $@"{{
                ""name_speciality"": ""{name_speciality}"",
                ""code_speciality"": ""{code_speciality}""
            }}";
            var request = new PostRequest(url, data, token, method);
            request.Run();
        }
    }
}

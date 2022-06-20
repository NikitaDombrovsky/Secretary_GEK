using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.Group
{
    public class GroupCreate
    {
        public void Create(string token, string method, string name_group, string id_speciality, string urlTeacher)
        {
            //string DateString = date.ToString("yyyy-MM-dd");
            var data = $@"{{
                ""name_group"": ""{name_group}"",
                ""id_speciality"": ""{id_speciality}""
            }}";
            var request = new PostRequest(urlTeacher, data, token, method);
            request.Run();
        }
    }
}

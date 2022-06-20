using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.repository.Teacher
{
    internal class TeacherCreate
    {
        public void Create(string token, string method,string Post ,DateTime date, string id_pd, string urlTeacher)
        {
            string DateString = date.ToString("yyyy-MM-dd");
            var data = $@"{{
                ""post"": ""{Post}"",
                ""date_of_birth"": ""{DateString}"",
                ""id_pd"": ""{id_pd}""
            }}";
            var request = new PostRequest(urlTeacher, data, token, method);
            request.Run();
        }
    }
}

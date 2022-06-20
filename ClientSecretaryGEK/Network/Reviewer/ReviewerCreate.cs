using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.Reviewer
{
    public class ReviewerCreate
    {
        public void Create(string token, string method, string Post, string workplace, string id_speciality, string id_pd, string url)
        {
            //string DateString = date.ToString("yyyy-MM-dd");
            var data = $@"{{
                ""post"": ""{Post}"",
                ""workplace"": ""{workplace}"",
                ""id_speciality"": ""{id_speciality}"",
                ""id_pd"": ""{id_pd}""
            }}";
            var request = new PostRequest(url, data, token, method);
            request.Run();
        }
    }
}

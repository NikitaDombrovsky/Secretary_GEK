using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.repository.Theme
{
    public class ThemeCreate
    {
        public void Create(string token, string method, string name_theme, string id_professional_module, string id_teacher, string url)
        {
            var data = $@"{{
                ""name_theme"": ""{name_theme}"",
                ""id_professional_module"": ""{id_professional_module}"",
                ""id_teacher"": ""{id_teacher}""
            }}";
            var request = new PostRequest(url, data, token, method);
            request.Run();
        }
    }
}

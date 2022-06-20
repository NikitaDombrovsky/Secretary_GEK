using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.Auth
{
    public class AuthTable
    {
        public AuthTable(string auth_token)
        {
            this.Токен = auth_token;
        }
        public string Токен { get; set; }
    }
}

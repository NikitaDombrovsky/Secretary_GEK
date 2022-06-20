using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.Auth
{
    public class LoginTable
    {
        public LoginTable(string username, string password)
        {
            this.Логин = username;
            this.Пароль = password;
        }
        public string Логин { get; set; }
        public string Пароль { get; set; }
    }
    public class LoginTableToken
    {
        public LoginTableToken(string email, int id, string username)
        {
            this.Почта = email;
            this.ID = id;
            this.Логин = username;
        }
        public string Логин { get; set; }
        public int ID { get; set; }
        public string Почта { get; set; }
    }
    /*
    {
    "email": "",
    "id": 1,
    "username": "Test4"
}
     */
}

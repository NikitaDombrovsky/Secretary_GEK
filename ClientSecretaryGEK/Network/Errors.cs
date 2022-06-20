using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class Errors
    {
        public string Error(Exception ex)
        {


            string text = ex.Message;
            if (text == "Удаленный сервер возвратил ошибку: (400) Недопустимый запрос.")
            {
                return text = "Неверный логин или пароль";
            }
            else
            {
                return text;
            }

        }
    }
}

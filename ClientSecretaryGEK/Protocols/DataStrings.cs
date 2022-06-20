using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Protocols
{
    public class DataStrings
    {
        static public string[] Protocol_GEK_Main { get; set; }
        public void RunProtocols()
        {
            Protocol_GEK_Main = new string[] 
            {   "№ п.п.",  
                "Фамилия, Имя, Отчество Студента", 
                "Средний балл", 
                "Оценка руководителя", 
                "Отзыв заказчика", 
                "Оценка потрфолио", 
                "Средняя оценка доклада",
                "Средняя оценка демонстрационного экзамена",
                "Средняя оценка ответов на вопросы",
                "Итоговая оценка защиты ВКР"
            };
        }
    }
}

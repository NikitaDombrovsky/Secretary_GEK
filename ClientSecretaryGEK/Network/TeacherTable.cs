using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class TeacherTable
    {
        public TeacherTable(int Id, string surname, string name, string patronymic, DateTime? date_of_birth) //
        {
            this.Id = Id;
            this.Имя = surname;
            this.Фамилия = name;
            this.Отчество = patronymic;
            this.Дата_Рождения = date_of_birth;
        }
        public int Id { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Отчество { get; set; }
        public DateTime? Дата_Рождения { get; set; }
    }
}

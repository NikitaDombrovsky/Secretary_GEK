using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class TeacherTable
    {
        public TeacherTable(int Id,string post ,DateTime? date_of_birth, string id_pd) //
        {
            this.Id = Id;
            this.Должность = post;
            this.Дата_Рождения = date_of_birth;
            this.Id_PD = id_pd;
        }
        public int Id { get; set; }
        public string Должность { get; set; }
        public DateTime? Дата_Рождения { get; set; }
        public string Id_PD { get; set; }
    }
    public class TeacherTableALL
    {
        public TeacherTableALL(int Id, string surname, string name, string patronymic, string post, DateTime? date_of_birth) //
        {
            this.Id = Id;
            this.Фамилия = surname;
            this.Имя = name;
            this.Отчество = patronymic;
            this.Должность = post;
            this.Дата_Рождения = date_of_birth;
        }
        public int Id { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Должность { get; set; }
        public DateTime? Дата_Рождения { get; set; }
    }
}

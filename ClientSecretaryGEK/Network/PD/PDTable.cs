using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class PDTable
    {
        public PDTable(int Id, string surname, string name, string patronymic)
        {
            this.Id = Id;
            this.Фамилия = surname;
            this.Имя = name;
            this.Отчество = patronymic;
        }
        public int Id { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
    }
}

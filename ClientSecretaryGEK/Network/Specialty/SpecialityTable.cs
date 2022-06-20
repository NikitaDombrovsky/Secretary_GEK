using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class SpecialityTable
    {
        public SpecialityTable(int Id, string name_speciality, string code_speciality)
        {
            this.Id = Id;
            this.Название_Специальности = name_speciality;
            this.Номер_Специальности = code_speciality;
        }
        public int Id { get; set; }
        public string Название_Специальности { get; set; }
        public string Номер_Специальности { get; set; }
    }
}

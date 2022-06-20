using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class ThemeTable
    {
        public ThemeTable(int Id, string name_theme, string id_professional_module, string id_teacher) 
        {
            this.Id = Id;
            this.Название_Темы = name_theme;
            this.ID_ПМ = id_professional_module;
            this.ID_Преподавателя = id_teacher;
        }
        public int Id { get; set; }
        public string Название_Темы { get; set; }
        public string ID_ПМ { get; set; }
        public string ID_Преподавателя { get; set; }
    }
    public class ThemeTableALL
    {
        public ThemeTableALL(int Id, string surname, string name, string patronymic, string name_theme, string professional_module) 
        {
            this.Id = Id;
            this.Фамилия = surname;
            this.Имя = name;
            this.Отчество = patronymic;
            this.Название_Темы = name_theme;
            this.ПМ = professional_module;
        }
        public int Id { get; set; }
        public string Название_Темы { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string ПМ { get; set; }
    }
}

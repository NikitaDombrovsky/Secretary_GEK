using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class ThemeTable
    {
        public ThemeTable(int Id, string name_theme, string id_professional_module, string id_teacher) //
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
}

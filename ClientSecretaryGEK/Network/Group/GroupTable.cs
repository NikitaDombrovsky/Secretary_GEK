using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.Group
{
    public class GroupTable
    {
        public GroupTable(int Id, string name_group, string id_speciality)
        {
            this.Id = Id;
            this.Название_Группы = name_group;
            this.ID_SP = id_speciality;
        }
        public int Id { get; set; }
        public string Название_Группы { get; set; }
        public string ID_SP { get; set; }
    }
    public class GroupTableALL
    {
        public GroupTableALL(int Id, string name_group, string name_sp)
        {
            this.Id = Id;
            this.Название_Группы = name_group;
            this.Название_Специальности = name_sp;
        }
        public int Id { get; set; }
        public string Название_Группы { get; set; }
        public string Название_Специальности { get; set; }
    }
}

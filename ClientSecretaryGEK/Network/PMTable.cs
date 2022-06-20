using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class PMTable
    {
        public PMTable(int Id, string index_professional_module, string name_professional_module)
        {
            this.Id = Id;
            this.Индекс_ПМ = index_professional_module;
            this.Название_ПМ = name_professional_module;
        }
        public int Id { get; set; }
        public string Индекс_ПМ { get; set; }
        public string Название_ПМ { get; set; }
    }
    public class PMTableMain
    {
        public PMTableMain(string index_professional_module, string name_professional_module) //
        {
            this.index_professional_module = index_professional_module;
            this.name_professional_module = name_professional_module;
        }
        public string index_professional_module { get; set; }
        public string name_professional_module { get; set; }
    }
    // Удаляй
    public class PMTableCreate
    {
        public PMTableCreate(string token, string method, string index, string name)
        {
            this.token = token;
            this.method = method;
            this.index = index;
            this.name = name;
        }

        public string token { get; set; }
        public string method { get; set; }
        public string index { get; set; }
        public string name { get; set; }

    }
}

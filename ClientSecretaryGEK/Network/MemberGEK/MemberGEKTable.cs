using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.MemberGEK
{
    public class MemberGEKTable
    {
        public MemberGEKTable(int Id, string post, string workplace, string id_speciality, string id_pd)
        {
            this.Id = Id;
            this.Должность = post;
            this.МестоРаботы = workplace;
            this.Id_Speciality = id_speciality;
            this.Id_PD = id_pd;
        }
        public int Id { get; set; }
        public string Должность { get; set; }
        public string МестоРаботы { get; set; }
        public string Id_Speciality { get; set; }
        public string Id_PD { get; set; }
    }
    public class MemberGEKTableALL
    {
        public MemberGEKTableALL(int Id, string surname, string name, string patronymic, string post, string workplace, string name_speciality)
        {
            this.Id = Id;
            this.Фамилия = surname;
            this.Имя = name;
            this.Отчество = patronymic;
            this.Должность = post;
            this.МестоРаботы = workplace;
            this.Название_Специальности = name_speciality;
        }
        public int Id { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Должность { get; set; }
        public string МестоРаботы { get; set; }
        public string Название_Специальности { get; set; }
    }
    public class MemberGEKTableProtocol
    {
        public MemberGEKTableProtocol(int Id, string surname, string name, string patronymic)
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

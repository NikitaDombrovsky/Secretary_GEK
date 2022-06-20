using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.Student
{
    public class StudentTable
    {
        public StudentTable(int Id, string average_grade, string surname, string name, string patronymic,  string id_group, DateTime? date_of_birth, string id_teacher, string id_theme, DateTime? date_meetings_gek, string reviewer_score, string supervisor_score) //  'id', 'average_grade', 'id_group', 'date_of_birth', 'id_teacher','id_theme','date_meetings_gek', 'reviewer_score', 'supervisor_score')
        {
            this.Id = Id;
            this.Фамилия = surname;
            this.Имя = name;
            this.Отчество = patronymic;
            this.Средняя_оценка = average_grade;
            this.Группа = id_group;
            this.Дата_рождения = date_of_birth;
            this.Преподаватель = id_teacher;
            this.Темы = id_theme;
            this.Дата_Заседания = date_meetings_gek;
            this.Оценка_Рецензента = reviewer_score;
            this.Оценка_Руководителя = supervisor_score;
        }
        public int Id { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Средняя_оценка { get; set; }
        public string Группа { get; set; }
        public DateTime? Дата_рождения { get; set; }
        public string Преподаватель { get; set; }
        public string Темы { get; set; }
        public DateTime? Дата_Заседания { get; set; }
        public string Оценка_Рецензента { get; set; }
        public string Оценка_Руководителя { get; set; }
    }
    public class StudentTableALL
    {
        public StudentTableALL(int Id,  string surname, string name, string patronymic, string average_grade, string group, DateTime? date_of_birth, string theme, DateTime? date_meetings_gek, string reviewer_score, string supervisor_score)
        {
            this.Id = Id;
            this.Фамилия = surname;
            this.Имя = name;
            this.Отчество = patronymic;
            this.Средняя_оценка = average_grade;
            this.Группа = group;
            this.Дата_рождения = date_of_birth;
            //this.Фамилия_ПР = teacher;
            this.Название_Темы = theme;
            this.Дата_Заседания = date_meetings_gek;
            this.Оценка_Рецензента = reviewer_score;
            this.Оценка_Руководителя = supervisor_score;
        }
        public int Id { get; set; }
        public string Средняя_оценка { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Группа { get; set; }
        public DateTime? Дата_рождения { get; set; }
        //public string Фамилия_ПР { get; set; }
        public string Название_Темы { get; set; }
        public DateTime? Дата_Заседания { get; set; }
        public string Оценка_Рецензента { get; set; }
        public string Оценка_Руководителя { get; set; }
    }
    public class StudentTableProtocols
    {
        public StudentTableProtocols(int Id, string surname, string name, string patronymic, string speciality, string theme, DateTime? date_meetings_gek)
        {
            this.Id = Id;
            this.Фамилия = surname;
            this.Имя = name;
            this.Отчество = patronymic;
            this.Специальность = speciality;
            this.Тема = theme;
            this.Дата_Заседания = date_meetings_gek;
        }
        public int Id { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Специальность { get; set; }
        public string Тема { get; set; }
        public DateTime? Дата_Заседания { get; set; }
    }
}

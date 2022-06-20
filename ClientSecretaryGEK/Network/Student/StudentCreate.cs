using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network.Student
{
    public class StudentCreate
    {
        public void Create(string token, string method, string surname, string name, string patronymic, string average_grade,string id_group, DateTime date_of_birth, string id_teacher, string id_theme, DateTime date_meetings_gek, string reviewer_score, string supervisor_score, string url)
        {
            string date_of_birth_ = date_of_birth.ToString("yyyy-MM-dd");
            string date_meetings_gek_ = date_meetings_gek.ToString("yyyy-MM-dd");
            var data = $@"{{
                ""surname"": ""{surname}"",
                ""name"": ""{name}"",
                ""patronymic"": ""{patronymic}"",
                ""average_grade"": ""{average_grade}"",
                ""id_group"": ""{id_group}"",
                ""date_of_birth"": ""{date_of_birth_}"",
                ""id_teacher"": ""{id_teacher}"",
                ""id_theme"": ""{id_theme}"",
                ""date_meetings_gek"": ""{date_meetings_gek_}"",
                ""reviewer_score"": ""{reviewer_score}"",
                ""supervisor_score"": ""{supervisor_score}""
            }}";
            //var request = new PostRequest(url, data, token, method);
            //request.Run();

/*            token = "Token 1dbdec5bd6f26846392b2993a79d19e5be7acb1e";
            method = "POST";
            surname = "t";
            name = "t";
            patronymic = "t";
            average_grade = null;
            id_group = "http://sleepy-brushlands-99972.herokuapp.com/Group/1/";
            date_of_birth_ = "2022-05-26";
            id_teacher = "http://sleepy-brushlands-99972.herokuapp.com/Teacher/1/";
            id_theme = "http://sleepy-brushlands-99972.herokuapp.com/Themes/4/";
            date_meetings_gek_ = "2022-05-26";
            reviewer_score = "1";
            supervisor_score = "1";
            //float average = Convert.ToSingle(average_grade);
            var data1 = $@"{{
                ""surname"": ""{surname}"",
                ""name"": ""{name}"",
                ""patronymic"": ""{patronymic}"",
                ""average_grade"": ""{average_grade}"",
                ""id_group"": ""{id_group}"",
                ""date_of_birth"": ""{date_of_birth_}"",
                ""id_teacher"": ""{id_teacher}"",
                ""id_theme"": ""{id_theme}"",
                ""date_meetings_gek"": ""{date_meetings_gek_}"",
                ""reviewer_score"": ""{reviewer_score}"",
                ""supervisor_score"": ""{supervisor_score}"",
            }}";*/
            /*
                     "id": 6,
        "surname": "t",
        "name": "t",
        "patronymic": "t",
        "average_grade": null,
        "id_group": "http://sleepy-brushlands-99972.herokuapp.com/Group/1/",
        "date_of_birth": "2022-05-26",
        "id_teacher": "http://sleepy-brushlands-99972.herokuapp.com/Teacher/1/",
        "id_theme": "http://sleepy-brushlands-99972.herokuapp.com/Themes/4/",
        "date_meetings_gek": "2022-05-26",
        "reviewer_score": "1",
        "supervisor_score": "1"
             */
            var request = new PostRequest(url, data, token, method);
            request.Run();
        }
    }
}

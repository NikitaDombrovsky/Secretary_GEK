using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSecretaryGEK.Network
{
    public class Urls
    {
        static public string Login { get; set; }
        static public string AuthToken { get; set; }
        static public string ApiUrl { get; set; }
        static public string Consultation { get; set; }
        static public string Student { get; set; }
        static public string Reviewer { get; set; }
        static public string Group { get; set; }
        static public string MemberGek { get; set; }
        static public string MethodPost { get; set; }
        static public string MethodPut { get; set; }
        static public string Token { get; set; }
        static public string PM { get; set; }
        static public string Teacher { get; set; }
        static public string Theme { get; set; }
        static public string PD { get; set; }
        static public string Speciality { get; set; }

        public void RunUrl()
        {
            MethodPost = "POST";
            MethodPut = "PUT";
            //Token = "Token 1dbdec5bd6f26846392b2993a79d19e5be7acb1e";

            //ApiUrl = "http://127.0.0.1:8000/";
            ApiUrl = "http://sleepy-brushlands-99972.herokuapp.com/";
            // PM = "http://127.0.0.1:8000/PM/";


            Login = ApiUrl + "auth/token/login/";
            AuthToken = ApiUrl + "auth/users/me/";
            Teacher = ApiUrl + "Teacher/"; //"http://127.0.0.1:8000/Teacher/";
            Consultation = ApiUrl + "Consultation/";
            Theme = ApiUrl + "Themes/";  //"http://127.0.0.1:8000/Themes/";
            Student = ApiUrl + "Student/";
            PD = ApiUrl + "PersonData/"; //"http://127.0.0.1:8000/";
            Reviewer = ApiUrl + "Reviewer/";
            PM = ApiUrl + "PM/";
            Speciality = ApiUrl + "Speciality/"; //"http://127.0.0.1:8000/Speciality/";
            Group = ApiUrl + "Group/";
            MemberGek = ApiUrl + "MemberGek/"; 

        }

    }
}
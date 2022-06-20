using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientSecretaryGEK.Menu
{
    /// <summary>
    /// Логика взаимодействия для LoginWindows.xaml
    /// </summary>
    public partial class LoginWindows : Window
    {
        List<LoginTableToken> ListMain = new List<LoginTableToken>();
        public string Token = "";
        public int role = 0;
        Errors errors_ = new Errors();
        int s = 0;
        public LoginWindows()
        {
            InitializeComponent();
            var url = new Urls();
            url.RunUrl();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        { 
                string username = TextLogin.Text;
            string password = TextPassword.Password;
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(username))
                errors.AppendLine("Введите Логин");
            if (string.IsNullOrWhiteSpace(password))
                errors.AppendLine("Введите Пароль");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

                LoginCreate create = new LoginCreate();

                string Token_ = create.Create(Token, Urls.MethodPost, username, password, Urls.Login);
                if (Token_ != "")
                {
                    Token = Token_;
                    s = 1;
                    var objResponse = JsonConvert.DeserializeObject<LoginTableToken>(Change());

                    string[] st_gp = objResponse.Почта.Split(new char[] { '@' });
                    if (st_gp[0] == "0")
                    {
                        role = 0;

                    }
                    if (st_gp[0] == "1")
                    {
                        role = 1;

                    }
                    else
                    {
                        role = 0;

                    }
                    this.Close();
                }

        }
        public string Change()
        {
                var request = new GetRequest(Urls.AuthToken, "Token " + Token);
                request.Run();
                string response = request.Response;
                return response;      
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (s == 0)
            {
               Application.Current.Shutdown();

            }
        }
    }
}


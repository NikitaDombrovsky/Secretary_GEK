using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.repository;
using ClientSecretaryGEK.Network.repository.PM;
//using ClientSecretaryGEK.Network.repository.net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientSecretaryGEK.Diploma.PM
{
    /// <summary>
    /// Логика взаимодействия для PMAddPage.xaml
    /// </summary>
    public partial class PMAddPage : Page
    {
        //string urlPM;
        int change_method;
        int id;
        string method;
        string Token = "";
        int role;
        Errors errors = new Errors();
        public PMAddPage(PMTable _selecteditem, string Token_, int role_)
        {
            InitializeComponent();
            //urlPM = Urls.PM;
            Token = Token_;
            role = role_;
            change_method = 0;
            if (_selecteditem != null)
            {
                change_method = 1;
                Index_PM.Text = _selecteditem.Индекс_ПМ;
                Name_PM.Text = _selecteditem.Название_ПМ;
                id = _selecteditem.Id;
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrWhiteSpace(Index_PM.Text))
                    errors.AppendLine("Укажите Индекс");
                if (string.IsNullOrWhiteSpace(Name_PM.Text))
                    errors.AppendLine("Укажите Название");
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                string index = Index_PM.Text;
                string name = Name_PM.Text;
                PMCreate create = new PMCreate();
                //string token = "Basic QWRtaW46MTIzNDU2QWRtaW4=";

                if (change_method == 0)
                {
                    method = "POST";
                    create.Create(Token, method, index, name, Urls.PM);
                    // Create(token, method, index, name, Urls.PM);
                    MessageBox.Show("Добавление успешно!");
                }
                else
                {
                    string _urlPM = Urls.PM + id + "/";
                    method = "PUT";
                    create.Create(Token, method, index, name, _urlPM);
                    //Create(token, method, index, name, Urls.PM);
                    MessageBox.Show("Изменение успешно!");
                }
                App.ParentWindowRef.ParentFrame.Navigate(new PMPage(Token, role));
            }
            catch (Exception ex)
            {
                MessageBox.Show(errors.Error(ex));
            }
        }
/*        public void Create(string token, string method, string index, string name, string urlPM)
        {
            var data = $@"{{
                ""id"": ""{id}""
                ""index_professional_module"": ""{index}"",
                ""name_professional_module"": ""{name}""
            }}";
            var request = new PostRequest(urlPM, data, token, method);
            request.Run();
        }*/
    }
}

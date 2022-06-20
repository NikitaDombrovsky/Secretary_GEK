using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.repository.Theme;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientSecretaryGEK.Diploma.Theme
{
    /// <summary>
    /// Логика взаимодействия для ThemeAddPage.xaml
    /// </summary>
    public partial class ThemeAddPage : Page
    {
        int change_method;
        int id;
        //string method;
        List<TeacherTableALL> ListTC = new List<TeacherTableALL>();
        List<PMTable> ListPM = new List<PMTable>();
        string Token = "";
        int role;
        Errors errors = new Errors();
        public ThemeAddPage(ThemeTableALL _selecteditem, string Token_, int role_)
        {
            InitializeComponent();
            Token = Token_;
            role = role_;
            change_method = 0;
            if (_selecteditem != null)
            {
                change_method = 1;
                Name_PM.Text = _selecteditem.Название_Темы;
                id = _selecteditem.Id;
            }

            ChangeTC();
            ChangePM();
            ComboPM.ItemsSource = ListPM;
            ComboTeacher.ItemsSource = ListTC;
        }
        public void ChangePM()
        {
            var request = new GetRequest(Urls.PM, Token);
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<PMTable>>(response);
            ListPM = objResponse;
        }
        public string Comm(string url)
        {
            var request = new GetRequest(url, Token);
            request.Run();
            string response = request.Response;
            return response;
        }
        public void ChangeTC()
        {
            var request = new GetRequest(Urls.Teacher, Token);
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<TeacherTable>>(response);
            for (int i = 0; i < objResponse.Count; i++)
            {
                var res = objResponse[i];
                var res1 = JsonConvert.DeserializeObject<PDTable>(Comm(res.Id_PD));
                ListTC.Add(new TeacherTableALL(res.Id, res1.Фамилия, res1.Имя, res1.Отчество, res.Должность, res.Дата_Рождения));
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrWhiteSpace(Name_PM.Text))
                    errors.AppendLine("Укажите Название");
                if (string.IsNullOrWhiteSpace(ComboPM.Text))
                    errors.AppendLine("Укажите Должность");
                if (string.IsNullOrWhiteSpace(ComboTeacher.Text))
                    errors.AppendLine("Укажите Персональные данные");
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                ThemeCreate create = new ThemeCreate();
                var str2 = (PMTable)ComboPM.SelectedItem;

                var str3 = (TeacherTableALL)ComboTeacher.SelectedItem;
                string name = Name_PM.Text;
                string id_pm = Urls.PM + str2.Id + "/";
                string id_th = Urls.Teacher + str3.Id + "/";
                if (change_method == 0)
                {
                    create.Create(Token, Urls.MethodPost, name, id_pm, id_th, Urls.Theme);
                    MessageBox.Show("Добавление успешно!");
                }
                else
                {
                    create.Create(Token, Urls.MethodPut, name, id_pm, id_th, Urls.Theme + id + "/");
                    MessageBox.Show("Изменение успешно!");
                }
                App.ParentWindowRef.ParentFrame.Navigate(new ThemePage(Token, role));
            }
            catch (Exception ex)
            {
                MessageBox.Show(errors.Error(ex));
            }
        }
    }
}

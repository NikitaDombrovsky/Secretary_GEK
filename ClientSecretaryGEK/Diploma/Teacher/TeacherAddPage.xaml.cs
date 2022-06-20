using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.repository.Teacher;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ClientSecretaryGEK.Diploma.Teacher
{
    /// <summary>
    /// Логика взаимодействия для TeacherAddPage.xaml
    /// </summary>
    public partial class TeacherAddPage : Page
    {
        int change_method;
        int id;
        string method;
        List<PDTable> ListMain = new List<PDTable>();
        string Token = "";
        int role;
        Errors errors = new Errors();
        public TeacherAddPage(TeacherTableALL _selecteditem, string Token_, int role_)
        {
            InitializeComponent();
            Token = Token_;
            role = role_;
            change_method = 0;
            if (_selecteditem != null)
            {
                change_method = 1;
                DatePick.DataContext = _selecteditem.Дата_Рождения;
                Post_PM.Text = _selecteditem.Должность;
                //ComboPost.DataContext = _selecteditem.Id;
                id = _selecteditem.Id;
            }
            Change();
            ComboPost.ItemsSource = ListMain;

        }
        public void Change()
        {
            var request = new GetRequest(Urls.PD, Token);
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<PDTable>>(response);
            ListMain = objResponse;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrWhiteSpace(DatePick.Text))
                    errors.AppendLine("Укажите Дату");
                if (string.IsNullOrWhiteSpace(Post_PM.Text))
                    errors.AppendLine("Укажите Должность");
                if (string.IsNullOrWhiteSpace(ComboPost.Text))
                    errors.AppendLine("Укажите Персональные данные");
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                //DateTime date = DatePick.DisplayDate;
                DateTime date = Convert.ToDateTime(DatePick.SelectedDate);
                TeacherCreate create = new TeacherCreate();
                var str2 = (PDTable)ComboPost.SelectedItem;
                string post = Post_PM.Text;
                //string token = "Basic QWRtaW46MTIzNDU2QWRtaW4=";
                string id_dp = Urls.PD + str2.Id + "/";
                if (change_method == 0)
                {
                    //method = "POST";
                    create.Create(Token, Urls.MethodPost, post, date, id_dp, Urls.Teacher);
                    MessageBox.Show("Добавление успешно!");
                }
                else
                {
                    //string _urlPM = Urls.Teacher + id + "/";
                    //method = "PUT";
                    create.Create(Token, Urls.MethodPut, post, date, id_dp, Urls.Teacher + id + "/");
                    MessageBox.Show("Изменение успешно!");
                }
                App.ParentWindowRef.ParentFrame.Navigate(new TeacherPage(Token, role));
            }
            catch (Exception ex)
            {
                MessageBox.Show(errors.Error(ex));
            }
        }
    }
}

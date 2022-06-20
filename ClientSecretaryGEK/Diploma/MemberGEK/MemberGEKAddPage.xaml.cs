using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.MemberGEK;
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

namespace ClientSecretaryGEK.Diploma.MemberGEK
{
    /// <summary>
    /// Логика взаимодействия для MemberGEKAddPage.xaml
    /// </summary>
    public partial class MemberGEKAddPage : Page
    {
        int change_method;
        int id;
        string method;
        List<PDTable> ListPD = new List<PDTable>();
        List<SpecialityTable> ListSP = new List<SpecialityTable>();
        string Token = "";
        int role;
        Errors errors = new Errors();
        public MemberGEKAddPage(MemberGEKTableALL _selecteditem, string Token_, int role_)
        {
            InitializeComponent();
            Token = Token_;
            role = role_;
            change_method = 0;
            if (_selecteditem != null)
            {
                change_method = 1;
                //DatePick.DataContext = _selecteditem.Дата_Рождения;
                Post_PM.Text = _selecteditem.Должность;
                Work_PM.Text = _selecteditem.МестоРаботы;
                //ComboPost.DataContext = _selecteditem.Id;
                id = _selecteditem.Id;
            }
            ChangePD();
            ChangeSP();
            ComboSurmane.ItemsSource = ListPD;
            ComboSP.ItemsSource = ListSP;
        }
        public void ChangePD()
        {
            var request = new GetRequest(Urls.PD, Token);
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<PDTable>>(response);
            ListPD = objResponse;
        }
        public void ChangeSP()
        {
            var request = new GetRequest(Urls.Speciality, Token);
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<SpecialityTable>>(response);
            ListSP = objResponse;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrWhiteSpace(Work_PM.Text))
                    errors.AppendLine("Укажите Место работы");
                if (string.IsNullOrWhiteSpace(Post_PM.Text))
                    errors.AppendLine("Укажите Должность");
                if (string.IsNullOrWhiteSpace(ComboSurmane.Text))
                    errors.AppendLine("Укажите Персональные данные");
                if (string.IsNullOrWhiteSpace(ComboSP.Text))
                    errors.AppendLine("Укажите Специальность");
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                //DateTime date = DatePick.DisplayDate;
                //DateTime date = Convert.ToDateTime(DatePick.SelectedDate);
                MemberGEKCreate create = new MemberGEKCreate();
                var str2 = (PDTable)ComboSurmane.SelectedItem;
                var str3 = (SpecialityTable)ComboSP.SelectedItem;
                string post = Post_PM.Text;
                string work = Work_PM.Text;
                //string token = "Basic QWRtaW46MTIzNDU2QWRtaW4=";
                string id_dp = Urls.PD + str2.Id + "/";
                string id_sp = Urls.Speciality + str3.Id + "/";
                if (change_method == 0)
                {
                    //method = "POST";
                    create.Create(Token, Urls.MethodPost, post, work, id_sp, id_dp, Urls.MemberGek);
                    //(string token, string method, string Post, string workplace, string id_speciality, string id_pd, string url)
                    MessageBox.Show("Добавление успешно!");
                }
                else
                {
                    //string _urlPM = Urls.Teacher + id + "/";
                    //method = "PUT";
                    //create.Create(Token, Urls.MethodPut, post, date, id_dp, Urls.Teacher + id + "/");
                    create.Create(Token, Urls.MethodPut, post, work, id_sp, id_dp, Urls.MemberGek + id + "/");
                    MessageBox.Show("Изменение успешно!");
                }
                App.ParentWindowRef.ParentFrame.Navigate(new MemberGEKPage(Token, role));
            }
            catch (Exception ex)
            {
                MessageBox.Show(errors.Error(ex));
            }
        }
    }
}

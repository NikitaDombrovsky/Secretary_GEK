using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.Group;
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

namespace ClientSecretaryGEK.Diploma.Group
{
    /// <summary>
    /// Логика взаимодействия для GroupAddPage.xaml
    /// </summary>
    public partial class GroupAddPage : Page
    {
        int change_method;
        int id;
        string method;
        int role;
        Errors errors = new Errors();
        List<SpecialityTable> ListMain = new List<SpecialityTable>();
        string Token = "";
        public GroupAddPage(GroupTableALL _selecteditem, string Token_, int role_)
        {
            InitializeComponent();
            Token = Token_;
            role = role_;
            change_method = 0;
            if (_selecteditem != null)
            {
                change_method = 1;
                //DatePick.DataContext = _selecteditem.Дата_Рождения;
                Post_PM.Text = _selecteditem.Название_Группы;
                //ComboPost.DataContext = _selecteditem.Id;
                id = _selecteditem.Id;
            }
            Change();
            ComboPost.ItemsSource = ListMain;

        }
        public void Change()
        {
            var request = new GetRequest(Urls.Speciality, Token);
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<SpecialityTable>>(response);
            ListMain = objResponse;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrWhiteSpace(Post_PM.Text))
                    errors.AppendLine("Укажите Название Группы");
                if (string.IsNullOrWhiteSpace(ComboPost.Text))
                    errors.AppendLine("Укажите Специальность");
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                //DateTime date = DatePick.DisplayDate;
                //DateTime date = Convert.ToDateTime(DatePick.SelectedDate);
                GroupCreate create = new GroupCreate();
                var str2 = (SpecialityTable)ComboPost.SelectedItem;
                string post = Post_PM.Text;
                //string token = "Basic QWRtaW46MTIzNDU2QWRtaW4=";
                string id_SP = Urls.Speciality + str2.Id + "/";
                if (change_method == 0)
                {
                    //method = "POST";
                    create.Create(Token, Urls.MethodPost, post, id_SP, Urls.Group);
                    // public void Create(string token, string method, string name_group, string id_speciality, string urlTeacher)
                    MessageBox.Show("Добавление успешно!");
                }
                else
                {
                    //string _urlPM = Urls.Teacher + id + "/";
                    //method = "PUT";
                    create.Create(Token, Urls.MethodPut, post, id_SP, Urls.Group + id + "/");
                    MessageBox.Show("Изменение успешно!");
                }
                App.ParentWindowRef.ParentFrame.Navigate(new GroupPage(Token, role));
            }
            catch (Exception ex)
            {
                MessageBox.Show(errors.Error(ex));
            }
        }
    }
}

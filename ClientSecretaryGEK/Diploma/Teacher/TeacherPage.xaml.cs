using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.repository;
using ClientSecretaryGEK.Network.repository.Teacher;
using ClientSecretaryGEK.Network.repository.Theme;
using Newtonsoft.Json;
using System;
using System.Collections;
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
//using ThemeRepository = ClientSecretaryGEK.Network.repository.Theme.ThemeRepository;

namespace ClientSecretaryGEK.Diploma.Teacher
{
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        List<TeacherTableALL> ListMain = new List<TeacherTableALL>();
        // List<PDTable> ListMainPD = new List<PDTable>();
        string Token = "";
        int role;
        Errors errors = new Errors();
        public TeacherPage(string Token_, int role_)
        {
            InitializeComponent();
            Token = Token_;
            role = role_;
            if (role == 0)
            {
                BtnAdd.IsEnabled = false;
                BtnEdit.IsEnabled = false;
                BtnDel.IsEnabled = false;
            }
            Change();
        }
        public string Comm(string url)
        {
            var request = new GetRequest(url, Token);
            request.Run();
            //request.RunALL();
            string response = request.Response;
            return response;
        }
        public void Change()
        {
            try
            {
                var request = new GetRequest(Urls.Teacher, Token);
                request.RunALL();
                var response = request.Response;
                var objResponse = JsonConvert.DeserializeObject<List<TeacherTable>>(response);
                for (int i = 0; i < objResponse.Count; i++)
                {
                    var res = objResponse[i];
                    var res1 = JsonConvert.DeserializeObject<PDTable>(Comm(res.Id_PD));
                    ListMain.Add(new TeacherTableALL(res.Id, res1.Фамилия, res1.Имя, res1.Отчество, res.Должность, res.Дата_Рождения));
                }
                dgv.ItemsSource = ListMain;
            }
            catch (Exception ex)
            {
                MessageBox.Show(errors.Error(ex));
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new TeacherAddPage(null, Token, role));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            TeacherTableALL path = dgv.SelectedItem as TeacherTableALL;
            if (dgv.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new TeacherAddPage(path, Token, role));
            }
            else
            {
                MessageBox.Show("Выберите элемент!");
            }
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text != "")
            {
                string st = Search.Text;
                var onlyTwo = ListMain.Where(x => x.Фамилия.Contains(Search.Text));
                dgv.ItemsSource = onlyTwo;
            }
            else
            {
                dgv.ItemsSource = ListMain;
            }
        }
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            TeacherTableALL path = dgv.SelectedItem as TeacherTableALL;
            if (dgv.SelectedItem != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var request = new DeleteRequest(Urls.Teacher + path.Id + "/", Token);
                        request.Run();
                        MessageBox.Show("Данные удалены!");
                        Change();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент!");
            }
            Change();
        }
    }
}

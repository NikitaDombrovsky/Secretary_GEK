using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.Group;
using ClientSecretaryGEK.Network.Student;
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

namespace ClientSecretaryGEK.Diploma.Student
{
    /// <summary>
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        List<StudentTableALL> ListMain = new List<StudentTableALL>();
        string Token = "";
        int role;
        Errors errors = new Errors();
        public StudentPage(string Token_, int role_)
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
                var request = new GetRequest(Urls.Student, Token);
                request.RunALL();
                var response = request.Response;
                var objResponse = JsonConvert.DeserializeObject<List<StudentTable>>(response);
                for (int i = 0; i < objResponse.Count; i++)
                {
                    var res = objResponse[i];
                    var res_g = JsonConvert.DeserializeObject<GroupTable>(Comm(res.Группа));
                    //var res_tc = JsonConvert.DeserializeObject<TeacherTable>(Comm(res.Преподаватель));
                    //var res_pm = JsonConvert.DeserializeObject<PDTable>(Comm(res.Преподаватель));
                    var res_th = JsonConvert.DeserializeObject<ThemeTable>(Comm(res.Темы));
                    // (int Id, string average_grade, string group, DateTime? date_of_birth, string teacher, string theme, DateTime? date_meetings_gek, string reviewer_score, string supervisor_score)
                    ListMain.Add(new StudentTableALL(res.Id, res.Фамилия, res.Имя, res.Отчество ,res.Средняя_оценка, res_g.Название_Группы, res.Дата_рождения, res_th.Название_Темы, res.Дата_Заседания, res.Оценка_Рецензента, res.Оценка_Руководителя));
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
            App.ParentWindowRef.ParentFrame.Navigate(new StudentAddPage(null, Token, role));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            StudentTableALL path = dgv.SelectedItem as StudentTableALL;
            if (dgv.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new StudentAddPage(path, Token, role));
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
            StudentTableALL path = dgv.SelectedItem as StudentTableALL;
            if (dgv.SelectedItem != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var request = new DeleteRequest(Urls.Student + path.Id + "/", Token);
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

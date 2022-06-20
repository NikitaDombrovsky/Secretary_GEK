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
    /// Логика взаимодействия для StudentAddPage.xaml
    /// </summary>
    public partial class StudentAddPage : Page
    {
        int change_method;
        int id;
        string method;
        List<GroupTable> ListG = new List<GroupTable>();
        List<ThemeTable> ListTH = new List<ThemeTable>();
        string Token = "";
        int role;
        Errors errors = new Errors();
        public StudentAddPage(StudentTableALL _selecteditem, string Token_, int role_)
        {
            InitializeComponent();
            Token = Token_;
            role = role_;
            change_method = 0;
            if (_selecteditem != null)
            {
                change_method = 1;
                Surname_ST.Text = _selecteditem.Фамилия;
                Name_ST.Text = _selecteditem.Имя;
                Path_ST.Text = _selecteditem.Отчество;

                DatePick_1.DataContext = _selecteditem.Дата_рождения;
                DatePick_2.DataContext = _selecteditem.Дата_Заседания;

                Grade_1.Text = _selecteditem.Средняя_оценка;
                Grade_2.Text = _selecteditem.Оценка_Рецензента;
                Grade_3.Text = _selecteditem.Оценка_Руководителя;

                id = _selecteditem.Id;
            }


            ChangeG();
            ChangeTH();


            ComboGroup.ItemsSource = ListG;
            ComboTheme.ItemsSource = ListTH;

        }
        public void ChangeG()
        {
            var request = new GetRequest(Urls.Group, Token);
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<GroupTable>>(response);
            ListG = objResponse;
        }
        public void ChangeTH()
        {
            var request = new GetRequest(Urls.Theme, Token);
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<ThemeTable>>(response);
            ListTH = objResponse;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrWhiteSpace(Surname_ST.Text))
                    errors.AppendLine("Укажите Фамилия");
                if (string.IsNullOrWhiteSpace(Name_ST.Text))
                    errors.AppendLine("Укажите Имя");
                if (string.IsNullOrWhiteSpace(Path_ST.Text))
                    errors.AppendLine("Укажите Отчество");
                if (string.IsNullOrWhiteSpace(DatePick_1.Text))
                    errors.AppendLine("Укажите Дату рождения");
                if (string.IsNullOrWhiteSpace(DatePick_2.Text))
                    errors.AppendLine("Укажите Дату Заседания");
                if (string.IsNullOrWhiteSpace(Grade_1.Text))
                    errors.AppendLine("Укажите Среднюю оценку");
                if (string.IsNullOrWhiteSpace(Grade_2.Text))
                    errors.AppendLine("Укажите Оценку Рецензента");
                if (string.IsNullOrWhiteSpace(Grade_3.Text))
                    errors.AppendLine("Укажите Оценку Руководителя");

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                StudentCreate create = new StudentCreate();

                string surname = Surname_ST.Text;
                string name = Name_ST.Text;
                string path = Path_ST.Text;

                DateTime date_1 = Convert.ToDateTime(DatePick_1.SelectedDate);
                DateTime date_2 = Convert.ToDateTime(DatePick_2.SelectedDate);

                string grade_1 = Grade_1.Text;
                string grade_2 = Grade_2.Text;
                string grade_3 = Grade_3.Text;

                var str1 = (GroupTable)ComboGroup.SelectedItem;
                var str3 = (ThemeTable)ComboTheme.SelectedItem;


                string id_g = Urls.Group + str1.Id + "/";
                string id_tc = "http://sleepy-brushlands-99972.herokuapp.com/Teacher/7/";
                string id_th = Urls.Theme + str3.Id + "/";
                if (change_method == 0)
                {
                    create.Create(Token, Urls.MethodPost, surname, name, path, grade_1, id_g, date_1, id_tc, id_th, date_2, grade_2, grade_3, Urls.Student);
                    MessageBox.Show("Добавление успешно!");
                }
                else
                {
                    create.Create(Token, Urls.MethodPut, surname, name, path, grade_1, id_g, date_1, id_tc, id_th, date_2, grade_2, grade_3, Urls.Student + id + "/");
                    MessageBox.Show("Изменение успешно!");
                }
                App.ParentWindowRef.ParentFrame.Navigate(new StudentPage(Token, role));
            }
            catch (Exception ex)
            {
                MessageBox.Show(errors.Error(ex));
            }
        }
    }
}

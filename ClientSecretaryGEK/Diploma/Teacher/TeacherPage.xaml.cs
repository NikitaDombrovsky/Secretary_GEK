using ClientSecretaryGEK.Network;
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

namespace ClientSecretaryGEK.Diploma.Teacher
{
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        string urlTeacher;
        List<TeacherTable> ListMain = new List<TeacherTable>();
        public TeacherPage()
        {
            InitializeComponent();
            urlTeacher = Urls.Teacher;
            Change();
        }
        public void Change()
        {

            string search = "";
            var request = new GetRequest1(urlTeacher);
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<TeacherTable>>(response);
            for (int i = 0; i < objResponse.Count; i++)
            {
                var res = objResponse[i];
                ListMain.Add(new TeacherTable(res.Id, res.Фамилия, res.Имя, res.Отчество, res.Дата_Рождения));
            }
            dgv.ItemsSource = ListMain;

        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //App.ParentWindowRef.ParentFrame.Navigate(new TeacherAddPage(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            PMTable path = dgv.SelectedItem as PMTable;
            if (dgv.SelectedItem != null)
            {
                // App.ParentWindowRef.ParentFrame.Navigate(new TeacherAddPage(path));
            }
            else
            {
                MessageBox.Show("Выберите элемент!");
            }
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            if (Search.Text != "")
            {
                string st = Search.Text;
                var onlyTwo = ListMain.Where(x => x.Индекс_ПМ == Search.Text);
                dgv.ItemsSource = onlyTwo;
            }
            else
            {
                dgv.ItemsSource = ListMain;
            }
            */
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            /*
            PMTable path = dgv.SelectedItem as PMTable;
            if (dgv.SelectedItem != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = path.Id;
                        string _urlPM = urlPM + id + "/";
                        var request = new DeleteRequest(_urlPM);
                        request.Run();
                        MessageBox.Show("Данные удалены!");
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
            */
        }
    }
}

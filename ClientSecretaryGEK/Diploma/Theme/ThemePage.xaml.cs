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

namespace ClientSecretaryGEK.Diploma.Theme
{
    /// <summary>
    /// Логика взаимодействия для ThemePage.xaml
    /// </summary>
    public partial class ThemePage : Page
    {
        string urlTheme, urlPM, urlTeacher;
        List<ThemeTable> ListMain = new List<ThemeTable>();
        public ThemePage()
        {
            InitializeComponent();
            var url = new Urls();
            url.RunUrl();
            urlTheme = Urls.Theme;
            urlPM = Urls.PM;
            urlTeacher = Urls.Teacher;
            Change();
        }
        public string Comm(string url)
        {
            var request = new GetRequest1(url);
            request.Run();
            string response = request.Response;
            return response;
        }
        public void Change()
        {
            var request = new GetRequest1(urlTheme);
            request.RunALL();
            var response = request.Response;
            var objResponse = JsonConvert.DeserializeObject<List<ThemeTable>>(response);

            for (int i = 0; i < objResponse.Count; i++)
            {
                var res = objResponse[i];
                var res1 = JsonConvert.DeserializeObject<PMTable>(Comm(res.ID_ПМ));
                var res2 = JsonConvert.DeserializeObject<TeacherTable>(Comm(res.ID_Преподавателя));
                ListMain.Add(new ThemeTable(res.Id, res.Название_Темы, res1.Название_ПМ, res2.Фамилия + " "+ res2.Имя + " " + res2.Отчество));
            }
            dgv.ItemsSource = ListMain;

        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new ThemeAddPage(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ThemeTable path = dgv.SelectedItem as ThemeTable;
            if (dgv.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new ThemeAddPage(path));
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
                var onlyTwo = ListMain.Where(x => x.Название_Темы == Search.Text);
                dgv.ItemsSource = onlyTwo;
            }
            else
            {
                dgv.ItemsSource = ListMain;
            }
            
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            
            ThemeTable path = dgv.SelectedItem as ThemeTable;
            if (dgv.SelectedItem != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = path.Id;
                        string _urlPM = urlTheme + id + "/";
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
            
        }
    }
}

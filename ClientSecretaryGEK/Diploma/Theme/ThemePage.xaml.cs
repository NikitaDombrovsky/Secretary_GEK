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
        //string urlTheme, urlPM, urlTeacher;
        List<ThemeTableALL> ListMain = new List<ThemeTableALL>();
        string Token = "";
        int role;
        Errors errors = new Errors();
        public ThemePage(string Token_, int role_)
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

            /*            var url = new Urls();
                        url.RunUrl();
                        urlTheme = Urls.Theme;
                        urlPM = Urls.PM;
                        urlTeacher = Urls.Teacher;*/
            Change();
        }
        //List<ReviewerTableALL> ListMain = new List<ReviewerTableALL>();
        // List<PDTable> ListMainPD = new List<PDTable>();
        //string Token = "";

        public string Comm(string url)
        {
            var request = new GetRequest(url, Token);
            request.Run();
            string response = request.Response;
            return response;
        }
        public void Change()
        {
            try
            {
                var request = new GetRequest(Urls.Theme, Token);
                request.RunALL();
                var response = request.Response;
                var objResponse = JsonConvert.DeserializeObject<List<ThemeTable>>(response);

                for (int i = 0; i < objResponse.Count; i++)
                {
                    var res = objResponse[i];
                    var res1 = JsonConvert.DeserializeObject<PMTable>(Comm(res.ID_ПМ));
                    var res2 = JsonConvert.DeserializeObject<TeacherTable>(Comm(res.ID_Преподавателя));
                    var res3 = JsonConvert.DeserializeObject<PDTable>(Comm(res2.Id_PD));
                    ListMain.Add(new ThemeTableALL(res.Id, res3.Фамилия, res3.Имя, res3.Отчество, res.Название_Темы, res1.Название_ПМ));
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
            App.ParentWindowRef.ParentFrame.Navigate(new ThemeAddPage(null, Token, role));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ThemeTableALL path = dgv.SelectedItem as ThemeTableALL;
            if (dgv.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new ThemeAddPage(path, Token, role));
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
            
            ThemeTableALL path = dgv.SelectedItem as ThemeTableALL;
            if (dgv.SelectedItem != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = path.Id;
                        //string _urlPM = urlTheme + id + "/";
                        var request = new DeleteRequest(Urls.Theme + id + "/", Token);
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

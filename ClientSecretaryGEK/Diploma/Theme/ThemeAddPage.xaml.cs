using ClientSecretaryGEK.Network;
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
        string urlTheme, urlPM, urlTeacher;
        int change_method;
        int id;
        string method;
        public ThemeAddPage(ThemeTable _selecteditem)
        {
            InitializeComponent();
            var url = new Urls();
            url.RunUrl();
            urlTheme = Urls.Theme;
            urlPM = Urls.PM;
            urlTeacher = Urls.Teacher;

            change_method = 0;
            if (_selecteditem != null)
            {
                change_method = 1;
                Name_PM.Text = _selecteditem.Название_Темы;
               // ComboPM.
                //id = _selecteditem.Id;
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Name_PM.Text))
                errors.AppendLine("Укажите Название");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            string name = Name_PM.Text;
            string idpm = "1";
            string idtch = "1";
            string url = "Basic QWRtaW46MTIzNDU2QWRtaW4=";

            if (change_method == 0)
            {
                method = "POST";
                var data = $@"{{
                ""name_theme"": ""{name}"",
                ""id_professional_module"": ""{idpm}"",
                ""id_teacher"": ""{idtch}""
            }}";
                var request = new PostRequest(urlPM, data, url, method);
                request.Run();
                MessageBox.Show("Добавление успешно!");
            }
            else
            {
                // urlPM = urlPM + id + "/";
                string _urlPM = urlPM + id + "/";
                method = "PUT";
                var data = $@"{{
                ""id"": ""{id}"",
                ""name_theme"": ""{name}"",
                ""id_professional_module"": ""{idpm}"",
                ""id_teacher"": ""{idtch}""
            }}";
                var request = new PostRequest(_urlPM, data, url, method);
                request.Run();
                MessageBox.Show("Изменение успешно!");
            }
            App.ParentWindowRef.ParentFrame.Navigate(new ThemePage());
        }
    }
}

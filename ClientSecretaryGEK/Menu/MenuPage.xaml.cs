using ClientSecretaryGEK.Diploma.PM;
using ClientSecretaryGEK.Diploma.Teacher;
using ClientSecretaryGEK.Diploma.Theme;
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

namespace ClientSecretaryGEK.Menu
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn3_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn4_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn5_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new PMPage());
        }
        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new ThemePage());
        }
        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new TeacherPage());
        }
        private void Btn9_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn10_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

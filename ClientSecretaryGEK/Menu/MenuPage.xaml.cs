using ClientSecretaryGEK.Diploma.Group;
using ClientSecretaryGEK.Diploma.MemberGEK;
using ClientSecretaryGEK.Diploma.PD;
using ClientSecretaryGEK.Diploma.PM;
using ClientSecretaryGEK.Diploma.Reviewer;
using ClientSecretaryGEK.Diploma.Speciality;
using ClientSecretaryGEK.Diploma.Student;
using ClientSecretaryGEK.Diploma.Teacher;
using ClientSecretaryGEK.Diploma.Theme;
using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Protocols;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        string Token = "";
        int role;
        public MenuPage(string Token_, int role_)
        {
            InitializeComponent();
            Token = "Token "+ Token_;
            role = role_;
            if (role == 0)
            {
                Btn12.IsEnabled = false;
            }
            //Token = "Token 1dbdec5bd6f26846392b2993a79d19e5be7acb1e";
            //Process.Start($"C:\Users\nikit\PycharmProjects\APIServer\GEK_DB\MyTest.py") ;
            //System.Diagnostics.Process.Start("C:\\Users\\nikit\\PycharmProjects\\APIServer\\GEK_DB\\manage.py");
            //bool v = new Process("MyTest.py").Start();
            // Urls.Token(Token);
        }
/*        private void Btn1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {

        }*/
        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new GroupPage(Token, role));
        }
        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new StudentPage(Token, role));
        }
        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new SpecialityPage(Token, role));
        }
        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new PMPage(Token, role));
        }
        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new ThemePage(Token, role));
        }
        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new TeacherPage(Token, role));
        }
        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
           App.ParentWindowRef.ParentFrame.Navigate(new ReviewerPage(Token, role));
        }
        private void Btn10_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new MemberGEKPage(Token, role));
        }

        private void Btn11_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new PDPage(Token, role));
        }

        private void Btn12_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new ProtocolsPage(Token));
        }
    }
}

using ClientSecretaryGEK.Diploma.PM;
using ClientSecretaryGEK.Menu;
using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

namespace ClientSecretaryGEK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string urlPM;
        string Token = "";
        int role = 0;
        int s = 0;
        public MainWindow()
        {
            InitializeComponent();

            LoginWindows b = new LoginWindows();

/*            bool loginSuccess = false;
            using (var loginForm = new LoginWindows())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Проверка логина/пароля и установка loginSuccess в true
                }
            }*/
            //if (!loginSuccess) return;

            //Token = Token_;
            if (s == 0)
            {
                b.ShowDialog();
                Token = b.Token;
                role = b.role;
            }


            //urlPM = Urls.PM;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef = this;

            this.ParentFrame.Navigate(new MenuPage(Token, role));
        }
        private void ParentFrame_ContentRendered(object sender, EventArgs e)
        {
            ParentFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            if (ParentFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Collapsed;
            }
        }
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new MenuPage(Token, role));
            /*
            if (ParentFrame.CanGoBack)
                ParentFrame.RemoveBackEntry();
            */
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.GoBack();
        }
    }
}

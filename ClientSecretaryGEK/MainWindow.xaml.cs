using ClientSecretaryGEK.Diploma.PM;
using ClientSecretaryGEK.Menu;
using ClientSecretaryGEK.Network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ClientSecretaryGEK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string urlPM;
        public MainWindow()
        {
            InitializeComponent();
            var url = new Urls();
            url.RunUrl();
            urlPM = Urls.PM;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef = this;

            this.ParentFrame.Navigate(new MenuPage());
        }
        private void ParentFrame_ContentRendered(object sender, EventArgs e)
        {
            ParentFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            if (ParentFrame.CanGoBack)
            {
                //BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                //BtnBack.Visibility = Visibility.Collapsed;
            }
        }

    }
}

using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.PD;
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

namespace ClientSecretaryGEK.Diploma.PD
{
    /// <summary>
    /// Логика взаимодействия для PDAddPage.xaml
    /// </summary>
    public partial class PDAddPage : Page
    {
        int change_method;
        int id;
        string Token = "";
        int role;
        Errors errors = new Errors();
        public PDAddPage(PDTable _selecteditem, string Token_,int role_)
        {
            InitializeComponent();
            Token = Token_;
            role = role_;
            change_method = 0;
            if (_selecteditem != null)
            {
                change_method = 1;
                Surname_PM.Text = _selecteditem.Фамилия;
                Name_PM.Text = _selecteditem.Имя;
                Patronymic_PM.Text = _selecteditem.Отчество;
                id = _selecteditem.Id;
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrWhiteSpace(Name_PM.Text))
                    errors.AppendLine("Укажите Имя");
                if (string.IsNullOrWhiteSpace(Surname_PM.Text))
                    errors.AppendLine("Укажите Фамилию");
                if (string.IsNullOrWhiteSpace(Patronymic_PM.Text))
                    errors.AppendLine("Укажите Отчетсво");
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                string name = Name_PM.Text;
                string surname = Surname_PM.Text;
                string patronymic = Patronymic_PM.Text;
                PDCreate create = new PDCreate();
                //string token = Urls.Token;

                if (change_method == 0)
                {
                    create.Create(Token, Urls.MethodPost, surname, name, patronymic, Urls.PD);

                    MessageBox.Show("Добавление успешно!");
                }
                else
                {
                    create.Create(Token, Urls.MethodPut, surname, name, patronymic, Urls.PD + id + "/");
                    MessageBox.Show("Изменение успешно!");
                }
                App.ParentWindowRef.ParentFrame.Navigate(new PDPage(Token, role));
            }
            catch (Exception ex)
            {
                MessageBox.Show(errors.Error(ex));
            }
        }
    }
}

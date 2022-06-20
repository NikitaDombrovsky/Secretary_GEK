using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.Specialty;
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

namespace ClientSecretaryGEK.Diploma.Speciality
{
    /// <summary>
    /// Логика взаимодействия для SpecialityAddPage.xaml
    /// </summary>
    public partial class SpecialityAddPage : Page
    {
/*        public SpecialityAddPage()
        {
            InitializeComponent();
        }*/
        int change_method;
        int id;
        string Token = "";
        int role;
        public SpecialityAddPage(SpecialityTable _selecteditem, string Token_, int role_)
        {
            InitializeComponent();
            //urlPM = Urls.PM;
            Token = Token_;
            role = role_;
            change_method = 0;
            if (_selecteditem != null)
            {
                change_method = 1;
                Name_PM.Text = _selecteditem.Название_Специальности;
                Code_PM.Text = _selecteditem.Номер_Специальности;
                id = _selecteditem.Id;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Name_PM.Text))
                errors.AppendLine("Укажите Название");
            if (string.IsNullOrWhiteSpace(Code_PM.Text))
                errors.AppendLine("Укажите Код");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            string name = Name_PM.Text;
            string code = Code_PM.Text;
            SpecialityCreate create = new SpecialityCreate();
            //string token = Urls.Token;

            if (change_method == 0)
            {
                create.Create(Token, Urls.MethodPost, name, code, Urls.Speciality);
                MessageBox.Show("Добавление успешно!");
            }
            else
            {
                create.Create(Token, Urls.MethodPut, name, code, Urls.Speciality + id + "/");
                MessageBox.Show("Изменение успешно!");
            }
            App.ParentWindowRef.ParentFrame.Navigate(new SpecialityPage(Token, role));
        }
    }
}

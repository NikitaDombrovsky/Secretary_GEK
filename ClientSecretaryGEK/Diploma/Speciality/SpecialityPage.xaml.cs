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

namespace ClientSecretaryGEK.Diploma.Speciality
{
    /// <summary>
    /// Логика взаимодействия для SpecialityPage.xaml
    /// </summary>
    public partial class SpecialityPage : Page
    {
        List<SpecialityTable> ListMain = new List<SpecialityTable>();
        string Token = "";
        int role;
        Errors errors = new Errors();
        public SpecialityPage(string Token_, int role_)
        {
            InitializeComponent();
            role = role_;
            if (role == 0)
            {
                BtnAdd.IsEnabled = false;
                BtnEdit.IsEnabled = false;
                BtnDel.IsEnabled = false;
            }
            Token = Token_;
            Change();
            // PMRepository pM = new PMRepositiryIMPL();
            //ListMain = pM.Execute();
            //dgv.ItemsSource = ListMain;
        }
        public void Change()
        {
            try
            {
                var request = new GetRequest(Urls.Speciality, Token);
                request.RunALL();
                var response = request.Response;
                var objResponse = JsonConvert.DeserializeObject<List<SpecialityTable>>(response);
                ListMain = objResponse;
                dgv.ItemsSource = ListMain;
            }
            catch (Exception ex)
            {
                MessageBox.Show(errors.Error(ex));
            }

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new SpecialityAddPage(null, Token, role));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            SpecialityTable path = dgv.SelectedItem as SpecialityTable;
            if (dgv.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new SpecialityAddPage(path, Token, role));
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
                var onlyTwo = ListMain.Where(x => x.Название_Специальности.Contains(Search.Text));
                dgv.ItemsSource = onlyTwo;
            }
            else
            {
                dgv.ItemsSource = ListMain;
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            SpecialityTable path = dgv.SelectedItem as SpecialityTable;
            if (dgv.SelectedItem != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var request = new DeleteRequest(Urls.Speciality + path.Id + "/", Token);
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
        }
    }
}

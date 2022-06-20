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

namespace ClientSecretaryGEK.Diploma.PD
{
    /// <summary>
    /// Логика взаимодействия для PDPage.xaml
    /// </summary>
    public partial class PDPage : Page
    {
        List<PDTable> ListMain = new List<PDTable>();
        string Token = "";
        int role;
        Errors errors = new Errors();
        public PDPage(string Token_, int role_)
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
            Change();
        }
        public void Change()
        {
            try
            {
                var request = new GetRequest(Urls.PD, Token);
                request.RunALL();
                var response = request.Response;
                var objResponse = JsonConvert.DeserializeObject<List<PDTable>>(response);
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
            App.ParentWindowRef.ParentFrame.Navigate(new PDAddPage(null, Token, role));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            PDTable path = dgv.SelectedItem as PDTable;
            if (dgv.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new PDAddPage(path, Token, role));
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
                var onlyTwo = ListMain.Where(x => x.Фамилия.Contains(Search.Text));
                dgv.ItemsSource = onlyTwo;
            }
            else
            {
                dgv.ItemsSource = ListMain;
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            PDTable path = dgv.SelectedItem as PDTable;
            if (dgv.SelectedItem != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var request = new DeleteRequest(Urls.PD + path.Id + "/", Token);
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

using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.Reviewer;
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

namespace ClientSecretaryGEK.Diploma.Reviewer
{
    /// <summary>
    /// Логика взаимодействия для ReviewerPage.xaml
    /// </summary>
    public partial class ReviewerPage : Page
    {

        List<ReviewerTableALL> ListMain = new List<ReviewerTableALL>();
        // List<PDTable> ListMainPD = new List<PDTable>();
        string Token = "";
        int role;
        Errors errors = new Errors();

        public ReviewerPage(string Token_, int role_)
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
        public string Comm(string url)
        {
            var request = new GetRequest(url, Token);
            request.Run();
            //request.RunALL();
            string response = request.Response;
            return response;
        }
        public void Change()
        {
            try
            {
                var request = new GetRequest(Urls.Reviewer, Token);
                request.RunALL();
                var response = request.Response;
                var objResponse = JsonConvert.DeserializeObject<List<ReviewerTable>>(response);
                for (int i = 0; i < objResponse.Count; i++)
                {
                    var res = objResponse[i];
                    var res1 = JsonConvert.DeserializeObject<SpecialityTable>(Comm(res.Id_Speciality));
                    var res2 = JsonConvert.DeserializeObject<PDTable>(Comm(res.Id_PD));
                    ListMain.Add(new ReviewerTableALL(res.Id, res2.Фамилия, res2.Имя, res2.Отчество, res.Должность, res.МестоРаботы, res1.Название_Специальности));
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
            App.ParentWindowRef.ParentFrame.Navigate(new ReviewerAddPage(null, Token, role));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ReviewerTableALL path = dgv.SelectedItem as ReviewerTableALL;
            if (dgv.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new ReviewerAddPage(path, Token, role));
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
            ReviewerTableALL path = dgv.SelectedItem as ReviewerTableALL;
            if (dgv.SelectedItem != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var request = new DeleteRequest(Urls.Reviewer + path.Id + "/", Token);
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

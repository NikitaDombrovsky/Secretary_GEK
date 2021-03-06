using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.MemberGEK;
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

namespace ClientSecretaryGEK.Diploma.MemberGEK
{
    /// <summary>
    /// Логика взаимодействия для MemberGEKPage.xaml
    /// </summary>
    public partial class MemberGEKPage : Page
    {
        List<MemberGEKTableALL> ListMain = new List<MemberGEKTableALL>();
        string Token = "";
        int role;
        Errors errors = new Errors();
        public MemberGEKPage(string Token_, int role_)
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
                /*            ArrayList Empty = new ArrayList();
                            dgv.ItemsSource = Empty;*/
                //ListMain.Clear();
                //dgv.Rows.Clear();

                var request = new GetRequest(Urls.MemberGek, Token);
                request.RunALL();
                var response = request.Response;
                var objResponse = JsonConvert.DeserializeObject<List<MemberGEKTable>>(response);
                for (int i = 0; i < objResponse.Count; i++)
                {
                    var res = objResponse[i];
                    var res1 = JsonConvert.DeserializeObject<SpecialityTable>(Comm(res.Id_Speciality));
                    var res2 = JsonConvert.DeserializeObject<PDTable>(Comm(res.Id_PD));
                    ListMain.Add(new MemberGEKTableALL(res.Id, res2.Фамилия, res2.Имя, res2.Отчество, res.Должность, res.МестоРаботы, res1.Название_Специальности));
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
            App.ParentWindowRef.ParentFrame.Navigate(new MemberGEKAddPage(null, Token, role));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            MemberGEKTableALL path = dgv.SelectedItem as MemberGEKTableALL;
            if (dgv.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new MemberGEKAddPage(path, Token, role));
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
            MemberGEKTableALL path = dgv.SelectedItem as MemberGEKTableALL;
            if (dgv.SelectedItem != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var request = new DeleteRequest(Urls.MemberGek + path.Id + "/", Token);
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

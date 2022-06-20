using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.Group;
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

namespace ClientSecretaryGEK.Diploma.Group
{
    /// <summary>
    /// Логика взаимодействия для GroupPage.xaml
    /// </summary>
    public partial class GroupPage : Page
    {
        List<GroupTableALL> ListMain = new List<GroupTableALL>();
        string Token = "";
        int role;
        Errors errors = new Errors();
        public GroupPage(string Token_, int role_)
        {
            Token = Token_;
            InitializeComponent();
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
            string response = request.Response;
            return response;
        }
        public void Change()
        {
            try
            {
                var request = new GetRequest(Urls.Group, Token);
                request.RunALL();
                var response = request.Response;
                var objResponse = JsonConvert.DeserializeObject<List<GroupTable>>(response);
                for (int i = 0; i < objResponse.Count; i++)
                {
                    var res = objResponse[i];
                    var res1 = JsonConvert.DeserializeObject<SpecialityTable>(Comm(res.ID_SP));
                    ListMain.Add(new GroupTableALL(res.Id, res.Название_Группы, res1.Название_Специальности));
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
            App.ParentWindowRef.ParentFrame.Navigate(new GroupAddPage(null, Token, role));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            GroupTableALL path = dgv.SelectedItem as GroupTableALL;
            if (dgv.SelectedItem != null)
            {
                App.ParentWindowRef.ParentFrame.Navigate(new GroupAddPage(path, Token, role));
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
                var onlyTwo = ListMain.Where(x => x.Название_Группы.Contains(Search.Text));
                dgv.ItemsSource = onlyTwo;
            }
            else
            {
                dgv.ItemsSource = ListMain;
            }
        }
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            GroupTableALL path = dgv.SelectedItem as GroupTableALL;
            if (dgv.SelectedItem != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var request = new DeleteRequest(Urls.Group + path.Id + "/", Token);
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

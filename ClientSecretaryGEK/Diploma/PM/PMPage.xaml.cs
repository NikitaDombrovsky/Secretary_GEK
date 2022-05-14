using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.repository;
using ClientSecretaryGEK.Network.repository.net;
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

namespace ClientSecretaryGEK.Diploma.PM
{
    /// <summary>
    /// Логика взаимодействия для PMPage.xaml
    /// </summary>
    public partial class PMPage : Page
    {
        string urlPM;
        List<PMTable> ListMain = new List<PMTable>();
        public PMPage()
        {
            InitializeComponent();
            Service<PMTable> service = new PMTableServiceIMPL();
            PMRepository pM = new PMRepositiryIMPL(service);
            ListMain = pM.Execute();
            dgv.ItemsSource = ListMain;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new PMAddPage(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            PMTable path = dgv.SelectedItem as PMTable;
            if (dgv.SelectedItem != null)
            {
               // MessageBox.Show(" ID: " + path.Id + " индекс: " + path.index_professional_module + "\n имя: " + path.name_professional_module);
                App.ParentWindowRef.ParentFrame.Navigate(new PMAddPage(path));
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
                var onlyTwo = ListMain.Where(x => x.Название_ПМ.Contains(Search.Text));
                dgv.ItemsSource = onlyTwo;
            }
            else
            {
                dgv.ItemsSource = ListMain;
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            PMTable path = dgv.SelectedItem as PMTable;
            if (dgv.SelectedItem != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var request = new DeleteRequest(Urls.PM + path.Id + "/");
                        request.Run();
                        MessageBox.Show("Данные удалены!");

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
           // Change();
        }
        

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            /*if (Visibility == Visibility.Visible)
            {
                SecretaryEntities5.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                сотрудникDataGrid.ItemsSource = SecretaryEntities5.GetContext().Employees.ToList();
            }*/
        }
        private void dgv_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PMTable path = dgv.SelectedItem as PMTable;
            //MyTable path = grid.SelectedItem as MyTable;
            MessageBox.Show(" ID: " + path.Id + " индекс: " + path.Индекс_ПМ + "\n имя: " + path.Название_ПМ);

            // MessageBox.Show(" ID: " + path.Id + "\n Исполнитель: " + path.Vocalist + "\n Альбом: " + path.Album + "\n Год: " + path.Year);
        }


    }
}

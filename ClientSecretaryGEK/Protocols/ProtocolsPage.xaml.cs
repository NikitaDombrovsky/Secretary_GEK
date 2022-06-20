//using ClientSecretaryGEK.Protocols.Helder;
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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using ClientSecretaryGEK.Network.Student;
using Newtonsoft.Json;
using ClientSecretaryGEK.Network;
using ClientSecretaryGEK.Network.Group;
using ClientSecretaryGEK.Network.MemberGEK;

namespace ClientSecretaryGEK.Protocols
{
    /// <summary>
    /// Логика взаимодействия для ProtocolsPage.xaml
    /// </summary>
    public partial class ProtocolsPage : Page
    {
        Excel._Workbook workBook;
        Excel._Worksheet workSheet;
        string Token = "";

        List<StudentTableProtocols> ListMain = new List<StudentTableProtocols>();
        List<StudentTableProtocols> ListMain_ = new List<StudentTableProtocols>();
        List<SpecialityTable> ListSp = new List<SpecialityTable>();
        List<MemberGEKTable> ListMemberGEK = new List<MemberGEKTable>();
        List<MemberGEKTableProtocol> ListMemberGEKProtocols = new List<MemberGEKTableProtocol>();
        public ProtocolsPage(String Token_)
        {
            InitializeComponent();
            Token = Token_;
            Change();
            ListSp = JsonConvert.DeserializeObject<List<SpecialityTable>>(Change_(Urls.Speciality));
            ComboGroup.ItemsSource = ListSp;
        }
        private void DatePick_1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateGridChanger();
        }
        private void ComboGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateGridChanger();
        }
        public void DateGridChanger()
        {
            DateTime date_1 = Convert.ToDateTime(DatePick_1.SelectedDate);
            string date_meetings_gek_ = date_1.ToString("yyyy-MM-dd");
            var str1 = (SpecialityTable)ComboGroup.SelectedItem;
            if (date_1.Date != DateTime.Parse("01.01.0001"))
            {
                if (str1 != null)
                {
                    var only = ListMain.Where(x => x.Специальность.Equals(str1.Название_Специальности));
                    var onlyTwo = only.Where(x => x.Дата_Заседания.Equals(date_1.Date));
                    dgv.ItemsSource = onlyTwo;
                    ListMain_ = onlyTwo.ToList();
                }
            }
            else
            {
                dgv.ItemsSource = ListMain;
            }
        }
        public string Change_(string url)
        {
            var request = new GetRequest(url, Token);
            request.RunALL();
            var response = request.Response;
            return response;
        }
        public void Change()
        {
            try
            {
                var request = new GetRequest(Urls.Student, Token);
                request.RunALL();
                var response = request.Response;
                var objResponse = JsonConvert.DeserializeObject<List<StudentTable>>(Change_(Urls.Student));
                var objResponse_1 = JsonConvert.DeserializeObject<List<GroupTable>>(Change_(Urls.Group));
                var objResponse_2 = JsonConvert.DeserializeObject<List<SpecialityTable>>(Change_(Urls.Speciality));
                var objResponse_3 = JsonConvert.DeserializeObject<List<ThemeTable>>(Change_(Urls.Theme));
                for (int i = 0; i < objResponse.Count; i++)
                {
                    var res = objResponse[i];
                    string[] st_th = res.Темы.Split(new char[] { '/' });
                    string[] st_gp = res.Группа.Split(new char[] { '/' });
                    var res_th = objResponse_3.Find(x => x.Id.ToString().Equals(st_th[4]));
                    var res_gp = objResponse_1.Find(x => x.Id.ToString().Equals(st_gp[4]));
                    string[] st_sp = res_gp.ID_SP.Split(new char[] { '/' });
                    var res_sp = objResponse_2.Find(x => x.Id.ToString().Equals(st_sp[4]));
                    ListMain.Add(new StudentTableProtocols(res.Id, res.Фамилия, res.Имя, res.Отчество, res_sp.Название_Специальности, res_th.Название_Темы, res.Дата_Заседания));
                }
                dgv.ItemsSource = ListMain;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            DataStrings dataStrings = new DataStrings();
            dataStrings.RunProtocols();
            Excel.Application excelApp = new Excel.Application();

            workBook = excelApp.Workbooks.Add();

            try
            {
                var st = ListMain_;
                string sp = st[0].Специальность;
                var request = new GetRequest(Urls.MemberGek, Token);
                request.RunALL();
                var response = request.Response;
                var objResponse = JsonConvert.DeserializeObject<List<MemberGEKTable>>(response); 
                var objResponse_1 = JsonConvert.DeserializeObject<List<PDTable>>(Change_(Urls.PD)); 
                var objResponse_2 = JsonConvert.DeserializeObject<List<SpecialityTable>>(Change_(Urls.Speciality));
                var res_sp = objResponse_2.Find(x => x.Название_Специальности.Equals(sp));
                var res_member = objResponse.Where(x => x.Id_Speciality.Equals(Urls.Speciality + res_sp.Id + "/"));        
                for (int i = 0; i < objResponse.Count; i++)
                {
                    var res = objResponse[i];
                    string[] st_pd = res.Id_PD.Split(new char[] { '/' });
                    var res_pd = objResponse_1.Find(x => x.Id.ToString().Equals(st_pd[4]));
                    ListMemberGEKProtocols.Add(new MemberGEKTableProtocol(res.Id,res_pd.Фамилия, res_pd.Имя, res_pd.Отчество));;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            var st_membergek = ListMemberGEKProtocols;
            string[,] memberarr = new string[st_membergek.Count, 3];
            for (int i = 0; i < st_membergek.Count; i++)
            {
                memberarr[i, 0] = st_membergek[i].Фамилия;
                memberarr[i, 1] = st_membergek[i].Имя;
                memberarr[i, 2] = st_membergek[i].Отчество;

            }
            var st_main = ListMain_;
            string[,] mainarr = new string[st_main.Count, 4];
            for (int i = 0; i < st_main.Count; i++)
            {
                mainarr[i, 0] = st_main[i].Фамилия;
                mainarr[i, 1] = st_main[i].Имя;
                mainarr[i, 2] = st_main[i].Отчество;
                mainarr[i, 3] = st_main[i].Тема;
            }
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            Protocol(memberarr, mainarr, "ДОКЛАДА", "Протокол1", "доклада");
            workSheet = (Excel.Worksheet)workBook.Worksheets.Add();
            Protocol(memberarr, mainarr, "ДЕМОПРИМЕРА", "Протокол2", "ДП");
            workSheet = (Excel.Worksheet)workBook.Worksheets.Add();
            Protocol(memberarr, mainarr, "ОТВЕТОВ", "Протокол3", " ответов");
            workSheet = (Excel.Worksheet)workBook.Worksheets.Add();
            Protocol_Main(memberarr, mainarr, "ОТВЕТОВ", "Протокол4", " ответов");
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }
        private void Protocol_Main(string[,] memberarr, string[,] mainarr, string score, string name, string dop)
        {
            workSheet.Name = name;

            string[] pr_main = DataStrings.Protocol_GEK_Main;

            int i = 0;
            for (int j = 2; j <= pr_main.Length + 1; j++)
            {
                workSheet.Cells[2, j] = pr_main[i];
                i++;
            }
            int shet = (memberarr.Length / 3) + 1;
            for (int j = 3; j - 3 < mainarr.Length / 4; j++)
            {
                workSheet.Cells[j, 2] = j - 3;
                workSheet.Cells[j, 3] = "" + mainarr[j - 3, 0] + " " + mainarr[j - 3, 1] + " " + mainarr[j - 3, 2];
                Excel.Range formul = workSheet.Range["" + Chet(shet + 2) + j];
                formul.Formula = "=СРЗНАЧ('Протокол1'!"+ Chet(shet)+""+(j+1)+")";
                Excel.Range formul_1 = workSheet.Range["" + Chet(shet + 3) + j];
                formul_1.Formula = "=СРЗНАЧ('Протокол2'!" + Chet(shet) + "" + (j + 1) + ")";
                Excel.Range formul_3 = workSheet.Range["" + Chet(shet + 4) + j];
                formul_3.Formula = "=СРЗНАЧ('Протокол3'!" + Chet(shet) + "" + (j + 1) + ")";
                Excel.Range formul_4 = workSheet.Range["" + Chet(shet + 5) + j];
                formul_4.Formula = "=СРЗНАЧ(D" + j + ":J" + j + ")";
                Excel.Range formul_5 = workSheet.Range["" + Chet(shet + 6) + j];
                //formul_5.Formula = "=СУММ(D" + j + ":K" + j + ")/СЧЁТЕСЛИ(D" + j + ":K" + j + ";>0";
                //=СУММ(D3:K4)/СЧЁТЕСЛИ(D3:K4;">0")
            }
            Excel.Range rng = workSheet.Range["B2:K" + ((mainarr.Length / 4) + 2) + ""];
            Excel.Range rng_2 = workSheet.Range["D2:M2"];
            Excel.Range rng_1 = workSheet.Range["B2:M2"];
            rng_2.Orientation = 90;
            rng_1.Font.Bold = true;
            rng.HorizontalAlignment = -4108;
            rng.VerticalAlignment = -4108;
            rng.WrapText = true;
            rng.Font.Name = "Times New Roman";
            rng.Font.Size = 12;
            rng.ColumnWidth = 12;
            Excel.Borders border = rng.Borders;
            border.LineStyle = Excel.XlLineStyle.xlContinuous;

        }

        private void Protocol(string[,] memberarr, string[,] mainarr, string score, string name, string dop)
        {

            workSheet.Name = name;
            workSheet.Cells[2, 2] = "№ п.п.";
            Excel.Range _excelCells_1 = workSheet.get_Range("B2:B3").Cells;
            _excelCells_1.Merge(Type.Missing);
            workSheet.Cells[2, 3] = "Фамилия, имя, отчество студента";
            Excel.Range _excelCells_2 = workSheet.get_Range("C2:C3").Cells;
            _excelCells_2.Merge(Type.Missing);
            workSheet.Cells[2, 4] = "Оценка "+ score + " членами ГЭК";
            Excel.Range _excelCells_3 = workSheet.get_Range("D2:"+ Chet(memberarr.Length / 3) +"2").Cells;
            _excelCells_3.Merge(Type.Missing);
            int shet = (memberarr.Length / 3) + 1;
            workSheet.Cells[2,4 + (memberarr.Length / 3)] = "Приведенная экспертная оценка " + dop; 
            Excel.Range _excelCells_4 = workSheet.get_Range(""+ Chet(shet) + "2:" + Chet(shet) + "3").Cells;
            _excelCells_4.Merge(Type.Missing);
            for (int j = 4; j-4 < memberarr.Length/3; j++)
            {
                workSheet.Cells[3, j] = "" + memberarr[j - 4, 0] + " " + memberarr[j - 4, 1] + " " + memberarr[j - 4, 2];
            }
            for (int j = 4; j - 4 < mainarr.Length / 4; j++)
            {
                workSheet.Cells[j, 2] = j-3;
                workSheet.Cells[j, 3] = "" + mainarr[j - 4, 0] + " " + mainarr[j - 4, 1] + " " + mainarr[j - 4, 2];
                Excel.Range formul = workSheet.Range[""+ Chet(shet) + j];
                formul.Formula = "=СРЗНАЧ(D" + j + ":"+Chet(shet-1) + j + ")";
                formul.FormulaHidden = false;
            }
            Excel.Range rng = workSheet.Range["B2:" +Chet(shet) +((mainarr.Length / 4)+3) +""];
            Excel.Range rng_1 = workSheet.Range["B2:" +Chet(shet) +"3"];
            Excel.Range rng_2 = workSheet.Range["D3:" +Chet(shet-1) +"3"];
            rng_2.Orientation = 90;
            rng_1.Font.Bold = true;
            rng.HorizontalAlignment = -4108;
            rng.VerticalAlignment = -4108;
            rng.WrapText = true;
            rng.Font.Name = "Times New Roman";
            rng.Font.Size = 12;
            rng.ColumnWidth = 15;
            Excel.Borders border = rng.Borders;
            border.LineStyle = Excel.XlLineStyle.xlContinuous;
        }
        private string Chet(int mass)
        {
            switch (mass)
            {
                case 1:
                    return "D";
                    break;
                case 2:
                    return "E";
                    break;
                case 3:
                    return "F";
                    break;
                case 4:
                    return "G";
                    break;
                case 5:
                    return "H";
                    break;
                case 6:
                    return "I";
                    break;
                case 7:
                    return "J";
                    break;
                case 8:
                    return "K";
                    break;
                case 9:
                    return "L";
                    break;
                case 10:
                    return "M";
                    break;
                default:
                    return "OK";
            }

        }
    }
}

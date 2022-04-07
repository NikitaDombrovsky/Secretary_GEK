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
using System;
using System.Net;
using ClientSecretaryGEK.Network;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

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
            urlPM = url.PM;
            Change();
            /*
            List<PMTable> list1 = new List<PMTable>(); //3
            var url1 = "http://127.0.0.1:8000/PM/";
            var request = new GetRequest1(url1);
            request.Run();
            var response = request.Response;
            var objResponse2 = JsonConvert.DeserializeObject<List<PMTable>>(response);
            list1.AddRange(objResponse2);
            dgv.ItemsSource = list1;
            */

            /*
            Console.WriteLine(httpResponse.StatusCode);

            //var PM = ("PM/");
            //var Data = ( 1 + "/");
            
            List<PMTable> list = new List<PMTable>(); //3
            int n = 1;
            //int i = 1;
            int megashet = 10;
            string url = "http://127.0.0.1:8000/PM/";
            for (int i = 1; i <= megashet; i++)
            //while (n == 1)
            //for (int i = 1; i <= 3; i++)
            {
                var Data = (i + "/");
                var request = new GetRequest($"{url}{Data}");
                request.Run();
                var response = request.Response;
                if (response != null)
                {
                    var result = JsonConvert.DeserializeObject<PMTable>(response); //PM
                    list.Add(new PMTable(result.Id, result.index_professional_module, result.name_professional_module));
                    //n = 0;
                    //break;
                }
                else
                {
                    megashet++;
                }
                //PMTable myDeserializedClass1 = JsonConvert.DeserializeObject<PMTable>(response); //PM
 
               // i++;
            }
            dgv.ItemsSource = list;
            */
        }
        public void Change()
        {
            //List<PMTable> List = new List<PMTable>();
            List<PMTableMain> ListMain = new List<PMTableMain>();
            // var url1 = "http://127.0.0.1:8000/PM/";
            string search = "";
            var request = new GetRequest1(urlPM);
            request.RunALL();
            var response = request.Response;
            //var request1 = new GetRequest(urlPM);
           // request1.Run();
            var objResponse = JsonConvert.DeserializeObject<List<PMTableMain>>(response);
            //var result = JsonConvert.DeserializeObject<PMTable>(request1.Response); //PM
           // var res = objResponse.ToList();
            //var res1 = objResponse[0];
            //var s = res1.index_professional_module;
            for (int i = 0; i < objResponse.Count; i++)
            {
                var res = objResponse[i];
                if (search != "")
                {
                    if (res.index_professional_module == search)
                    {
                        ListMain.Add(new PMTableMain(res.index_professional_module, res.name_professional_module));
                    }
                }
                else
                {
                    ListMain.Add(new PMTableMain(res.index_professional_module, res.name_professional_module));
                }


            }
            //.Add(new PMTable(result.Id, result.index_professional_module, result.name_professional_module));
           // ListMain.AddRange(objResponse);
            dgv.ItemsSource = ListMain;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var url = "http://127.0.0.1:8000/PM/";
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(urlPM); //var
            string index = Index_B.Text;
            string name = Name_B.Text;
            httpRequest.Method = "POST";   
            httpRequest.ContentType = "application/json";
            var data = $@"{{
                ""index_professional_module"": ""{index}"",
                ""name_professional_module"": ""{name}""
            }}";
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            //var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
            Change();
            Console.WriteLine(httpResponse.StatusCode);
            //var request = new PostRequest("http://127.0.0.1:8000/PM/");
           // request.Run();
           // var response = request.Response;
            /*
            var key = "1111";
            var request = WebRequest.Create("URL");
            request.ContentType = "application/json";
            request.Headers["Authorization"] = "Basic " + key;

            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"param1\":\"val\",\"param2\":\"val\"}";
                streamWriter.Write(json);
            }


            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                Console.WriteLine(reader.ReadToEnd());
            }
            */
        }
        /* НЕ УДАЛЯТЬ
//Получаем данные из таблицы
private void grid_MouseUp(object sender, MouseButtonEventArgs e)
{
   MyTable path = grid.SelectedItem as MyTable;
   MessageBox.Show(" ID: " + path.Id + "\n Исполнитель: " + path.Vocalist + "\n Альбом: " + path.Album
       + "\n Год: " + path.Year);
}
*/
        /*
        public class MyTable
        {
            public MyTable(int Id, string index_professional_module, string name_professional_module)
            {
                this.Id = Id;
                this.index_professional_module = index_professional_module;
                this.name_professional_module = name_professional_module;
            }
            public int Id { get; set; }
            public string index_professional_module { get; set; }
            public string name_professional_module { get; set; }
        }
        */
    }
}

// request.Run();

// var response = request.Response;


//label1.Content = response.ToString();

// string testJson = "{'id':'1','index_professional_module':'ПП_01','name_professional_module':'Мобильные приложения'}";
// PM myDeserializedClass = JsonConvert.DeserializeObject<PM>(testJson);

//PM myDeserializedClass1 = JsonConvert.DeserializeObject<PM>(response);

//string jsonData = JsonConvert.SerializeObject(response);

// var result = JsonConvert.DeserializeObject<PM>(response); //response

//DataGridView inf = new DataGridView();
//DGrid.DataContext = inf;


// result1.Add(new MyTable(2, "AC/DC", "Back in Black", 1980));

/*
inf.Add(new SunsetTime
{
    voshod = "9:01:06",
    zahod = "16:07:38"
});
inf.Add(new SunsetTime
{
    voshod = "9:00:51",
    zahod = "16:08:47"
});

inf.Add(new SunsetTime
{
    voshod = "9:00:33",
    zahod = "16:10:00"
});
/*
label1.Content = ($"Id: {result.id}, Index: {result.index_professional_module}, Name: {result.name_professional_module}");
//создаем строку

string[] Stroka = { "cibergod", "is", "good", "special", "Site" };

//добавляем ее в таблицу

gridParam(Stroka, DGrid);

//создаем другю строку

string[] strokaEshe = { "abx", "asd", "qwe" };

//добавляем ее в таблицу

gridParam(strokaEshe, DGrid);
/*
DataGridView dataGrid = new DataGridView();
DiplomaDataGrid.DataContext
string[] array = //ваши данные
for (int i = 0; i <= 10; i++)
{
    datagridview.Rows.Add//добавляем строки с таблицу
    datagridview[0, i].Value = array[i];//заносим в первый столбец данные
}
dataGrid.Parent = MainWindow();
dataGrid.Dock = DockStyle.Fill;
dataGrid.RowCount = 5;
dataGrid.ColumnCount = 5;
for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        dataGrid.Rows[i].Cells[j].Value = arr[i, j];
    }
}
*/

/*
public void gridParam(string[] N, DataGridView Grid)
{
    //пока столбцов не будет достаточное количество добавляем их
    while (N.Length > Grid.ColumnCount)
    {
        //если колонок нехватает добавляем их пока их будет хватать
        Grid.Columns.Add("", "");
    }
    //заполняем строку
    Grid.Rows.Add(N);

}
} */

/*
public class SunsetTime
{
public string datestr { get; set; }
public string voshod { get; set; }
}
*/
/*
class PM
{
    public int id { get; set; }
    public string index_professional_module { get; set; }
    public string name_professional_module { get; set; }
}
*/

//

//Regex regex = new Regex(@"id");
//MatchCollection matches = regex.Matches(response.ToString());
/*
string s = "Бык тупогуб, тупогубенький бычок, у быка губа бела была тупа";
Regex regex = new Regex(@"туп(\w*)");
MatchCollection matches = regex.Matches(s);
*/
//if (matches.Count > 0)
//{
//foreach (Match match in matches)
//  label1.Content = match.Value;
//Console.WriteLine(match.Value);
//}
//else
//{
//  Console.WriteLine("Совпадений не найдено");
//}
//
// string[] words = response.Split(':', ',');
//


//var json = JObject.Parse(response.ToString());
/*
 var json = JObject.Parse(response);

 var _PM = json["PM"];
 foreach (var name in _PM)
 {
     var name_professional_module = name["name_professional_module"];
     label1.Content = name_professional_module;
 }
*/

//label1.Content = response;
/*
HttpClient httpClient = new HttpClient();
string request = "https://api.exmo.com/v1/trades/?pair=BTC_USD,ETH_USD";
HttpResponseMessage response =
    (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
string responseBody = await response.Content.ReadAsStringAsync();

JObject jObject = JObject.Parse(responseBody);
Dictionary<string, List<Order>> dict =
    jObject.ToObject<Dictionary<string, List<Order>>>( */

// Console.WriteLine(results.source_text);





/*
// Адрес ресурса, к которому выполняется запрос
string url = "http://127.0.0.1:8000/PM/";

// Создаём объект WebClient
using (var webClient = new WebClient())
{
    // Выполняем запрос по адресу и получаем ответ в виде строки
    var response = webClient.DownloadString(url);
    //var items = JObject.Parse(JSON_RESPONSE)["items"].ToObject<Account[]>();

    label1.Content = response;
}
*/


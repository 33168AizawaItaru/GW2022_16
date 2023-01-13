
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static BookSearch.RakutenApi;
using static BookSearch.SearchResult;
using static BookSearch.SearchConnect;

namespace BookSearch
{
    /// <summary>
    /// SearchWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SearchWindow : Window
    {
        SearchConnect sc = new SearchConnect();
        WebClient wc = new WebClient(){Encoding = Encoding.UTF8};
        string dString;


        public SearchWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow();
            menu.Show();
            this.Close();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SearchConnect();
            DataContext = sc;

            if (text.Text.Count() < 1)
            {
                MessageBox.Show("タイトルが入力されていません。");
            } else
            {
                var url = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json&applicationId=1074422515641226717.json";

                dString = wc.DownloadString(url);
                var json = JsonConvert.DeserializeObject<Rootobject>(dString);

                var betweenText = json.Items[0].Items.titleKana;

                sc.titleInput = betweenText;

                SearchResult sr = new SearchResult();
                sr.Show();
                Search.Close();
            }
        }
    }
}
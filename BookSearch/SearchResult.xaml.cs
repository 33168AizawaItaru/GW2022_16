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
using static BookSearch.SearchWindow;

namespace BookSearch
{
    /// <summary>
    /// SearchResult.xaml の相互作用ロジック
    /// </summary>
    public partial class SearchResult : Window
    {
        WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
        string dString;
        public SearchResult()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow search = new SearchWindow();
            search.Show();
            this.Close();
        }

        public string Window2 { get; set; }

        private void Result_Loaded(object sender, RoutedEventArgs e)
        {
            var url = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json&applicationId=1074422515641226717";

            dString = wc.DownloadString(url);
            var json = JsonConvert.DeserializeObject<Rootobject>(dString);

            SearchConnect sc = new SearchConnect();
            DataContext = sc;

            var betweenTitle = json.Items[0].Item.title;
            sc.titleInput = betweenTitle;

            var betweenSubTitle = json.Items[0].Item.subTitle;
            sc.subTitleInput = betweenSubTitle;

            var betweenAuthor = json.Items[0].Item.author;
            sc.authorInput = betweenAuthor;

            var betweenPublisherName = json.Items[0].Item.publisherName;
            sc.publisherNameInput = betweenPublisherName;

            var betweenSalesDate = json.Items[0].Item.salesDate;
            sc.salesDateInput = betweenSalesDate;

            var betweenItemPrice = json.Items[0].Item.itemPrice;
            sc.itemPriceInput = betweenItemPrice;

            var betweenReviewAverage = json.Items[0].Item.reviewAverage;
            sc.reviewAverageInput = betweenReviewAverage;

            var betweenReviewCount = json.Items[0].Item.reviewCount;
            sc.reviewCountInput = betweenReviewCount;
        }
    }
}
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
        string url;
        string dString;
        Rootobject json;
        string pass;
        BitmapImage m_bitmap = null;
        string passId;

        infosys202215DataSet1 infosys202215DataSet1;
        infosys202215DataSet1TableAdapters.BookMarkTableAdapter BookMarkTableAdapter;
        CollectionViewSource bookMarkViewSource;

        infosys202215DataSet infosys202215DataSet;
        infosys202215DataSetTableAdapters.BookHistoryTableAdapter BookHistoryTableAdapter;
        CollectionViewSource bookHistoryViewSource;

        public SearchResult()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow search = new SearchWindow();
            search.passUserId(passId);
            search.Show();
            Result.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            DataRow dr = (DataRow)infosys202215DataSet1.BookMark.NewRow();

            dr[1] = passId;
            dr[2] = title.Text;
            dr[3] = subTitle.Text;
            dr[4] = author.Text;
            dr[5] = publisherName.Text;
            dr[6] = salesDate.Text;
            dr[7] = itemPrice.Text;
            dr[8] = reviewAverage.Text;
            dr[9] = reviewCount.Text;

            infosys202215DataSet1.BookMark.Rows.Add(dr);
            BookMarkTableAdapter.Update(infosys202215DataSet1.BookMark);
        }

        public void passTitle(string strData)
        {
            pass = strData;
        }

        public void passUserId(string strData)
        {
            passId = strData;
        }

        public string Window2 { get; set; }

        private void Result_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pass != null)
                {
                    url = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json" + "&title=" + pass + "&applicationId=1074422515641226717";
                    dString = wc.DownloadString(url);
                    json = JsonConvert.DeserializeObject<Rootobject>(dString);
                }
            } catch (System.Net.WebException)
            {
            }

            if (json != null)
            {
                try
                {
                    title.Text = json.Items[0].Item.title;
                    subTitle.Text = json.Items[0].Item.subTitle;
                    author.Text = json.Items[0].Item.author;
                    publisherName.Text = json.Items[0].Item.publisherName;
                    salesDate.Text = json.Items[0].Item.salesDate;
                    itemPrice.Text = json.Items[0].Item.itemPrice.ToString();
                    reviewAverage.Text = json.Items[0].Item.reviewAverage;
                    reviewCount.Text = json.Items[0].Item.reviewCount.ToString();
                    if (title.Text == ""){subTitle.Text = "データがありません";}
                    if (subTitle.Text == "") { subTitle.Text = "データがありません"; }
                    if (author.Text == "") { subTitle.Text = "データがありません"; }
                    if (publisherName.Text == "") { subTitle.Text = "データがありません"; }
                    if (salesDate.Text == "") { subTitle.Text = "データがありません"; }
                    if (itemPrice.Text == "") { subTitle.Text = "データがありません"; }
                    if (reviewAverage.Text == "") { subTitle.Text = "データがありません"; }
                    if (reviewCount.Text == "") { subTitle.Text = "データがありません"; }
                    var betweenPicture = json.Items[0].Item.largeImageUrl;
                    var pUrl = betweenPicture.Replace("?", "　");
                    var index = pUrl.IndexOf("　");
                    var pictureUrl = pUrl.Substring(0, index);
                    var path = pictureUrl;
                    m_bitmap = new BitmapImage();
                    m_bitmap.BeginInit();
                    m_bitmap.UriSource = new Uri(path);
                    m_bitmap.EndInit();
                    picture.Source = m_bitmap;
                } catch (System.NullReferenceException)
                {
                    MessageBox.Show("検索出来ません");
                    SearchWindow search = new SearchWindow();
                    Result.Close();
                    search.Show();
                }
            }
            

            infosys202215DataSet1 = ((BookSearch.infosys202215DataSet1)(this.FindResource("infosys202215DataSet1")));
            // テーブル BookMark にデータを読み込みます。必要に応じてこのコードを変更できます。
            BookMarkTableAdapter = new BookSearch.infosys202215DataSet1TableAdapters.BookMarkTableAdapter();
            BookMarkTableAdapter.Fill(infosys202215DataSet1.BookMark);
            bookMarkViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bookMarkViewSource")));
            bookMarkViewSource.View.MoveCurrentToFirst();

            infosys202215DataSet = ((BookSearch.infosys202215DataSet)(this.FindResource("infosys202215DataSet")));
            // テーブル BookHistory にデータを読み込みます。必要に応じてこのコードを変更できます。
            BookHistoryTableAdapter = new BookSearch.infosys202215DataSetTableAdapters.BookHistoryTableAdapter();
            BookHistoryTableAdapter.Fill(infosys202215DataSet.BookHistory);
            bookHistoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bookHistoryViewSource")));
            bookHistoryViewSource.View.MoveCurrentToFirst();

            DataRow dr = (DataRow)infosys202215DataSet.BookHistory.NewRow();
            dr[0] = passId;
            dr[1] = title.Text;
            dr[2] = subTitle.Text;
            dr[3] = author.Text;
            dr[4] = publisherName.Text;
            dr[5] = salesDate.Text;
            dr[6] = itemPrice.Text;
            dr[7] = reviewAverage.Text;
            dr[8] = reviewCount.Text;

            infosys202215DataSet.BookHistory.Rows.Add(dr);
            BookHistoryTableAdapter.Update(infosys202215DataSet.BookHistory);
        }
    }
}
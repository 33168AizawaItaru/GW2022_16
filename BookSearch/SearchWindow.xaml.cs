﻿
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BookSearch
{
    /// <summary>
    /// SearchWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SearchWindow : Window
    {
        ObservableCollection<Book> books = new ObservableCollection<Book>();
        WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
        string url;
        string dString;
        Rootobject json;
        string title;
        string passId;
        string str = @"[a-z\d-.]+";

        public SearchWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow();
            menu.passUserId(passId);
            menu.Show();
            Search.Close();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            title = text.Text;

            if (text.Text.Count() < 1)
            {
                MessageBox.Show("タイトルが入力されていません。");
            }else
            {
                try
                {
                    url = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json" + "&title=" + title + "&applicationId=1074422515641226717";
                    dString = wc.DownloadString(url);
                    json = JsonConvert.DeserializeObject<Rootobject>(dString);

                    for (int i = 0; i < json.hits; i++)
                    {
                        books.Add(new Book() { Title = json.Items[i].Item.title });
                    }

                    foreach (var item in books)
                    {
                        list.Items.Add(item);
                    }
                } catch (Exception)
                {
                    MessageBox.Show("使えない文字があります。");
                }
            }
        }

        private void decision_Click(object sender, RoutedEventArgs e)
        {
            if (passTitle.Text != "")
            {
                SearchResult sr = new SearchResult();
                sr.passUserId(passId);
                sr.passTitle(passTitle.Text);
                sr.Show();
                Search.Close();
            }
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(text.Text == ""))
            {
                if (list.Items.Count > 0)
                {
                    list.Items.Clear();
                    books.Clear();
                    passTitle.Text = "";
                }
            }
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(list.SelectedItem == null))
            {
                Book book = (Book)list.SelectedItem;
                passTitle.Text = book.Title.ToString();
            }
        }

        public void passUserId(string strData)
        {
            passId = strData;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    class Book
    {
        public object Title { get; set; }
    }
}
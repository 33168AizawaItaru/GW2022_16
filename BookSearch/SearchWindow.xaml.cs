
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public SearchWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            list.ColumnHeader.Rows[0].Height = 90;
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow();
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
                url = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json" + "&title=" + title + "&applicationId=1074422515641226717";
                dString = wc.DownloadString(url);
                json = JsonConvert.DeserializeObject<Rootobject>(dString);

                var window = new SearchResult();
                window.title.Text = text.Text;

                for (int i = 0; i < json.hits; i++)
                {
                    books.Add(new Book() { Title = json.Items[i].Item.title });
                }

                foreach (var item in books)
                {
                    list.Items.Add(item);
                }
            }
        }

        private void decision_Click(object sender, RoutedEventArgs e)
        {
            SearchResult sr = new SearchResult();
            sr.passTitle(passTitle.Text);
            sr.Show();
            Search.Close();
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(text.Text == null))
            {
                if (list.Items.Count > 0)
                {
                    list.Items.Clear();
                    books.Clear();
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
    }

    class Book
    {
        public object Title { get; set; }
    }
}
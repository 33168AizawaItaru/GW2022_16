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
using System.Windows.Shapes;

namespace BookSearch
{
    /// <summary>
    /// MenuWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Menu.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow search = new SearchWindow();
            search.Show();
            Menu.Close();
        }

        private void Bookmark_Click(object sender, RoutedEventArgs e)
        {
            BookmarkWindow bookmark = new BookmarkWindow();
            bookmark.Show();
            Menu.Close();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            HistoryWindow history = new HistoryWindow();
            history.Show();
            Menu.Close();
        }
    }
}
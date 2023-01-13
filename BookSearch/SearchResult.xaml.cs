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
    /// SearchResult.xaml の相互作用ロジック
    /// </summary>
    public partial class SearchResult : Window
    {
        SearchConnect sc = new SearchConnect();
        public SearchResult()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            DataContext = new SearchConnect();
            DataContext = sc;
            sc.titleInput = "123";
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow search = new SearchWindow();
            search.Show();
            this.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
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
    /// BookmarkWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class BookmarkWindow : Window
    {
        infosys202215DataSet infosys202215DataSet;
        infosys202215DataSetTableAdapters.BookMarkTableAdapter BookMarkTableAdapter;
        CollectionViewSource bookMarkViewSource;

        public BookmarkWindow()
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

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView)bookMarkViewSource.View.CurrentItem;
                drv.Delete();
                BookMarkTableAdapter.Update(infosys202215DataSet.BookMark);
            } catch (Exception)
            {
            }
        }

        

        private void Bookmark_Loaded(object sender, RoutedEventArgs e)
        {
            infosys202215DataSet = ((BookSearch.infosys202215DataSet)(this.FindResource("infosys202215DataSet")));
            // テーブル BookMark にデータを読み込みます。必要に応じてこのコードを変更できます。
            BookMarkTableAdapter = new BookSearch.infosys202215DataSetTableAdapters.BookMarkTableAdapter();
            BookMarkTableAdapter.Fill(infosys202215DataSet.BookMark);
            bookMarkViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bookMarkViewSource")));
            bookMarkViewSource.View.MoveCurrentToFirst();
        }
    }
}
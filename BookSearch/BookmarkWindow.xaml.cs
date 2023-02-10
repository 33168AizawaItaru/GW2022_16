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
        string passId;

        infosys202215DataSet1 infosys202215DataSet1;
        infosys202215DataSet1TableAdapters.BookMarkTableAdapter BookMarkTableAdapter;
        CollectionViewSource bookMarkViewSource;

        public BookmarkWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow();
            menu.passUserId(passId);
            menu.Show();
            this.Close();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView)bookMarkViewSource.View.CurrentItem;
                drv.Delete();
                
            } catch (Exception)
            {
            }
            BookMarkTableAdapter.Update(infosys202215DataSet1.BookMark);

            if (bookMarkDataGrid.Items.Count == 0)
            {
                delete.IsEnabled = false;
            }
        }

        public void passUserId(string strData)
        {
            passId = strData;
        }

        private void Bookmark_Loaded(object sender, RoutedEventArgs e)
        {
            infosys202215DataSet1 = ((BookSearch.infosys202215DataSet1)(this.FindResource("infosys202215DataSet1")));
            // テーブル BookMark にデータを読み込みます。必要に応じてこのコードを変更できます。
            BookMarkTableAdapter = new BookSearch.infosys202215DataSet1TableAdapters.BookMarkTableAdapter();
            BookMarkTableAdapter.Fill(infosys202215DataSet1.BookMark);
            bookMarkViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bookMarkViewSource")));
            bookMarkViewSource.View.MoveCurrentToFirst();
        }
    }
}
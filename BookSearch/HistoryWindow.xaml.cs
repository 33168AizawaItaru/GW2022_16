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
    /// HistoryWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class HistoryWindow : Window
    {
        string passId;

        infosys202215DataSet infosys202215DataSet;
        infosys202215DataSetTableAdapters.BookHistoryTableAdapter BookHistoryTableAdapter;
        CollectionViewSource bookHistoryViewSource;

        public HistoryWindow()
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

        public void passUserId(string strData)
        {
            passId = strData;
        }

        private void History_Loaded(object sender, RoutedEventArgs e)
        {

            infosys202215DataSet = ((BookSearch.infosys202215DataSet)(this.FindResource("infosys202215DataSet")));
            // テーブル BookHistory にデータを読み込みます。必要に応じてこのコードを変更できます。
            BookHistoryTableAdapter = new BookSearch.infosys202215DataSetTableAdapters.BookHistoryTableAdapter();
            BookHistoryTableAdapter.Fill(infosys202215DataSet.BookHistory);
            bookHistoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bookHistoryViewSource")));
            bookHistoryViewSource.View.MoveCurrentToFirst();
        }

        

        
    }
}
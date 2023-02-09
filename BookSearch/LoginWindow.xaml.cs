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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookSearch
{
    /// <summary>
    /// LoginWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class LoginWindow : Window
    {
        infosys202215DataSet3 infosys202215DataSet3;
        infosys202215DataSet3TableAdapters.UserLoginTableAdapter UserLoginTableAdapter;
        CollectionViewSource userLoginViewSource;

        public LoginWindow()
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.None;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            LoginWindow1.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            DataTable dTable;
            dTable = infosys202215DataSet3.Tables["UserLogin"];

            
            foreach (DataRow item in dTable.Rows)
            {
                Console.WriteLine(item["UserId"].ToString(),
                    item["UserPass"].ToString());

                if (InputId.Text == item["UserId"].ToString() && InputPass.Password == item["UserPass"].ToString())
                {
                    MenuWindow menu = new MenuWindow();
                    menu.Show();
                    LoginWindow1.Close();
                    return;
                }

                if (item == infosys202215DataSet3.UserLogin.Last())
                {
                    MessageBox.Show("ユーザー名、もしくはパスワードが違います。");
                    InputPass.Clear();
                }
            }
        }

        private void newRegi_Click(object sender, RoutedEventArgs e)
        {
            RegistWindow rw = new RegistWindow();
            rw.Show();
            LoginWindow1.Close();
        }

        private void LoginWindow1_Loaded(object sender, RoutedEventArgs e)
        {

            infosys202215DataSet3 = ((BookSearch.infosys202215DataSet3)(this.FindResource("infosys202215DataSet3")));
            // テーブル UserLogin にデータを読み込みます。必要に応じてこのコードを変更できます。
            UserLoginTableAdapter = new BookSearch.infosys202215DataSet3TableAdapters.UserLoginTableAdapter();
            UserLoginTableAdapter.Fill(infosys202215DataSet3.UserLogin);
            userLoginViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userLoginViewSource")));
            userLoginViewSource.View.MoveCurrentToFirst();
        }
    }
}
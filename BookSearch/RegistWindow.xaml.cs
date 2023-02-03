using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

namespace BookSearch
{
    /// <summary>
    /// RegistWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class RegistWindow : Window
    {
        infosys202215DataSet2 infosys202215DataSet2;
        infosys202215DataSet2TableAdapters.UserLoginTableAdapter UserLoginTableAdapter;
        CollectionViewSource userLoginViewSource;

        public RegistWindow()
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.None;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            Regist.Close();
        }

        private void regist_Click(object sender, RoutedEventArgs e)
        {
            string str = @"/[a-z]/";
            string num = @"/[0-9]/";

            if (!(name.Text == null))
            {
                if (passDenote.Password.Length >= 8 && passDenote.Password.Length <= 16)
                {
                    if (Regex.IsMatch(name.Text, str))
                    {
                        if (Regex.IsMatch(passDenote.Password, str) && Regex.IsMatch(passDenote.Password, num))
                        {
                            if (!(name.Text.Contains(" ")) && !(passDenote.Password.Contains(" ")))
                            {

                            }
                        }
                    }
                }
            }

            //DataRow dr = (DataRow)infosys202215DataSet2.UserLogin.NewRow();
            //dr[1] = name.Text;
            //dr[2] = passDenote.Password;
            //infosys202215DataSet2.UserLogin.Rows.Add(dr);
            //UserLoginTableAdapter.Update(infosys202215DataSet2.UserLogin);
        }

        private void hide_Click(object sender, RoutedEventArgs e)
        {
            if (passDenote.Visibility == Visibility.Visible)
            {
                passHide.Visibility = Visibility.Visible;
                passDenote.Visibility = Visibility.Hidden;
                passHide.Text = passDenote.Password;
            } else
            {
                passDenote.Visibility = Visibility.Visible;
                passHide.Visibility = Visibility.Hidden;
                passDenote.Password = passHide.Text;
            }

            if (confirm.Visibility == Visibility.Visible)
            {
                denote.Visibility = Visibility.Visible;
                confirm.Visibility = Visibility.Hidden;
                denote.Text = confirm.Password;
            } else
            {
                confirm.Visibility = Visibility.Visible;
                denote.Visibility = Visibility.Hidden;
                confirm.Password = denote.Text;
            }
        }

        private void Regist_Loaded(object sender, RoutedEventArgs e)
        {

            infosys202215DataSet2 = ((BookSearch.infosys202215DataSet2)(this.FindResource("infosys202215DataSet2")));
            // テーブル UserLogin にデータを読み込みます。必要に応じてこのコードを変更できます。
            UserLoginTableAdapter = new BookSearch.infosys202215DataSet2TableAdapters.UserLoginTableAdapter();
            UserLoginTableAdapter.Fill(infosys202215DataSet2.UserLogin);
            userLoginViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userLoginViewSource")));
            userLoginViewSource.View.MoveCurrentToFirst();
        }
    }
}
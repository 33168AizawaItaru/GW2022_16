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
        infosys202215DataSet3 infosys202215DataSet3;
        infosys202215DataSet3TableAdapters.UserLoginTableAdapter UserLoginTableAdapter;
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

        private void passClear()
        {
            passDenote.Password = "";
            passHide.Text = "";
            rePassDenote.Password = "";
            rePassHide.Text = "";
        }

        private void regist_Click(object sender, RoutedEventArgs e)
        {
            string str = @"[a-z\d-.]+";
            DataRow dr = (DataRow)infosys202215DataSet3.UserLogin.NewRow();

            DataTable dTable;
            dTable = infosys202215DataSet3.Tables["UserLogin"];

            if (!(name.Text == null && passDenote.Password == null && rePassDenote.Password == null))
            {
                if (passDenote.Password.Length >= 8 && passDenote.Password.Length <= 16)
                {
                    if (Regex.IsMatch(name.Text, str, RegexOptions.IgnoreCase) && Regex.IsMatch(passDenote.Password, str, RegexOptions.IgnoreCase))
                    {
                        if (passDenote.Password == rePassDenote.Password || passHide.Text == rePassHide.Text)
                        {
                            foreach (DataRow dtRow in dTable.Rows)
                            {
                                if (!(name.Text == dtRow[0].ToString()) && !(passDenote.Password == dtRow[1].ToString()))
                                {
                                    dr[0] = name.Text;
                                    dr[1] = passDenote.Password;
                                    infosys202215DataSet3.UserLogin.Rows.Add(dr);
                                    UserLoginTableAdapter.Update(infosys202215DataSet3.UserLogin);
                                } else
                                {
                                    MessageBox.Show("既に存在しています。");
                                    passClear();
                                    return;
                                }
                            }
                        } else
                        {
                            MessageBox.Show("パスワードが一致していません。");
                            passClear();
                        }
                    } else
                    {
                        MessageBox.Show("半角英字、数字、記号で入力してください。");
                        passClear();
                    }
                } else
                {
                    MessageBox.Show("文字数が足りてる、又は多くなっています。");
                    passClear();
                }
            } else
            {
                MessageBox.Show("ユーザー名かパスワードが入力されていません。");
                passClear();
            }


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

            if (rePassDenote.Visibility == Visibility.Visible)
            {
                rePassHide.Visibility = Visibility.Visible;
                rePassDenote.Visibility = Visibility.Hidden;
                rePassHide.Text = rePassDenote.Password;
            } else
            {
                rePassDenote.Visibility = Visibility.Visible;
                rePassHide.Visibility = Visibility.Hidden;
                rePassDenote.Password = rePassHide.Text;
            }
        }

        private void Regist_Loaded(object sender, RoutedEventArgs e)
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
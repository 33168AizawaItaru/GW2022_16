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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookSearch
{
    /// <summary>
    /// LoginWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class LoginWindow : Window
    {
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
            var num = "1111";

            if (InputId.Text == num && InputPass.Password == num)
            {
                MenuWindow menu = new MenuWindow();
                menu.Show();
                LoginWindow1.Close();
            } else
            {
                MessageBox.Show("ID、もしくはパスワードが違います。");
                InputPass.Clear();
            }
        }

        private void newRegi_Click(object sender, RoutedEventArgs e)
        {
            RegistWindow rw = new RegistWindow();
            rw.Show();
            LoginWindow1.Close();
        }
    }
}
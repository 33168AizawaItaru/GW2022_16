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
    /// RegistWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class RegistWindow : Window
    {
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

        }
    }
}

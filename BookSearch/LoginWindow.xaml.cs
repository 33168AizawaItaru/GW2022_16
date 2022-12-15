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
        private NavigationService _navi;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private List<Uri> _uriList = new List<Uri>() {
            new Uri("Page1.xaml",UriKind.Relative),
            //new Uri("Page2.xaml",UriKind.Relative),
            //new Uri("Page3.xaml",UriKind.Relative),
        };

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow1.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
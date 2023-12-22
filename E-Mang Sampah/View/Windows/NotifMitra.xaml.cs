using E_Mang_Sampah.Services.Navigation;
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

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for NotifMitra.xaml
    /// </summary>
    public partial class NotifMitra : Window
    {
        NavigationManager navigationManager;
        public NotifMitra()
        {
            InitializeComponent();
            navigationManager = new NavigationManager(this);
        }

        private void BtnMinimized_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClosed_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SureBtn_Click(object sender, RoutedEventArgs e)
        {
            navigationManager.NavigateWindow(new Company_SignUp());
        }

        private void NopeBtn_Click(object sender, RoutedEventArgs e)
        {
            navigationManager.NavigateWindow(new SignUpView());
        }
    }
}

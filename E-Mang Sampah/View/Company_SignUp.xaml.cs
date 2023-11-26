using E_Mang_Sampah.Model;
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
using WpfApp1;

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for Company_SignUp.xaml
    /// </summary>
    public partial class Company_SignUp : Window
    {
        EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
        NavigationManager navigationManager;
        public Company_SignUp()
        {
            InitializeComponent();
            navigationManager = new NavigationManager(this);
        }
        private void Windows_Mouse(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void BtnMinimized_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClosed_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnLogin2_Click(object sender, RoutedEventArgs e)
        {
            navigationManager.NavigateWindow(new LoginView());
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {

            navigationManager.NavigateWindow(new LoginView());
        }
    }
}

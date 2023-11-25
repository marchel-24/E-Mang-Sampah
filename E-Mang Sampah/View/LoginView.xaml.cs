using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
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
using E_Mang_Sampah;
using E_Mang_Sampah.Model;
using E_Mang_Sampah.Services.Authentication;
using E_Mang_Sampah.Services.Navigation;
using E_Mang_Sampah.View;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
        NavigationManager navigationManager;
        ValidationManager validationManager;
        public LoginView()
        {
            InitializeComponent();
            navigationManager = new NavigationManager(this);
            validationManager = new ValidationManager(db);
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

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (validationManager.Validate(TxtUsername.Text, TxtPassword.Password))
            {
                navigationManager.NavigateWindow(new MainWindow());
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            navigationManager.NavigateWindow(new SignUpView());
        }
    }
}

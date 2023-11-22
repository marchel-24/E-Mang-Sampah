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
using E_Mang_Sampah;
using E_Mang_Sampah.View;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class Login : Window
    {
        EmangSampahEntities db = new EmangSampahEntities();
        public Login()
        {
            InitializeComponent();
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
            if (db.Accounts.Where(r => r.Username == TxtUsername.Text && r.Password == TxtPassword.Password).Count() > 0)
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpView sign = new SignUpView();
            sign.Show();
            this.Hide();
        }
    }
}

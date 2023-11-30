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
using E_Mang_Sampah.Model;
using E_Mang_Sampah.Services.Navigation;
using WpfApp1;

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : Window
    {
       EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
        NavigationManager navigationManager;
        public SignUpView()
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

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            string firstName = TxtFirstname.Text;
            string lastName = TxtLastname.Text;
            string username = TxtUsername.Text;
            string password = TxtPassword.Password;
            if (db.Accounts.Where(r => r.Username == username).Count() > 0)
            {
                MessageBox.Show("Username has already been taken", "Invalid");
                TxtFirstname.Text = "";
                TxtLastname.Text = "";
                TxtUsername.Text = "";
                TxtPassword.Password = "";
                return;
            }
            var userAcc = new UserAccount { FirstName = firstName, LastName = lastName, Username = username, Password = password };
            db.Accounts.Add(userAcc);
            db.SaveChanges();
            MessageBox.Show("Sign Up Succeeded", "Sign Up");
            navigationManager.NavigateWindow(new LoginView());
        }
        private void BtnLogin2_Click(object sender, RoutedEventArgs e)
        {
            navigationManager.NavigateWindow(new LoginView());
        }
    }
}

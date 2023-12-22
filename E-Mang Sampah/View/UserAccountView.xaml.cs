using E_Mang_Sampah.Model;
using E_Mang_Sampah.Services.Navigation;
using E_Mang_Sampah.Services.Session;
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
using WpfApp1;

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for UserAccountView.xaml
    /// </summary>
    public partial class UserAccountView : UserControl
    {
        EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
        NavigationManager navigationManager;

        public UserAccountView()
        {
            InitializeComponent();
            SetTextInCodeBehind();
            navigationManager = new NavigationManager(SessionData.CurrentWindow);
        }

        private void SetTextInCodeBehind()
        {
            if (SessionData.CurrentAccount is PartnerAccount)
            {
                NameLabel.Text = "Hello, " + ((PartnerAccount)SessionData.CurrentAccount).CompanyName;
            }
            else if (SessionData.CurrentAccount is UserAccount)
            {
                NameLabel.Text = "Hello, " + ((UserAccount)SessionData.CurrentAccount).GetFullName();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var editAccount = db.Accounts.OfType<UserAccount>().FirstOrDefault(r => r.Username == SessionData.CurrentAccount.Username);
            editAccount.FirstName = FirstNameLabel.Text;
            editAccount.LastName = LastNameLabel.Text;
            editAccount.Username = UsernameLabel.Text;
            editAccount.Password = PasswordLabel.Text;
            editAccount.Xp = ((UserAccount)SessionData.CurrentAccount).Xp;
            db.SaveChanges();
            SessionData.CurrentAccount = editAccount;
            ((MainWindow)SessionData.CurrentWindow).SetTextInCodeBehind();
            SetTextInCodeBehind();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            FirstNameLabel.Text = "";
            LastNameLabel.Text = "";
            UsernameLabel.Text = "";
            PasswordLabel.Text = "";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var delAccount = db.Accounts.OfType<UserAccount>().FirstOrDefault(r => r.Username == SessionData.CurrentAccount.Username);
            //var delOrder = db.Orders.Where()
            db.Accounts.Remove(delAccount);
            db.SaveChanges();
            MessageBox.Show("Your account has been deleted", "Delete");
            navigationManager.NavigateWindow(new LoginView());
        }
    }
}

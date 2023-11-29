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
    /// Interaction logic for UserAccount.xaml
    /// </summary>
    public partial class PartnerAccountView : UserControl
    {
        EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
        NavigationManager navigationManager;
        public PartnerAccountView()
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
            var editAccount = db.Accounts.OfType<PartnerAccount>().FirstOrDefault(r => r.Username == SessionData.CurrentAccount.Username);
            editAccount.CompanyName = CompanyNameLabel.Text;
            editAccount.Username = UsernameLabel.Text;
            editAccount.Password = PasswordLabel.Text;
            db.SaveChanges();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CompanyNameLabel.Text = "";
            UsernameLabel.Text = "";
            PasswordLabel.Text = "";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var delAccount = db.Accounts.OfType<PartnerAccount>().FirstOrDefault(r => r.Username == SessionData.CurrentAccount.Username);
            db.Accounts.Remove(delAccount);
            db.SaveChanges();
            MessageBox.Show("Your account has been deleted", "Delete");
            navigationManager.NavigateWindow(new LoginView());
        }
    }
}

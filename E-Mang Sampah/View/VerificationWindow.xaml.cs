using E_Mang_Sampah.Model;
using E_Mang_Sampah.Services.Authentication;
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
using System.Windows.Shapes;

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for VerificationWindow.xaml
    /// </summary>
    public partial class VerificationWindow : Window
    {
        EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
        ValidationManager validationManager;
        public static bool check = false;

        public VerificationWindow()
        {
            InitializeComponent();
            validationManager = new ValidationManager(db);
        }

        private void BtnVerification_Click(object sender, RoutedEventArgs e)
        {
            check = false;
            if (validationManager.Validate(TxtUsername.Text, TxtPassword.Password))
            {
                check = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid", "Login");
                check = false;
            }
        }
    }
}

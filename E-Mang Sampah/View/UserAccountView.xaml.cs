using E_Mang_Sampah.Model;
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

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for UserAccountView.xaml
    /// </summary>
    public partial class UserAccountView : UserControl
    {
        public UserAccountView()
        {
            InitializeComponent();
            SetTextInCodeBehind();
        }

        private void SetTextInCodeBehind()
        {
            if (SessionData.CurrentAccount is PartnerAccount)
            {
                NameLabel.Text = "Hello, " + ((PartnerAccount)SessionData.CurrentAccount).CompanyName;
            }
            else if (SessionData.CurrentAccount is UserAccount)
            {
                NameLabel.Text = "Hello, " + ((UserAccount)SessionData.CurrentAccount).FirstName + " " + ((UserAccount)SessionData.CurrentAccount).LastName;
            }
        }
    }
}

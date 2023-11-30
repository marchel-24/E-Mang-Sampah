using E_Mang_Sampah.Model;
using E_Mang_Sampah.ViewModel;
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
    /// Interaction logic for JunkPickForUser.xaml
    /// </summary>
    public partial class JunkPickForUser : UserControl
    {
        EmangSampahModelContainer1 db = new EmangSampahModelContainer1();

        public JunkPickForUser()
        {
            InitializeComponent();
            foreach (var partnerAccount in db.Accounts.OfType<PartnerAccount>())
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Header = partnerAccount.CompanyName;
                menuItem.Click += PartnersMenuItem_Click;
                PartnerMenu.Items.Add(menuItem);
            }
        }

        private void PartnersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem clickedMenuItem)
            {
                PartnerMenu.Header = clickedMenuItem.Header;
            }
        }



    }
}

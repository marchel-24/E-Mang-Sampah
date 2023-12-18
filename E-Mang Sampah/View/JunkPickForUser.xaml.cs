using E_Mang_Sampah.Model;
using E_Mang_Sampah.Services.Session;
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
using System.Device.Location;
using Microsoft.Maps.MapControl.WPF;

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for JunkPickForUser.xaml
    /// </summary>
    public partial class JunkPickForUser : UserControl
    {
        EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
        PartnerAccount choosenPartner = new PartnerAccount();

        public JunkPickForUser()
        {
            InitializeComponent();
            foreach (var partnerAccount in db.Accounts.OfType<PartnerAccount>())
            {
                MenuItem menuItem = new MenuItem();
                var pushPin = new Pushpin();
                var toolTip = new ToolTip();
                toolTip.Content = partnerAccount.CompanyName;
                pushPin.Location = new Location(partnerAccount.Latitude, partnerAccount.Longitude);
                ToolTipService.SetToolTip(pushPin, toolTip);
                menuItem.Header = partnerAccount.CompanyName;
                menuItem.Click += PartnersMenuItem_Click;
                PartnerMenu.Items.Add(menuItem);
                BingMap.Children.Add(pushPin);
            }
        }

        private void PartnersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem clickedMenuItem)
            {
                PartnerMenu.Header = clickedMenuItem.Header;
                choosenPartner = db.Accounts.OfType<PartnerAccount>().FirstOrDefault(r => r.CompanyName == clickedMenuItem.Header.ToString());
                BingMap.ZoomLevel = 18;
                BingMap.Center = new Location(choosenPartner.Latitude, choosenPartner.Longitude);
            }
        }

        private void BtnOrderForUser_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.PartnerAccount = choosenPartner;
            order.UserAccount = db.Accounts.OfType<UserAccount>().First(r => r.Username == SessionData.CurrentAccount.Username);
            order.OrderReqTime = DateTime.Now;
            order.Description = DescriptionSampah.Text;
            db.Orders.Add(order);
            db.SaveChanges();
            MessageBox.Show("Order Suceeded", "Order");
            if(SessionData.CurrentAccount is UserAccount)
            {
                ((UserAccount)SessionData.CurrentAccount).Xp += 20;
                ((MainWindow)SessionData.CurrentWindow).SetTextInCodeBehind();
            }
        }
    }
}

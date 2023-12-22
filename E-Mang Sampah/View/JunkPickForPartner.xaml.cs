using E_Mang_Sampah.Model;
using E_Mang_Sampah.Services.Session;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for JunkPickForPartner.xaml
    /// </summary>
    public partial class JunkPickForPartner : UserControl
    {
        int partnerId = ((PartnerAccount)SessionData.CurrentAccount).AccountId;
        EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
        ObservableCollection<Member> members = new ObservableCollection<Member>();
        public JunkPickForPartner()
        {
            InitializeComponent();
            List<UserAccount> accounts = new List<UserAccount>();

            //Create Info
            int n = 1;
            foreach (var orderAcc in db.Orders.Where(r => r.PartnerAccountId == partnerId))
            {

                if (!accounts.Contains(orderAcc.UserAccount))
                {
                    accounts.Add(orderAcc.UserAccount);
                }
                Member member = new Member { Id = orderAcc.OrderId, Number = n++.ToString(), Name = orderAcc.UserAccount.GetFullName(), Address = orderAcc.UserAccount.Address, Description = orderAcc.Description, Latitude = orderAcc.UserAccount.Latitude, Longitude = orderAcc.UserAccount.Longitude};
                
                if (orderAcc.Status == false)
                {
                    member.Status = "Belum Selesai";
                }
                else
                {
                    member.Status = "Selesai";
                }
                members.Add(member);
            }
            foreach (var account in accounts)
            {
                var pushPin = new Pushpin();
                var toolTip = new ToolTip();
                toolTip.Content = account.GetFullName();
                pushPin.Location = new Location(account.Latitude, account.Longitude);
                ToolTipService.SetToolTip(pushPin, toolTip);
                BingMap.Children.Add(pushPin);

            }
            memberDataGrid.ItemsSource = members;

            
        }

        private void memberDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
            if (memberDataGrid.SelectedItem is Member selectedMember)
            {
                var order = db.Orders.FirstOrDefault(r => r.OrderId == selectedMember.Id);
                BingMap.Center = new Location(selectedMember.Latitude, selectedMember.Longitude);
                order.Status = !order.Status;
                selectedMember.Status = order.Status ? "Selesai" : "Belum Selesai";
                db.SaveChanges();
            }
        }
    }

    public class Member : INotifyPropertyChanged
    {
        private string _status;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}

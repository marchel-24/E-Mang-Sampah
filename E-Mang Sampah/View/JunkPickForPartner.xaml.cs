﻿using E_Mang_Sampah.Model;
using E_Mang_Sampah.Services.Session;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public JunkPickForPartner()
        {
            InitializeComponent();
            ObservableCollection<Member> members = new ObservableCollection<Member>();
            List<UserAccount> accounts = new List<UserAccount>();

            //Create Info
            int n = 1;
            foreach (var orderAcc in db.Orders.Where(r => r.PartnerAccountId == partnerId))
            {

                if (!accounts.Contains(orderAcc.UserAccount))
                {
                    accounts.Add(orderAcc.UserAccount);
                }
                members.Add(new Member { Number = n++.ToString(), Name = orderAcc.UserAccount.GetFullName(), Address = orderAcc.UserAccount.Address, Description = orderAcc.Description, Status = "Selesai" });
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
    }

    public class Member
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}

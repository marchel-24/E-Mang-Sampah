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
        public JunkPickForPartner()
        {
            InitializeComponent();
           ObservableCollection<Member> members = new ObservableCollection<Member>();

            //Create Info
            members.Add(new Member { Number = "1", Name = "Edo", Position = "Rumah", Status = "Selesai" });
            memberDataGrid.ItemsSource = members;
        }
    }

    public class Member
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
    }
}

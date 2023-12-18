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
    /// Interaction logic for Community.xaml
    /// </summary>
    public partial class Community : UserControl
    {
        public Community()
        {
            InitializeComponent();
            SwitchToFirstUserControl();
        }

        private void SwitchUserControl_Click(object sender, RoutedEventArgs e)
        {
            // Toggle between FirstUserControl and SecondUserControl
            if (contentControl.Content is PostMain)
            {
                SwitchToSecondUserControl();
            }
            else
            {
                SwitchToFirstUserControl();
            }
        }

        private void SwitchToFirstUserControl()
        {
            contentControl.Content = new PostMain();
            ShowSwitchButton(true);
        }

        private void SwitchToSecondUserControl()
        {
            contentControl.Content = new MakePost();
            ShowSwitchButton(false);
        }

        private void ShowSwitchButton(bool show)
        {
            SwitchUserControl.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}

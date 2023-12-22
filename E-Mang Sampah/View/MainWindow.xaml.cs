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
using System.Runtime.InteropServices;    
using System.Windows.Interop;
using E_Mang_Sampah.Model;
using E_Mang_Sampah.Services.Session;
using E_Mang_Sampah.ViewModel;
using E_Mang_Sampah.Services.Navigation;
using E_Mang_Sampah.View;
using WpfApp1;

namespace E_Mang_Sampah
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NavigationManager navigationManager;
        public MainWindow()
        {
            InitializeComponent();
            SetTextInCodeBehind();
            navigationManager = new NavigationManager(this);
            SessionData.CurrentWindow = this;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public void SetTextInCodeBehind()
        {
            if(SessionData.CurrentAccount is PartnerAccount)
            {
                NameLabel.Text = ((PartnerAccount)SessionData.CurrentAccount).CompanyName;
            }
            else if(SessionData.CurrentAccount is UserAccount)
            {
                NameLabel.Text = ((UserAccount)SessionData.CurrentAccount).GetFullName();
                if (((UserAccount)SessionData.CurrentAccount).Xp < 10)
                {
                    XpLabel.Source = new BitmapImage(new Uri("pack://application:,,,/Images/10-order.png"));
                }
                else if (((UserAccount)SessionData.CurrentAccount).Xp < 50)
                {
                    XpLabel.Source = new BitmapImage(new Uri("pack://application:,,,/Images/50-order.png"));
                }
                else
                {
                    XpLabel.Source = new BitmapImage(new Uri("pack://application:,,,/Images/100-order.png"));
                }

            }
        }

        //Closed app when button clicked
        private void BtnClosed_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           WindowInteropHelper helper= new WindowInteropHelper(this);
           SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            navigationManager.NavigateWindow(new LoginView());
        }
    }
}

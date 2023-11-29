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

namespace E_Mang_Sampah
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetTextInCodeBehind();
            SessionData.CurrentWindow = this;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void Btn_Menu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SetTextInCodeBehind()
        {
            if(SessionData.CurrentAccount is PartnerAccount)
            {
                NameLabel.Text = ((PartnerAccount)SessionData.CurrentAccount).CompanyName;
            }
            else if(SessionData.CurrentAccount is UserAccount)
            {
                NameLabel.Text = ((UserAccount)SessionData.CurrentAccount).GetFullName();
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

        
    }
}

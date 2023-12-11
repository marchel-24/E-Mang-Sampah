using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
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
    /// Interaction logic for MakePost.xaml
    /// </summary>
    public partial class MakePost : UserControl
    {
        private byte[] _imageFile;
        public MakePost()
        {
            InitializeComponent();
        }

        private void btnUploadPicture_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _imageFile = File.ReadAllBytes(openFileDialog.FileName);
                tbPostImageURL.IsEnabled = false;
                tbPostImageURL.Text = "< Uploaded Image >";
            }
        }

        private void tbPostContent_TouchEnter(object sender, TouchEventArgs e)
        {

        }
    }
}

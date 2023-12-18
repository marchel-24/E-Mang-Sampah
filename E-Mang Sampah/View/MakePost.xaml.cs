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
using Microsoft.Win32;
using E_Mang_Sampah.Model;
using E_Mang_Sampah.Services.Session;

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for MakePost.xaml
    /// </summary>
    public partial class MakePost : UserControl
    {
        EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
        public event EventHandler<bool> ShowSwitchButtonChanged;
        private byte[] _imageFile = new byte[0];
        public MakePost()
        {
            InitializeComponent();
            ShowSwitchButtonChanged?.Invoke(this, false);
        }

        private void btnUploadPicture_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _imageFile = File.ReadAllBytes(openFileDialog.FileName);
                //tbPostImageURL.IsEnabled = false;
                //tbPostImageURL.Text = "< Uploaded Image >";
                DisplayImage();
            }
        }

        private void DisplayImage()
        {
            if (_imageFile != null && _imageFile.Length > 0)
            {
                using (var stream = new MemoryStream(_imageFile))
                {
                    BitmapImage imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = stream;
                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
                    imageSource.EndInit();

                    // Set the Source property of the Image control
                    imageControl.Source = imageSource;
                }

                //tbPostImageURL.IsEnabled = false;
                //tbPostImageURL.Text = "< Uploaded Image >";
            }
            else
            {
                MessageBox.Show("No image data available.");
            }
        }

        private void btnNewPost_Click(object sender, RoutedEventArgs e)
        {
            Posts post = new Posts();
            post.Account = db.Accounts.First(r => r.Username == SessionData.CurrentAccount.Username);
            post.LikesCount = 0;
            post.Content = tbPostContent.Text;
            post.UploadTime = DateTime.Now;
            post.Image = _imageFile;
            db.Posts.Add(post);
            db.SaveChanges();

        }
    }
}

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
using System.Security.Cryptography;
using E_Mang_Sampah.Services;
using ImageManager;

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
                imageControl.Source = ImageManager.ImageManager.GetImage(_imageFile);
            }
        }

        

        private void btnNewPost_Click(object sender, RoutedEventArgs e)
        {
            if((_imageFile == null || _imageFile.Length == 0) && (tbPostContent.Text == "" || tbPostContent.Text.Length == 0))
            {
                MessageBox.Show("Please input text or image", "Invalid");
            }
            else
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

        private void btnResetPost_Click(object sender, RoutedEventArgs e)
        {
            tbPostContent.Text = "";
            imageControl.Source = null;
            _imageFile = new byte[0];
        }
    }
}

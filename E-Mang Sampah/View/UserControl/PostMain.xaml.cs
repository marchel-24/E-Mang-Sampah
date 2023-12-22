using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using E_Mang_Sampah.Model;
using FontAwesome.Sharp;
using ImageManager;

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for PostMain.xaml
    /// </summary>
    public partial class PostMain : UserControl
    {
        EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
        public event EventHandler<bool> ShowBackButtonChanged;
        private bool isImage1 = true;
        string HexColorTitle = "#1b6b93";
        private Dictionary<int, TextBlock> textBlocksDictionary;
        public PostMain()
        {
            InitializeComponent();
            var posts = db.Posts;
            ShowBackButtonChanged?.Invoke(this, false);
            int counter = 1;
            textBlocksDictionary = new Dictionary<int, TextBlock>();

            foreach (var post in posts)
            {

                StackPanel sBorder = new StackPanel
                {
                    Margin = new Thickness(10, 0, 30, 10),
                };
                //sBorder.SetResourceReference(StackPanel.BackgroundProperty, "");
                spPosts.Children.Add(sBorder);

                StackPanel spMain = new StackPanel()
                {
                    Margin = new Thickness(3),
                    //Background = (Brush)bc.ConvertFrom("#FF202020")
                };
                sBorder.Children.Add(spMain);

                StackPanel spHeader = new StackPanel
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Orientation = Orientation.Horizontal
                };
                spMain.Children.Add(spHeader);

                

                StackPanel spDescription = new StackPanel
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness(0, 5, 3, 0)
                };
                spMain.Children.Add(spDescription);

                StackPanel spImage = new StackPanel
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness(10, 5, 10, 5)
                };
                spMain.Children.Add(spImage);

                StackPanel spFooter = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness(5, 2, 0, 1)
                };
                spMain.Children.Add(spFooter);

                string name;
                if(post.Account is PartnerAccount)
                {
                    name = ((PartnerAccount)post.Account).CompanyName;
                }
                else
                {
                    name = ((UserAccount)post.Account).GetFullName();
                }

                TextBlock tbTitle = new TextBlock
                {
                    Text = name,
                    //Tag = posts[i].userID,
                    FontSize = 18,
                    FontFamily = new FontFamily("Gilroy"),
                    FontWeight = FontWeights.DemiBold,

                    Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(HexColorTitle),
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 5, 0)
                };
                spHeader.Children.Add(tbTitle);

                string date = post.UploadTime.ToString();
                TextBlock tbDate = new TextBlock
                {
                    Text = date,
                    FontSize = 8,
                    FontFamily = new FontFamily("Arial"),
                    FontWeight = FontWeights.Light,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Gray")),
                    Opacity = 0.5,
                    VerticalAlignment = VerticalAlignment.Center
                };
                spHeader.Children.Add(tbDate);

                string description = post.Content;
                TextBlock tbDesc = new TextBlock
                {
                    Text = description,
                    FontSize = 12,
                    FontFamily = new FontFamily("Gilroy"),
                    FontWeight = FontWeights.Regular,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black")),
                    VerticalAlignment = VerticalAlignment.Center
                };
                spDescription.Children.Add(tbDesc);

                var imageSource = ImageManager.ImageManager.GetImage(post.Image);

                Image dynamicImageContent = new Image
                {
                    Source = imageSource
                };

                spImage.Children.Add(dynamicImageContent);

                TextBlock Count_like = new TextBlock
                {
                    Name = $"TextBlock{counter}",
                    Text = post.LikesCount.ToString(),
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black")),
                    FontFamily = new FontFamily("Arial"),
                    FontWeight = FontWeights.Regular,
                    FontSize = 10,

                };

                textBlocksDictionary.Add(counter, Count_like);

                Button likebutton = new Button
                {
                    Content = new Image
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/Images/Vector.png")),
                        Width = 20,
                        Height = 20,
                    },
                    Background = Brushes.Transparent,
                    BorderThickness = new Thickness(0),
                    Tag = Tuple.Create(post.PostsId, counter)

                };
                

                spFooter.Children.Add(likebutton);

                spFooter.Children.Add(Count_like);


                likebutton.Click += LikeButton_Click;

                Border border_Header = new Border
                    {
                        BorderBrush = Brushes.LightGray,
                        BorderThickness = new Thickness(0, 0, 0, 1),
                        Margin = new Thickness(0, 5, 0, 0)
                    };

                spMain.Children.Add(border_Header);
                counter++;
            }

            
        }
        private void LikeButton_Click(object sender, RoutedEventArgs e)
        {

            //// Mengakses elemen Image di dalam tombol
            Image myImage = (Image)((Button)sender).Content;
            Button button = sender as Button;
            Tuple<int, int> tagValue = button?.Tag as Tuple<int, int>;
            Posts post = db.Posts.FirstOrDefault(r => r.PostsId == tagValue.Item1);
            var targetTextBlock = textBlocksDictionary[tagValue.Item2];

            // Mengubah sumber gambar berdasarkan status
            if (isImage1)
            {
                myImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Vector-1.png"));


            }
            else
            {
                myImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Vector.png"));
            }

            post.AddLikes(isImage1);


            //db.SaveChanges();
            //// Mengubah status untuk digunakan pada klik berikutnya
            //isImage1 = !isImage1;

            //foreach (var entry in textBlocksDictionary)
            //{
            //    int key = entry.Key;
            //    TextBlock textBlock = entry.Value;

            //    MessageBox.Show($"Key: {key}, TextBlock Name: {textBlock.Name}, Text: {textBlock.Text}");
            //}

            //MessageBox.Show(tagValue.Item1.ToString());
            //MessageBox.Show(tagValue.Item2.ToString());

            //MessageBox.Show(textBlocksDictionary[tagValue.Item2].Name);

            //MessageBox.Show(targetTextBlock.Text);
            targetTextBlock.Text = post.LikesCount.ToString();

            db.SaveChanges();
            isImage1 = !isImage1;
        }
    }
}

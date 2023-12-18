using System;
using System.Collections.Generic;
using System.IO;
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
using E_Mang_Sampah.Model;
using FontAwesome.Sharp;

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for PostMain.xaml
    /// </summary>
    public partial class PostMain : UserControl
    {
        EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
        string HexColorTitle = "#1b6b93";
        public PostMain()
        {
            InitializeComponent();
            var posts = db.Posts;
            
            
            foreach(var post in posts)
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
                    Cursor = Cursors.Hand,
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

                BitmapImage imageSource = new BitmapImage();
                if (post.Image != null && post.Image.Length > 0)
                {
                    using (var stream = new MemoryStream(post.Image))
                    {
                        imageSource.BeginInit();
                        imageSource.StreamSource = stream;
                        imageSource.CacheOption = BitmapCacheOption.OnLoad;
                        imageSource.EndInit();
                    }
                }

                Image dynamicImageContent = new Image
                {
                    //Tag = ,
                    Source = imageSource
                };

                spImage.Children.Add(dynamicImageContent);

                CheckBox likeButton = new CheckBox
                {
                    Style = (Style)Application.Current.FindResource("CircularCheckBoxStyle")
                };
                spFooter.Children.Add(likeButton);

                

                TextBlock Count_like = new TextBlock
                {
                    Text = "Count",
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black")),
                    FontFamily = new FontFamily("Arial"),
                    FontWeight = FontWeights.Regular,
                    FontSize = 8,
                };
                spFooter.Children.Add(Count_like);

                    Border border_Header = new Border
                    {
                        BorderBrush = Brushes.LightGray,
                        BorderThickness = new Thickness(0, 0, 0, 1),
                        Margin = new Thickness(0, 5, 0, 0)
                    };

                spMain.Children.Add(border_Header);
            }
        }

        private void btnMakePost_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

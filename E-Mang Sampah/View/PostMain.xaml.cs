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
using FontAwesome.Sharp;

namespace E_Mang_Sampah.View
{
    /// <summary>
    /// Interaction logic for PostMain.xaml
    /// </summary>
    public partial class PostMain : UserControl
    {
        string HexColorTitle = "#1b6b93";
        public PostMain()
        {
            InitializeComponent();
            
            for(int i = 0; i < 10; i++)
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

            TextBlock tbTitle = new TextBlock
            {
                Text = "Nama",
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

            TextBlock tbDate = new TextBlock
            {
                Text = "Tanggal",
                FontSize = 8,
                FontFamily = new FontFamily("Arial"),
                FontWeight = FontWeights.Light,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Gray")),
                Opacity = 0.5,
                VerticalAlignment = VerticalAlignment.Center
            };
            spHeader.Children.Add(tbDate);

            TextBlock tbDesc = new TextBlock
            {
                Text = "Description",
                FontSize = 12,
                FontFamily = new FontFamily("Gilroy"),
                FontWeight = FontWeights.Regular,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black")),
                VerticalAlignment = VerticalAlignment.Center
            };
            spDescription.Children.Add(tbDesc);

            Image dynamicImageContent = new Image
            {
                //Tag = ,
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Stretch = Stretch.None,
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
    }
}

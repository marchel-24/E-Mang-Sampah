using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace E_Mang_Sampah.Services.ImageControl
{
    /// <summary>
    /// Provides methods for managing images.
    /// </summary>
    internal static class ImageManager
    {
        /// <summary>
        /// Converts a byte array representing an image to a <see cref="BitmapImage"/>.
        /// </summary>
        /// <param name="image">The byte array representing the image.</param>
        /// <returns>
        /// A <see cref="BitmapImage"/> representing the image.
        /// Returns <c>null</c> if the input byte array is <c>null</c> or empty.
        /// </returns>
        public static BitmapImage GetImage(byte[] image)
        {
            if (image != null && image.Length > 0)
            {
                using (var stream = new MemoryStream(image))
                {
                    BitmapImage imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = stream;
                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
                    imageSource.EndInit();
                    return imageSource;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
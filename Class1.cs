using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace Xiaowang0229
{
    namespace ImageLibrary
    {
        namespace WinUI
        {
            class Image
            {
                public static BitmapImage ByteArrayToBitmapImage(byte[] imageBytes)
                {
                    if (imageBytes == null || imageBytes.Length == 0) return null;

                    var bitmapImage = new BitmapImage();

                    using var stream = new InMemoryRandomAccessStream();
                    using (var writer = new DataWriter(stream.GetOutputStreamAt(0)))
                    {
                        writer.WriteBytes(imageBytes);
                        writer.StoreAsync().AsTask().GetAwaiter().GetResult();
                        writer.FlushAsync().AsTask().GetAwaiter().GetResult();
                    }

                    stream.Seek(0);
                    bitmapImage.SetSource(stream);  

                    return bitmapImage;
                }
            }
        }
    }
}

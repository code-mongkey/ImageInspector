using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageInspector.ImageLibrary
{
    public class ConvertImage
    {
        public Image ConvertColorToGrayscale(Image image)
        {
            Bitmap returnMap = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
            BitmapData bitmapData1 = ((Bitmap)image).LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* imagePointer = (byte*)bitmapData1.Scan0;
                int a = 0;
                for (int i = 0; i < bitmapData1.Height; i++)
                {
                    for (int j = 0; j < bitmapData1.Width; j++)
                    {
                        a = (imagePointer[0] + imagePointer[1] + imagePointer[2]) / 3;
                        imagePointer[0] = (byte)a;
                        imagePointer[1] = (byte)a;
                        imagePointer[2] = (byte)a;
                        imagePointer[3] = imagePointer[3];
                        imagePointer += 4;
                    }
                    imagePointer += bitmapData1.Stride - (bitmapData1.Width * 4);
                }
            }
            returnMap.UnlockBits(bitmapData1);
            return returnMap;
        }
    }
}

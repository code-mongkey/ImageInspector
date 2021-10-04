using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageInspector.ImageLibrary
{
    public static class CommonBase
    {
        public static Image CropImage(Image image, Rectangle rectangle)
        {
            return (Image)((Bitmap)image).Clone(rectangle, image.PixelFormat);
        }

        public static Image ConvertColorToGrayscale(Image image)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
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
            bmp.UnlockBits(bitmapData1);
            return bmp;
        }

        public static int GetHisto(Image image)
        {
            Bitmap bmp = new Bitmap(image);
            BitmapData bitmapData1 = ((Bitmap)bmp).LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            double total = 0;
            unsafe
            {
                byte* imagePointer = (byte*)bitmapData1.Scan0;
                int a = 0;
                for (int i = 0; i < bitmapData1.Height; i++)
                {
                    for (int j = 0; j < bitmapData1.Width; j++)
                    {
                        a = (imagePointer[0] + imagePointer[1] + imagePointer[2]) / 3;
                        imagePointer += 4;
                        total += a;
                    }
                    imagePointer += bitmapData1.Stride - (bitmapData1.Width * 4);
                }
            }
            bmp.UnlockBits(bitmapData1);
            return (int)(total / (bmp.Width * bmp.Height));
        }


    }
}
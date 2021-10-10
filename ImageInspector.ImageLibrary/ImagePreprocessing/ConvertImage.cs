using OpenCvSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace ImageInspector.ImageLibrary.ImagePreprocessing
{
    public static class ConvertImage
    {
        public static unsafe Image ConvertColorToGray(Image image)
        {
            Bitmap grayImage = new Bitmap(image);
            int width = grayImage.Width;
            int height = grayImage.Height;

            BitmapData bitmapData = grayImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bitmapData.Stride;
            System.IntPtr Scan0 = bitmapData.Scan0;
            byte* p = (byte*)(void*)Scan0;
            Parallel.For(0, height, y =>
            {
                Parallel.For(0, width, x =>
                {
                    int nPos = y * stride + x * 3;
                    //int blue = p[nPos + 0];
                    //int green = p[nPos + 1];
                    //int red = p[nPos + 2];
                    p[nPos + 0] = p[nPos + 1] = p[nPos + 2] = (byte)(.299 * p[nPos + 0] + .587 * p[nPos + 1] + .114 * p[nPos + 2]);
                });
            });

            grayImage.UnlockBits(bitmapData);

            return grayImage;
        }

        public static Image ConvertColorToGrayByOpenCV(Image image)
        {
            Mat src = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)image);
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            Image output = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(gray);
            return output;
        }

        public static unsafe Image ConvertGrayToBinary(Image image, int threshold)
        {
            Bitmap outputImage = new Bitmap(image);
            int width = outputImage.Width;
            int height = outputImage.Height;

            BitmapData bitmapData = outputImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bitmapData.Stride;
            System.IntPtr Scan0 = bitmapData.Scan0;
            byte* p = (byte*)(void*)Scan0;
            Parallel.For(0, height, y =>
            {
                Parallel.For(0, width, x =>
                {
                    int nPos = y * stride + x * 3;
                    //int blue = p[nPos + 0];
                    //int green = p[nPos + 1];
                    //int red = p[nPos + 2];
                    p[nPos] = p[nPos] <= threshold ? (byte)0 : (byte)255;

                    p[nPos + 0] = p[nPos + 1] = p[nPos + 2] = (byte)(.299 * p[nPos + 0] + .587 * p[nPos + 1] + .114 * p[nPos + 2]);
                });
            });

            outputImage.UnlockBits(bitmapData);

            return outputImage;
        }

        public enum RGB { B, G, R}
        public static unsafe Image ConvertColorToRGB(Image image, RGB value)
        {
            Bitmap outputImage = new Bitmap(image);
            int width = outputImage.Width;
            int height = outputImage.Height;

            BitmapData bitmapData = outputImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bitmapData.Stride;
            System.IntPtr Scan0 = bitmapData.Scan0;
            byte* p = (byte*)(void*)Scan0;
            Parallel.For(0, height, y =>
            {
                Parallel.For(0, width, x =>
                {
                    int nPos = y * stride + x * 3;
                    p[nPos + 0] = p[nPos + 1] = p[nPos + 2] = (byte)(p[nPos + (int)value]);
                });
            });

            outputImage.UnlockBits(bitmapData);

            return outputImage;
        }

        public static Image CropImage(Image image, Rectangle rectangle)
        {
            return (Image)((Bitmap)image).Clone(rectangle, image.PixelFormat);
        }
    }
}

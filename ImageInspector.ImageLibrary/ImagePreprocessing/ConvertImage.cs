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
    }
}

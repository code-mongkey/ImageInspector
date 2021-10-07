using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageInspector.ImageLibrary
{
    public class MyHistogram : CommonBase
    {
        public override Rectangle SEARCH_AREA { get; set; }
        public override object? RESULT { get; set; }
        public override Image INPUT_IMAGE { get; set; }
        public override Image OUTPUT_IMAGE { get; set; }

        private unsafe int GetHisto()
        {
            if (INPUT_IMAGE == null) return -1;

            long total = 0;
            try
            {
                Bitmap grayImage = new Bitmap(INPUT_IMAGE);

                BitmapData bitmapData = grayImage.LockBits(SEARCH_AREA, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int stride = bitmapData.Stride;
                System.IntPtr Scan0 = bitmapData.Scan0;
                byte* p = (byte*)(void*)Scan0;
                Parallel.For(SEARCH_AREA.Y, SEARCH_AREA.Y + SEARCH_AREA.Height, y =>
                {
                    Parallel.For(SEARCH_AREA.X, SEARCH_AREA.X + SEARCH_AREA.Width, x =>
                    {
                        int nPos = y * stride + x * 3;
                        total += (p[nPos + 0] + p[nPos + 1] + p[nPos + 2]) / 3;
                    });
                });

                grayImage.UnlockBits(bitmapData);
            }
            catch
            {
                return -1;
            }

            OUTPUT_IMAGE = new Bitmap(INPUT_IMAGE);

            int brightness = (int)(total / (SEARCH_AREA.Width * SEARCH_AREA.Height));
            return brightness;
        }

        public override int Run()
        {
            int ret = this.GetHisto();
            RESULT = ret.ToString();
            return ret == -1 ? 1 : 0;
        }
    }
}

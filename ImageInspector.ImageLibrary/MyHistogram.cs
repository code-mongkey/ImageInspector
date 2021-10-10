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
        public override object RESULT { get; set; }
        public override Image INSPECTION_IMAGE { get; set; }
        public override Rectangle SEARCH_AREA { get; set; }
        public override Rectangle FIND_AREA { get; set; }
        
        public MyHistogram()
        {
            RESULT = "";
            SEARCH_AREA = new Rectangle();
            FIND_AREA = new Rectangle();
        }

        private unsafe int GetHisto()
        {
            if (INSPECTION_IMAGE == null) return -1;
            object lockObject = new object();
            long total = 0;

            try
            {
                Bitmap grayImage = new Bitmap(INSPECTION_IMAGE);

                BitmapData bitmapData = grayImage.LockBits(new Rectangle(0,0,grayImage.Width,grayImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int stride = bitmapData.Stride;
                System.IntPtr Scan0 = bitmapData.Scan0;
                byte* p = (byte*)(void*)Scan0;
                Parallel.For(SEARCH_AREA.X, SEARCH_AREA.X + SEARCH_AREA.Width, x =>
                {
                    Parallel.For(SEARCH_AREA.Y, SEARCH_AREA.Y + SEARCH_AREA.Height, y =>
                    {
                        lock (lockObject)
                        {
                            int nPos = y * stride + x * 3;
                            total += (p[nPos + 0] + p[nPos + 1] + p[nPos + 2]) / 3;
                        }
                    });
                });

                grayImage.UnlockBits(bitmapData);
            }
            catch
            {
                return -1;
            }

            FIND_AREA = SEARCH_AREA;
            int brightness = (int)(total / (SEARCH_AREA.Width * SEARCH_AREA.Height));
            return brightness;
        }

        public override int Run()
        {
            int ret = this.GetHisto();
            RESULT = ret.ToString();
            DrawImage(INSPECTION_IMAGE, SEARCH_AREA, Color.Blue);
            return ret == -1 ? 1 : 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageInspector.ImageLibrary
{
    public static class CommonBase
    {
        public static Image CropImage(Image image, Rectangle rectangle)
        {
            //Bitmap bmp = new Bitmap(rectangle.Width, rectangle.Height);

            return (Image)((Bitmap)image).Clone(rectangle, image.PixelFormat);

            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.DrawImage(image, rectangle);
            //    return (Image)bmp;
            //}
        }
    }
}

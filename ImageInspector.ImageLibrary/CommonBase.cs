using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp.Extensions;

namespace ImageInspector.ImageLibrary
{
    public abstract class CommonBase
    {
        public abstract Image INPUT_IMAGE { get; set; }
        public abstract Image OUTPUT_IMAGE { get; set; }
        public abstract Rectangle SEARCH_AREA { get; set; }
        public abstract object RESULT { get; set; }
        public abstract int Run();

        public Image CropImage(Image image, Rectangle rectangle)
        {
            return (Image)((Bitmap)image).Clone(rectangle, image.PixelFormat);
        }
    }
}
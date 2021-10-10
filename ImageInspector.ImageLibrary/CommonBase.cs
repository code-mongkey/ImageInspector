using System.Drawing;
using OpenCvSharp;

namespace ImageInspector.ImageLibrary
{
    public abstract class CommonBase
    {
        public abstract Image INSPECTION_IMAGE { get; set; }
        public abstract Rectangle SEARCH_AREA { get; set; }
        public abstract Rectangle FIND_AREA { get; set; }
        public abstract object RESULT { get; set; }
        public abstract int Run();

        protected void DrawImage(Image image, Rectangle rectangle, Color color, int width=4)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawRectangle(new Pen(color, width), SEARCH_AREA);
            }
        }
        protected void DrawImage(Image image, RectangleF rectangle, Color color, int width=4)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawRectangle(new Pen(color, width), SEARCH_AREA);
            }
        }
        protected Bitmap MatToBitmap(Mat mat) => OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
        protected Mat BitmapToMat(Bitmap bmp) => OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp);
    }
}
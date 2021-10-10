using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageInspector.Controls
{
    public class MyDrawRectangle
    {
        public Rectangle Rectangle {  get; set; }
        public Color Color { get; set; }
        public int Width {  get; set; }

        public bool IsImage { get; set; }

        public MyDrawRectangle(Rectangle rectangle, Color color, int width, bool isImage = false)
        {
            Rectangle = rectangle;
            Color = color;
            Width = width;
            IsImage = isImage;
        }
    }
}

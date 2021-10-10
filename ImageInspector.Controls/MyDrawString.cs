using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageInspector.Controls
{
    public class MyDrawString
    {
        public string Text {  get; set; }
        public Brush Brush {  get; set; }
        public Font Font {  get; set; }
        public float X { get; set; }
        public float Y {  get; set; }

        public MyDrawString(string text, Brush brush, Font font, float x, float y)
        {
            Text = text;
            Brush = brush;
            Font = font;
            X = x;
            Y = y;
        }
    }
}

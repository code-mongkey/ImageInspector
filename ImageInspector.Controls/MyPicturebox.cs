using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageInspector.Controls
{
    public partial class MyPicturebox : UserControl
    {

        public MyPicturebox()
        {
            InitializeComponent();

            pictureBox1.MouseDown += PictureBox_MouseDown;
            pictureBox1.MouseMove += PictureBox_MouseMove;
            pictureBox1.MouseUp += PictureBox_MouseUp;
            pictureBox1.Paint += PictureBox_Paint;
        }

        private Rectangle Search_Area_Display;
        public Rectangle SEARCH_AREA_DISPLAY
        {
            get { return Search_Area_Display; }
        }

        private Rectangle Search_Area_Image;
        public Rectangle SEARCH_AREA_IMAGE
        {
            get { return Search_Area_Image; }
        }

        private bool Drawing = false;
        public bool DRAWING
        {
            get {  return Drawing; }
            set { Drawing = value; }
        }

        private Image InspectionImage = null;
        public Image IMAGE
        {
            get {  return InspectionImage; }
            set
            {
                InspectionImage = value;
                pictureBox1.Image = value;
            }
        }

        private void PictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (!ValidateChildren()) return;

            int pX = e.X;
            int pY = e.Y;

            if (pX < 0 || pY < 0) return;
            if(pX >= pictureBox1.Image.Width || pY >= pictureBox1.Image.Height) return;

            Search_Area_Display = new Rectangle(pX, pY, 0, 0);

            this.Refresh();
        }

        private void PictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (!ValidateChildren()) return;

            if (e.Button == MouseButtons.Left)
            {
                int pX = e.X;
                int pY = e.Y;

                int standardX = Search_Area_Display.X < pX ? Search_Area_Display.X : Search_Area_Display.X + Search_Area_Display.Width;
                int standardY = Search_Area_Display.Y < pY ? Search_Area_Display.Y : Search_Area_Display.Y + Search_Area_Display.Height;

                int x = Math.Min(standardX, pX);
                int y = Math.Min(standardY, pY);
                int width = Math.Abs(standardX - pX);
                int height = Math.Abs(standardY - pY);

                Search_Area_Display = new Rectangle(x,y, width, height);

                this.Refresh();
            }
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        { 
            if (!ValidateChildren()) return;

            using (Pen pen = new Pen(Color.Blue, 2))
            {
                e.Graphics.DrawRectangle(pen, Search_Area_Display);
            }
        }
        private void PictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (!ValidateChildren()) return;

            Drawing = false;

            double wfactor = (double)InspectionImage.Width / pictureBox1.ClientSize.Width;
            double hfactor = (double)InspectionImage.Height / pictureBox1.ClientSize.Height;
            double resizeFactor = Math.Max(wfactor, hfactor);

            int sX = (int)((pictureBox1.Image.Width / 2) + (Search_Area_Display.X - (pictureBox1.ClientSize.Width / 2)) * resizeFactor);
            int sY = (int)((pictureBox1.Image.Height / 2) + (Search_Area_Display.Y - (pictureBox1.ClientSize.Height / 2)) * resizeFactor);

            int eX = (int)((pictureBox1.Image.Width / 2) + (Search_Area_Display.X + Search_Area_Display.Width - (pictureBox1.ClientSize.Width / 2)) * resizeFactor);
            int eY = (int)((pictureBox1.Image.Height / 2) + (Search_Area_Display.Y + Search_Area_Display.Height - (pictureBox1.ClientSize.Height / 2)) * resizeFactor);

            sX = sX < 0 ? 0 : sX;
            sY = sY < 0 ? 0 : sY;
            eX = eX < 0 ? 0 : eX;
            eY = eY < 0 ? 0 : eY;

            sX = sX >= pictureBox1.Image.Width ? pictureBox1.Image.Width - 1 : sX;
            sY = sY >= pictureBox1.Image.Height ? pictureBox1.Image.Height - 1 : sY;
            eX = eX >= pictureBox1.Image.Width ? pictureBox1.Image.Width - 1 : eX;
            eY = eY >= pictureBox1.Image.Height ? pictureBox1.Image.Height - 1 : eY;

            Search_Area_Image = new Rectangle(sX, sY, Math.Max(eX - sX, 1), Math.Max(eY - sY, 1));
        }

        public override bool ValidateChildren()
        {
            if (!Drawing) return false;
            if (InspectionImage == null) return false;

            return base.ValidateChildren();
        }

        public void DrawString(string text, Brush brush, int emSize = 10, int x = 0, int y = 0)
        {
            Graphics drawString = pictureBox1.CreateGraphics();
            drawString.DrawString(text, new Font("맑은 고딕", emSize), brush, x, y);
        }
        public void DrawRectangle(Rectangle rect)
        {
            Graphics drawString = pictureBox1.CreateGraphics();
            drawString.DrawRectangle(new Pen(Color.Blue, 2), rect);
        }

        public void ClearDisplay()
        {
            Image img = (Image)pictureBox1.Image.Clone();

            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.LightGray);

            pictureBox1.Image = img;

            this.Refresh();
        }
    }
}

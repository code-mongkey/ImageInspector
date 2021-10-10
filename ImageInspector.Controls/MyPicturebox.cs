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

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            MyDrawStrings = new MyList<MyDrawString>();
            MyDrawRectangles = new MyList<MyDrawRectangle>();

            MyDrawStrings.OnAdd += MyDraw_OnAdd;
            MyDrawRectangles.OnAdd += MyDraw_OnAdd;

            pictureBox1.MouseDown += PictureBox_MouseDown;
            pictureBox1.MouseMove += PictureBox_MouseMove;
            pictureBox1.MouseUp += PictureBox_MouseUp;
            pictureBox1.Paint += PictureBox_Paint;
        }

        private void MyDraw_OnAdd(object? sender, EventArgs e)
        {
            this.Refresh();
        }

        private int StartX, StartY;

        public MyList<MyDrawString> MyDrawStrings;
        public MyList<MyDrawRectangle> MyDrawRectangles;

        public Rectangle SEARCH_AREA_DISPLAY { get; private set; }
        public Rectangle SEARCH_AREA_IMAGE { get; private set; }

        private bool Drawing = false;
        public bool DRAWING
        {
            get {  return Drawing; }
            set { Drawing = value; }
        }

        private Image InspectionImage;
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
            if (!CheckValidation()) return;

            int pX = e.X;
            int pY = e.Y;

            if (pX < 0 || pY < 0) return;

            ClearDisplay();

            StartX = e.X;
            StartY = e.Y;
            SEARCH_AREA_DISPLAY = new Rectangle(pX, pY, 0, 0);

            this.Refresh();
        }

        private void PictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (!CheckValidation()) return;

            if (e.Button == MouseButtons.Left)
            {
                int pX = e.X;
                int pY = e.Y;

                //int standardX = StartX < pX ? StartX : StartX + SEARCH_AREA_DISPLAY.Width;
                //int standardY = StartY < pY ? StartY : StartY + SEARCH_AREA_DISPLAY.Height;

                int x = Math.Min(StartX, pX);
                int y = Math.Min(StartY, pY);
                int width = Math.Abs(StartX - pX);
                int height = Math.Abs(StartY - pY);

                SEARCH_AREA_DISPLAY = new Rectangle(x,y, width, height);

                this.Refresh();
            }
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        { 
            if (MyDrawRectangles.Count != 0)
            {
                foreach (MyDrawRectangle myDrawRectangle in MyDrawRectangles)
                {
                    if(myDrawRectangle.IsImage)
                    {
                        myDrawRectangle.Rectangle = ImageToDisplayFactor(myDrawRectangle.Rectangle);
                        myDrawRectangle.IsImage = false;
                    }
                    using (Pen pen = new Pen(myDrawRectangle.Color, myDrawRectangle.Width))
                    {
                        e.Graphics.DrawRectangle(pen, myDrawRectangle.Rectangle);
                    }
                }
            }

            if (MyDrawStrings.Count != 0)
            {
                foreach (MyDrawString myDrawString in MyDrawStrings)
                {
                    e.Graphics.DrawString(myDrawString.Text, myDrawString.Font, myDrawString.Brush, myDrawString.X, myDrawString.Y);
                }
            }

            if (!CheckValidation()) return;
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                e.Graphics.DrawString("영역 선택 후 확인 \r\n(MOUSE DRAG AND CONFIRM)", new Font("맑은 고딕", 12, FontStyle.Bold), Brushes.Black, 10, 10);
                e.Graphics.DrawRectangle(pen, SEARCH_AREA_DISPLAY);
            }
        }
        private void PictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (!CheckValidation()) return;

            Drawing = false;

            double wfactor = (double)InspectionImage.Width / pictureBox1.ClientSize.Width;
            double hfactor = (double)InspectionImage.Height / pictureBox1.ClientSize.Height;
            double resizeFactor = Math.Max(wfactor, hfactor);

            int sX = (int)((pictureBox1.Image.Width / 2) + (SEARCH_AREA_DISPLAY.X - (pictureBox1.ClientSize.Width / 2)) * resizeFactor);
            int sY = (int)((pictureBox1.Image.Height / 2) + (SEARCH_AREA_DISPLAY.Y - (pictureBox1.ClientSize.Height / 2)) * resizeFactor);

            int eX = (int)((pictureBox1.Image.Width / 2) + (SEARCH_AREA_DISPLAY.X + SEARCH_AREA_DISPLAY.Width - (pictureBox1.ClientSize.Width / 2)) * resizeFactor);
            int eY = (int)((pictureBox1.Image.Height / 2) + (SEARCH_AREA_DISPLAY.Y + SEARCH_AREA_DISPLAY.Height - (pictureBox1.ClientSize.Height / 2)) * resizeFactor);

            sX = sX < 0 ? 0 : sX;
            sY = sY < 0 ? 0 : sY;
            eX = eX < 0 ? 0 : eX;
            eY = eY < 0 ? 0 : eY;

            sX = sX >= pictureBox1.Image.Width ? pictureBox1.Image.Width - 1 : sX;
            sY = sY >= pictureBox1.Image.Height ? pictureBox1.Image.Height - 1 : sY;
            eX = eX >= pictureBox1.Image.Width ? pictureBox1.Image.Width - 1 : eX;
            eY = eY >= pictureBox1.Image.Height ? pictureBox1.Image.Height - 1 : eY;

            SEARCH_AREA_IMAGE = new Rectangle(sX, sY, Math.Max(eX - sX, 1), Math.Max(eY - sY, 1));
        }

        private bool CheckValidation()
        {
            if (!Drawing) return false;
            if (InspectionImage == null) return false;
            return true;
        }

        /// <summary>
        /// 이미지위치에서 컨트롤 위치로 변경하는 함수
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        private Rectangle ImageToDisplayFactor(Rectangle rectangle)
        {
            double wfactor = (double)pictureBox1.ClientSize.Width / InspectionImage.Width;
            double hfactor = (double)pictureBox1.ClientSize.Height / InspectionImage.Height;
            double resizeFactor = Math.Min(wfactor, hfactor);

            int sX = (int)((pictureBox1.ClientSize.Width / 2) + (rectangle.X - (pictureBox1.Image.Width / 2)) * resizeFactor);
            int sY = (int)((pictureBox1.ClientSize.Height / 2) + (rectangle.Y - (pictureBox1.Image.Height / 2)) * resizeFactor);

            int eX = (int)((pictureBox1.ClientSize.Width / 2) + (rectangle.X + rectangle.Width - (pictureBox1.Image.Width / 2)) * resizeFactor);
            int eY = (int)((pictureBox1.ClientSize.Height / 2) + (rectangle.Y + rectangle.Height - (pictureBox1.Image.Height / 2)) * resizeFactor);

            sX = sX < 0 ? 0 : sX;
            sY = sY < 0 ? 0 : sY;
            eX = eX < 0 ? 0 : eX;
            eY = eY < 0 ? 0 : eY;

            sX = sX >= pictureBox1.ClientSize.Width ? pictureBox1.ClientSize.Width - 1 : sX;
            sY = sY >= pictureBox1.ClientSize.Height ? pictureBox1.ClientSize.Height - 1 : sY;
            eX = eX >= pictureBox1.ClientSize.Width ? pictureBox1.ClientSize.Width - 1 : eX;
            eY = eY >= pictureBox1.ClientSize.Height ? pictureBox1.ClientSize.Height - 1 : eY;

            return new Rectangle(sX, sY, eX-sX, eY-sY);
        }

        public void ClearDisplay()
        {
            MyDrawRectangles.Clear();
            MyDrawStrings.Clear();

            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.LightGray);

            this.Refresh();
        }
    }
}

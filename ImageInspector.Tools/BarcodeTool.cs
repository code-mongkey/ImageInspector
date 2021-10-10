using ImageInspector.Controls;
using ImageInspector.ImageLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageInspector.Tools
{
    public partial class BarcodeTool : UserControl, ToolInterface, IDisposable
    {
        private MyBarcode MyBarcode = new MyBarcode();
        private MyPicturebox MyPicturebox = new MyPicturebox();
        private Rectangle SearchAreaDisplay, SearchAreaImage;

        public BarcodeTool()
        {
            InitializeComponent();
        }

        public int SetImage(MyPicturebox display)
        {
            MyPicturebox = display;
            if (MyPicturebox != null)
            {
                SearchAreaDisplay = new Rectangle(0, 0, display.Width, display.Height);
                SearchAreaImage = new Rectangle(0, 0, display.IMAGE.Width, display.IMAGE.Height);
            }

            return 0;
        }

        public int Cancel()
        {
            MyPicturebox.DRAWING = false;
            MyPicturebox.ClearDisplay();
            return 0;
        }

        public int Confirm()
        {
            MyPicturebox.DRAWING = false;
            MyPicturebox.ClearDisplay();

            SearchAreaDisplay = MyPicturebox.SEARCH_AREA_DISPLAY;
            SearchAreaImage = MyPicturebox.SEARCH_AREA_IMAGE;
            
            return 0;
        }

        public string GetResult()
        {
            return (string)MyBarcode.RESULT;
        }

        public void Release()
        {
            int i = this.Controls.Count;
            while (i > 0)
            {
                this.Controls[--i].Dispose();
            }
        }

        public int Run()
        {
            if (MyPicturebox.IMAGE == null) return 1;

            MyBarcode.INSPECTION_IMAGE = MyPicturebox.IMAGE;
            MyBarcode.SEARCH_AREA = SearchAreaImage;
            int ret = MyBarcode.Run();

            MyDrawRectangle myDrawRectangle = new MyDrawRectangle(SearchAreaDisplay, ret == 0 ? Color.Green : Color.Red, 4);
            MyPicturebox.MyDrawRectangles.Add(myDrawRectangle);
            if (ret == 0)
            {
                txtResult.ForeColor = Color.Green;
                txtResult.Text = (string)MyBarcode.RESULT;
                return 0;
            }
            else
            {
                txtResult.ForeColor = Color.Red;
                txtResult.Text = "";
                return 1;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.Run();
        }

        private void btnSearchArea_Click(object sender, EventArgs e)
        {
            MyPicturebox.ClearDisplay();
            MyPicturebox.DRAWING = true;
            //MyPicturebox.DrawRectangle(SearchAreaDisplay, Color.Green);
            MyDrawRectangle myDrawRectangle = new MyDrawRectangle(SearchAreaDisplay, Color.Green, 4);
            MyPicturebox.MyDrawRectangles.Add(myDrawRectangle);
        }
    }
}

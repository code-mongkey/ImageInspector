using ImageInspector.Controls;
using ImageInspector.ImageLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageInspector.Tools
{
    public partial class BarcodeTool : UserControl, ToolInterface
    {
        private MyBarcode myBarcode = new MyBarcode();
        private MyPicturebox picturebox = new MyPicturebox();
        private Rectangle SearchAreaDisplay, SearchAreaImage;

        public BarcodeTool()
        {
            InitializeComponent();
        }

        public int SetImage(MyPicturebox display)
        {
            picturebox = display;
            if (picturebox != null)
            {
                SearchAreaDisplay = new Rectangle(0, 0, display.Width, display.Height);
                SearchAreaImage = new Rectangle(0, 0, display.IMAGE.Width, display.IMAGE.Height);
            }

            return 0;
        }

        public int Cancel()
        {
            picturebox.DRAWING = false;
            picturebox.ClearDisplay();
            return 0;
        }

        public int Confirm()
        {
            picturebox.DRAWING = false;
            picturebox.ClearDisplay();

            SearchAreaDisplay = picturebox.SEARCH_AREA_DISPLAY;
            SearchAreaImage = picturebox.SEARCH_AREA_IMAGE;
            
            return 0;
        }

        public string GetResult()
        {
            return (string)myBarcode.RESULT;
        }

        public void Release()
        {
            this.Release();
            int i = this.Controls.Count;
            while (i > 0)
            {
                this.Controls[--i].Dispose();
            }
        }

        public int Run()
        {
            myBarcode.INPUT_IMAGE = picturebox.IMAGE;
            myBarcode.SEARCH_AREA = SearchAreaImage;
            int ret = myBarcode.Run();

            picturebox.DrawRectangle(SearchAreaDisplay);
            //picturebox.IMAGE = myBarcode.OUTPUT_IMAGE;

            if (ret == 0)
            {
                txtResult.ForeColor = Color.Green;
                txtResult.Text = (string)myBarcode.RESULT;
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
            picturebox.ClearDisplay();
            picturebox.DRAWING = true;
            picturebox.DrawRectangle(SearchAreaDisplay);
        }
    }
}

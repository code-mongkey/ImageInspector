using ImageInspector.Controls;
using ImageInspector.ImageLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageInspector.Tools
{
    public partial class BarcodeTool : UserControl, ToolInterface
    {
        public BarcodeTool()
        {
            InitializeComponent();
        }

        private ImageLibrary.MyBarcode myBarcode = new ImageLibrary.MyBarcode();
        private MyPicturebox picturebox = new MyPicturebox();
        private Rectangle SearchAreaDisplay, SearchAreaImage;

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
            if(myBarcode.Result == null)
            {
                return "";
            }
            else
            {
                return myBarcode.Result.Text;
            }
        }

        public void Release()
        {
            myBarcode = null;
            picturebox = null;
        }

        public int Run()
        {
            Image img = CommonBase.CropImage(picturebox.IMAGE, SearchAreaImage);
            myBarcode.ReadBarcode(img);

            picturebox.DrawRectangle(SearchAreaDisplay);

            if(myBarcode.Result == null)
            {
                txtResult.ForeColor = Color.Red;
                txtResult.Text = "";
                return 1;
            }
            else
            {
                txtResult.ForeColor = Color.Green;
                txtResult.Text = myBarcode.Result.Text;
                return 0;
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

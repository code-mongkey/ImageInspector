using ImageInspector.Controls;
using ImageInspector.ImageLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageInspector.Tools
{
    public partial class HistogramTool : UserControl, ToolInterface
    {
        private MyHistogram MyHistogram = new MyHistogram();
        private MyPicturebox picturebox = new MyPicturebox();
        private Rectangle SearchAreaDisplay, SearchAreaImage;

        public HistogramTool()
        {
            InitializeComponent();
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
            return (string)MyHistogram.RESULT;
        }

        public void Release()
        {
            throw new NotImplementedException();
        }

        public int Run()
        {
            MyHistogram.INPUT_IMAGE = picturebox.IMAGE;
            MyHistogram.SEARCH_AREA = SearchAreaImage;
            MyHistogram.Run();

            int Result = Convert.ToInt32(MyHistogram.RESULT);

            picturebox.DrawRectangle(SearchAreaDisplay);

            lblResult.Text = Result.ToString();
            if (Result >= numMin.Value && Result <= numMax.Value)
            {
                lblResult.ForeColor = Color.Green;
                return 0;
            }
            else
            {
                lblResult.ForeColor = Color.Red;
                return 1;
            }
        }

        private void btnSearchArea_Click(object sender, EventArgs e)
        {
            picturebox.ClearDisplay();
            picturebox.DRAWING = true;
            picturebox.DrawRectangle(SearchAreaDisplay);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.Run();
        }

        public int SetImage(MyPicturebox display)
        {
            picturebox = display;
            if (picturebox != null)
            {
                SearchAreaDisplay = new Rectangle(0, 0, display.Width, display.Height);
                SearchAreaImage = new Rectangle(0, 0, display.IMAGE.Width, display.IMAGE.Height);
            }

            picturebox.IMAGE = ImageInspector.ImageLibrary.ImagePreprocessing.ConvertImage.ConvertColorToGray(picturebox.IMAGE);
            return 0;
        }
    }
}

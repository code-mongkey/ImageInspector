using ImageInspector.Controls;
using ImageInspector.ImageLibrary;
using ImageInspector.ImageLibrary.ImagePreprocessing;
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
        private MyPicturebox MyPicturebox = new MyPicturebox();
        private Rectangle SearchAreaDisplay, SearchAreaImage;

        public HistogramTool()
        {
            InitializeComponent();

            cboConvertImage.Items.Clear();
            cboConvertImage.Items.AddRange(new string[] { "GRAY", "RED", "GREEN", "BLUE" });
            cboConvertImage.SelectedIndex = 0;
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
            return (string)MyHistogram.RESULT;
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
            if (SearchAreaImage.Width == 0 || SearchAreaImage.Height == 0) return 1;

            MyHistogram.INSPECTION_IMAGE = ConvertImg();
            MyHistogram.SEARCH_AREA = SearchAreaImage;
            MyHistogram.Run();

            int Result = Convert.ToInt32(MyHistogram.RESULT);

            lblResult.Text = Result.ToString();

            if (Result >= numMin.Value && Result <= numMax.Value)
            {
                MyDrawRectangle myDrawRectangle = new MyDrawRectangle(SearchAreaDisplay, Color.Green, 4);
                MyPicturebox.MyDrawRectangles.Add(myDrawRectangle);
                lblResult.ForeColor = Color.Green;
                return 0;
            }
            else
            {
                MyDrawRectangle myDrawRectangle = new MyDrawRectangle(SearchAreaDisplay, Color.Red, 4);
                MyPicturebox.MyDrawRectangles.Add(myDrawRectangle);
                lblResult.ForeColor = Color.Red;
                return 1;
            }
        }

        private void btnSearchArea_Click(object sender, EventArgs e)
        {
            MyPicturebox.ClearDisplay();
            MyPicturebox.DRAWING = true;
            MyDrawRectangle myDrawRectangle = new MyDrawRectangle(SearchAreaDisplay, Color.Green, 4);
            MyPicturebox.MyDrawRectangles.Add(myDrawRectangle);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.Run();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (MyPicturebox.IMAGE == null) return;
            myPicturebox1.IMAGE = ConvertImg();
        }

        private Image ConvertImg()
        {
            Image ret;
            switch (cboConvertImage.SelectedIndex)
            {
                case 0:
                    ret = ConvertImage.ConvertColorToGray((Bitmap)MyPicturebox.IMAGE);
                    break;
                case 1:
                    ret = ConvertImage.ConvertColorToRGB(MyPicturebox.IMAGE, ConvertImage.RGB.R);
                    break;
                case 2:
                    ret = ConvertImage.ConvertColorToRGB(MyPicturebox.IMAGE, ConvertImage.RGB.G);
                    break;
                case 3:
                    ret = ConvertImage.ConvertColorToRGB(MyPicturebox.IMAGE, ConvertImage.RGB.B);
                    break;
                default:
                    ret = ConvertImage.ConvertColorToGray((Bitmap)MyPicturebox.IMAGE);
                    break;
            }
            return ret;
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
    }
}

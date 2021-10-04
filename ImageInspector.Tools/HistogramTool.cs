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
        private MyPicturebox picturebox = new MyPicturebox();
        private Rectangle SearchAreaDisplay, SearchAreaImage;

        int histo = 0;

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
            return histo.ToString();
        }

        public void Release()
        {
            throw new NotImplementedException();
        }

        public int Run()
        {
            Image img = CommonBase.CropImage(picturebox.IMAGE, SearchAreaImage);
            //Image gray = CommonBase.ConvertColorToGrayscale(img);

            picturebox.DrawRectangle(SearchAreaDisplay);

            int histo = CommonBase.GetHisto(img);

            lblResult.Text = histo.ToString();
            if (histo >= numMin.Value && histo <= numMax.Value)
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
    }
}

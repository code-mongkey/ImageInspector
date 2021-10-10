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
    public partial class MatchingTool : UserControl, ToolInterface
    {
        private MyPicturebox MyPicturebox = new MyPicturebox();
        private MyTemplateMatching MyTemplateMatching = new MyTemplateMatching();
        private Rectangle SearchAreaDisplay, SearchAreaImage;
        private Rectangle TemplateAreaDisplay, TemplateAreaImage;
        private Image TemplateImage;

        private enum STATES { SEARCH, TEMPLATE }
        private STATES STATE;

        public MatchingTool()
        {
            InitializeComponent();

            cboConvertImage.Items.Clear();
            cboConvertImage.Items.AddRange(new string[] { "GRAY" });
            cboConvertImage.SelectedIndex = 0;
        }

        private void btnSearchArea_Click(object sender, EventArgs e)
        {
            STATE = STATES.SEARCH;
            MyPicturebox.ClearDisplay();
            MyPicturebox.DRAWING = true;
            //MyPicturebox.DrawRectangle(SearchAreaDisplay, Color.Blue);
            MyDrawRectangle myDrawRectangle = new MyDrawRectangle(SearchAreaDisplay, Color.Green, 4);
            MyPicturebox.MyDrawRectangles.Add(myDrawRectangle);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.Run();
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

        public int Confirm()
        {
            MyPicturebox.DRAWING = false;
            MyPicturebox.ClearDisplay();

            if (STATE == STATES.SEARCH)
            {
                SearchAreaDisplay = MyPicturebox.SEARCH_AREA_DISPLAY;
                SearchAreaImage = MyPicturebox.SEARCH_AREA_IMAGE;
            }
            else if (STATE == STATES.TEMPLATE)
            {
                TemplateAreaDisplay = MyPicturebox.SEARCH_AREA_DISPLAY;
                TemplateAreaImage = MyPicturebox.SEARCH_AREA_IMAGE;
                TemplateImage = ConvertImage.CropImage(MyPicturebox.IMAGE, MyPicturebox.SEARCH_AREA_IMAGE);
                picTemplate.IMAGE = TemplateImage;
                MyTemplateMatching.TemplateImage = TemplateImage;
            }

            MyPicturebox.ClearDisplay();

            return 0;
        }

        public int Cancel()
        {
            MyPicturebox.DRAWING = false;
            MyPicturebox.ClearDisplay();
            return 0;
        }

        public int Run()
        {
            if (MyTemplateMatching.TemplateImage == null) return 1;

            MyTemplateMatching.Score = (int)numScore.Value;
            MyTemplateMatching.INSPECTION_IMAGE = ConvertImg((Bitmap)MyPicturebox.IMAGE);
            MyTemplateMatching.TemplateImage = ConvertImg((Bitmap)picTemplate.IMAGE);
            MyTemplateMatching.SEARCH_AREA = SearchAreaImage;

            int ret = MyTemplateMatching.Run();

            lblResult.ForeColor = ret == 0 ? Color.Green : Color.Red;
            if (ret == 0)
            {
                MyDrawRectangle myDrawRectangle = new MyDrawRectangle(MyTemplateMatching.FIND_AREA, Color.Cyan, 4, true);
                MyDrawRectangle myDrawRectangle2 = new MyDrawRectangle(MyTemplateMatching.SEARCH_AREA, Color.Blue, 4, true);
                MyPicturebox.MyDrawRectangles.Add(myDrawRectangle);
                MyPicturebox.MyDrawRectangles.Add(myDrawRectangle2);
            }

            return ret;
        }

        public string GetResult()
        {
            throw new NotImplementedException();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (MyPicturebox.IMAGE == null) return;

            panel1.Visible = true;
            panel1.Location = panel3.Location;
            panel1.BringToFront();

            picConvertImage.IMAGE = ConvertImg((Bitmap)MyPicturebox.IMAGE);

        }
        private Image ConvertImg(Bitmap bmp)
        {
            Image ret;
            switch (cboConvertImage.SelectedIndex)
            {
                case 0:
                    ret = ConvertImage.ConvertColorToGrayByOpenCV(bmp);
                    break;
                //case 1:
                //    ret = ConvertImage.ConvertColorToRGB(MyPicturebox.IMAGE, ConvertImage.RGB.R);
                //    break;
                //case 2:
                //    ret = ConvertImage.ConvertColorToRGB(MyPicturebox.IMAGE, ConvertImage.RGB.G);
                //    break;
                //case 3:
                //    ret = ConvertImage.ConvertColorToRGB(MyPicturebox.IMAGE, ConvertImage.RGB.B);
                //    break;
                //case 4:
                //    ret = ConvertImage.ConvertColorToGray(bmp);
                //    break;
                default:
                    ret = ConvertImage.ConvertColorToGray(bmp);
                    break;
            }
            return ret;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnSetTemplate_Click(object sender, EventArgs e)
        {
            if (MyPicturebox.IMAGE == null) return;

            STATE = STATES.TEMPLATE;
            MyPicturebox.ClearDisplay();
            MyPicturebox.DRAWING = true;
            //MyPicturebox.DrawRectangle(TemplateAreaDisplay, Color.Cyan);
            MyDrawRectangle myDrawRectangle = new MyDrawRectangle(TemplateAreaDisplay, Color.Cyan, 4);
            MyPicturebox.MyDrawRectangles.Add(myDrawRectangle);
        }

        public void Release()
        {
            int i = this.Controls.Count;
            while (i > 0)
            {
                this.Controls[--i].Dispose();
            }
        }
    }
}

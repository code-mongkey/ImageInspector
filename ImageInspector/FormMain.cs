using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ImageInspector.Tools;

namespace ImageInspector
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            cboTools.Items.Clear();
            cboTools.Items.AddRange(new string[] { "BARCODE",  "PATTERN", "HISTOGRAM" });
            cboTools.SelectedIndex = 0;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadImage = new OpenFileDialog();
            string loadedImgPath;

            loadImage.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";

            if (loadImage.ShowDialog() == DialogResult.OK)
                loadedImgPath = loadImage.FileName;
            else return;

            try
            {
                Bitmap bitmap = new Bitmap(loadedImgPath);
                myPicturebox1.IMAGE = bitmap;

                foreach (TabPage tab in tabControl1.TabPages)
                {
                    ((ToolInterface)tab.Controls[0]).SetImage(myPicturebox1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (myPicturebox1.IMAGE == null) return;
            ((Tools.ToolInterface)(tabControl1.SelectedTab.Controls[0])).Confirm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ((Tools.ToolInterface)(tabControl1.SelectedTab.Controls[0])).Cancel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboTools.Text == "") return;

            UserControl tool = null;
            switch (cboTools.SelectedIndex)
            {
                case 0:
                    tool = new Tools.BarcodeTool();
                    break;
                case 2:
                    tool = new Tools.HistogramTool();
                    break;
            }

            tabControl1.TabPages.Add(new TabPage(cboTools.Text + tabControl1.TabPages.Count));
            tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(tool);
            tabControl1.SelectTab(tabControl1.TabPages.Count - 1);

            if(myPicturebox1.IMAGE != null)
            {
                ((Tools.ToolInterface)(tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls[0])).SetImage(myPicturebox1);
            }
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            if (myPicturebox1.IMAGE == null) return;

            myPicturebox1.ClearDisplay();

            int result = 0;
            foreach(TabPage tabpage in tabControl1.TabPages)
            {
                //((Tools.ToolInterface)tabpage.Controls[0]).SetImage(myPicturebox1);
                result += ((Tools.ToolInterface)tabpage.Controls[0]).Run();
            }

            string text = result == 0 ? "OK" : "NG";
            Brush brush = result == 0 ? Brushes.Green : Brushes.Red;
            myPicturebox1.DrawString(text, brush, 30, 10, 10);
        }
    }
}

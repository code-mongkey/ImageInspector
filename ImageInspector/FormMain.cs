using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ImageInspector.Tools;
using ImageInspector.Controls;

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

            myPicturebox1.ClearDisplay();

            Bitmap bitmap = new Bitmap(loadedImgPath);
            myPicturebox1.IMAGE = bitmap;

            foreach (TabPage tab in tabControl1.TabPages)
            {
                ((ToolInterface)tab.Controls[0]).SetImage(myPicturebox1);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!CheckValidation()) return;
            myPicturebox1.DRAWING = false;
            ((Tools.ToolInterface)(tabControl1.SelectedTab.Controls[0])).Confirm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!CheckValidation()) return;
            myPicturebox1.DRAWING = false;
            ((Tools.ToolInterface)(tabControl1.SelectedTab.Controls[0])).Cancel();
        }

        private bool CheckValidation()
        {
            if (myPicturebox1.IMAGE == null) return false;
            if (tabControl1.TabPages.Count == 0) return false;
            return true;
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            if (!CheckValidation()) return;

            myPicturebox1.DRAWING = false;
            myPicturebox1.ClearDisplay();

            int result = 0;
            foreach (TabPage tabpage in tabControl1.TabPages)
            {
                result += ((Tools.ToolInterface)tabpage.Controls[0]).Run();
            }

            string text = result == 0 ? "OK" : "NG";
            Brush brush = result == 0 ? Brushes.Green : Brushes.Red;
            MyDrawString myDrawString = new MyDrawString(text, brush, new Font("맑은 고딕", 20, FontStyle.Bold), 10, 10);
            myPicturebox1.MyDrawStrings.Add(myDrawString);
        }

        private void cboTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtToolName.Text = cboTools.Text + tabControl1.TabCount.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboTools.Text == "") return;
            if (txtToolName.Text == "") return;

            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                if (txtToolName.Text.Trim() == tabPage.Text)
                {
                    MessageBox.Show("동알한 검사명이 존재합니다");
                    return;
                }
            }

            UserControl tool = null;
            switch (cboTools.SelectedIndex)
            {
                case 0:
                    tool = new Tools.BarcodeTool();
                    break;
                case 1:
                    tool = new Tools.MatchingTool();
                    break;
                case 2:
                    tool = new Tools.HistogramTool();
                    break;
            }

            tabControl1.TabPages.Add(new TabPage(txtToolName.Text.Trim()));
            tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(tool);
            tabControl1.SelectTab(tabControl1.TabPages.Count - 1);

            if (myPicturebox1.IMAGE != null)
            {
                ((Tools.ToolInterface)(tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls[0])).SetImage(myPicturebox1);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        { 
            if (tabControl1.TabPages.Count == 0) return;
            if (MessageBox.Show(tabControl1.SelectedTab.Text + " 를 삭제하시겠습니까?", "WARNING", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ((Tools.ToolInterface)(tabControl1.SelectedTab.Controls[0])).Release();
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
            }
        }
    }
}

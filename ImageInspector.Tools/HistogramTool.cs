using ImageInspector.Controls;
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
    
        public HistogramTool()
        {
            InitializeComponent();
        }

        public int Cancel()
        {
            throw new NotImplementedException();
        }

        public int Confirm()
        {
            throw new NotImplementedException();
        }

        public string GetResult()
        {
            throw new NotImplementedException();
        }

        public void Release()
        {
            throw new NotImplementedException();
        }

        public int Run()
        {
            throw new NotImplementedException();
        }

        public int SetImage(MyPicturebox display)
        {
            throw new NotImplementedException();
        }
    }
}

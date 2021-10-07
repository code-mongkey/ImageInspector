using System.Drawing;
using System.Linq;

namespace ImageInspector.ImageLibrary
{
    public class MyBarcode : CommonBase
    {
        public override object RESULT { get; set; }
        public override Rectangle SEARCH_AREA { get; set; }
        public override Image INPUT_IMAGE { get; set; }
        public override Image OUTPUT_IMAGE { get; set; }

        public int ReadBarcode()
        {
            RESULT = "";
            Image img = CropImage(INPUT_IMAGE, SEARCH_AREA);
            ZXing.BarcodeReader barcodeReader = new ZXing.BarcodeReader();
            ZXing.Result result = barcodeReader.Decode((Bitmap)img);
            if (result == null || result.Text == "") return 1;
            RESULT = result.Text;

            ZXing.ResultPoint [] resultPoint = result.ResultPoints;

            float sX = resultPoint[0].X;
            float sY = resultPoint[0].Y;
            float eX = resultPoint[0].X;
            float eY = resultPoint[0].Y;

            foreach (ZXing.ResultPoint point in resultPoint)
            {
                sX = sX < point.X ? sX : point.X;
                sY = sY < point.Y ? sY : point.Y;
                eX = eX > point.X ? eX : point.X;
                eY = eY > point.Y ? eY : point.Y;
            }

            OUTPUT_IMAGE = new Bitmap(INPUT_IMAGE);
            
            Graphics g = Graphics.FromImage(OUTPUT_IMAGE);
            g.DrawRectangle(new Pen(Color.Cyan, 4), sX, sY, eX - sX, eY - sY);
            g.Dispose();

            return 0;
        }

        public override int Run()
        {
            return ReadBarcode();
        }

    }
}

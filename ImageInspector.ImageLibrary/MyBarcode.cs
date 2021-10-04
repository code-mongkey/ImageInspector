using System.Drawing;

namespace ImageInspector.ImageLibrary
{
    public class MyBarcode
    {
        private ZXing.Result? result;
        public ZXing.Result Result
        {
            get {  return result; }
        }

        public void ReadBarcode(Image image)
        {
            if (image == null) return;

            ZXing.BarcodeReader barcodeReader = new ZXing.BarcodeReader();
            result = barcodeReader.Decode((Bitmap)image);
        }
    }
}

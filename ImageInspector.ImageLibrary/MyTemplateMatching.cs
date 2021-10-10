using OpenCvSharp;
using System.Drawing;

namespace ImageInspector.ImageLibrary
{
    public class MyTemplateMatching : CommonBase
    {
        public override Image INSPECTION_IMAGE { get; set; }
        public override Rectangle SEARCH_AREA { get; set; }
        public override object RESULT { get; set; }
        public override Rectangle FIND_AREA { get; set; }

        public Image TemplateImage { get; set; }
        public float Score { get; set;  }

        public override int Run()
        {
            int ret = 1;

            Image img = ImagePreprocessing.ConvertImage.CropImage(INSPECTION_IMAGE, SEARCH_AREA);

            Mat src = BitmapToMat((Bitmap)img);
            Mat tmplt = BitmapToMat((Bitmap)TemplateImage);
            Mat output = new Mat();

            Score = (float)Score / 100;
            Cv2.MatchTemplate(src, tmplt, output, TemplateMatchModes.CCoeffNormed);
            Cv2.Threshold(output, output, Score, 1.0, ThresholdTypes.Tozero);

            double minval, maxval;
            OpenCvSharp.Point minloc, maxloc;
            Cv2.MinMaxLoc(output, out minval, out maxval, out minloc, out maxloc);

            if (maxval > Score)
            {
                FIND_AREA = new Rectangle(maxloc.X, maxloc.Y, tmplt.Width, tmplt.Height);

                ret = 0;
            }

            return ret;
        }
    }
}

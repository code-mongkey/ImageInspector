using System.Drawing;

namespace ImageInspector.Tools
{
    public interface ToolInterface
    {
        int SetImage(ImageInspector.Controls.MyPicturebox display);
        int Confirm();
        int Cancel();

        // 툴 실행
        int Run();

        // 결과값 불러오기
        string GetResult();

        // 툴 해재
        void Release();
    }
}

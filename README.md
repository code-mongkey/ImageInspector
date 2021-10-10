# 영상 검사 프로그램
#
# 프로그램 설명
이 프로젝트는 영상처리를 통한 영상 검사 프로그램 입니다.
다양한 검사방법(검사툴)을 이용하여 적절한 검사방법을 찾을 수 있도록 구성하는걸 목표하였습니다.
#
# 프로그램 구성
Language: C# .NET 5.0 
Third Party: OpenCVSharp, ZXing
#
# 프로그램 사용방법
![MAIN화면]![image](https://user-images.githubusercontent.com/22908223/136704868-2429ade7-c4f7-4af7-b402-b33c8e2a50d3.png)

1. LOAD IMAGE 버튼을 클릭하여 이미지를 불러온다
2. 검사방법 선택 및 검사명을 입력하여 ADD 한다
3. 검사 방법을 이용하여 검사 테스트 확인 해 본다
#
# 프로그램 구조
1. 검사를 위한 각종 Tool 들은 UserControl로 구성되어 있으며 공통기능에 대해서는 ToolInterface를 통해 구성
2. 공통적으로 사용되는 이미지 변환 함수에 대해서는 ConvertImage 클래스를 활용
3. 검사를 위한 MyClass들은 CommonBase 상속을 통해 완전한 기능 구현

![image](https://user-images.githubusercontent.com/22908223/136705655-caab401c-c416-47f7-8800-36c05deb2783.png)


namespace ImageInspector.Tools
{
    partial class MatchingTool
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearchArea = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.picTemplate = new ImageInspector.Controls.MyPicturebox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numScore = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHide = new System.Windows.Forms.Button();
            this.picConvertImage = new ImageInspector.Controls.MyPicturebox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboConvertImage = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSetTemplate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchArea
            // 
            this.btnSearchArea.Location = new System.Drawing.Point(50, 15);
            this.btnSearchArea.Name = "btnSearchArea";
            this.btnSearchArea.Size = new System.Drawing.Size(205, 37);
            this.btnSearchArea.TabIndex = 4;
            this.btnSearchArea.Text = "SEARCH AREA";
            this.btnSearchArea.UseVisualStyleBackColor = true;
            this.btnSearchArea.Click += new System.EventHandler(this.btnSearchArea_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(48, 379);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(205, 37);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // picTemplate
            // 
            this.picTemplate.DRAWING = false;
            this.picTemplate.IMAGE = null;
            this.picTemplate.Location = new System.Drawing.Point(12, 21);
            this.picTemplate.Name = "picTemplate";
            this.picTemplate.Size = new System.Drawing.Size(178, 108);
            this.picTemplate.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "TEMPLATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "SCORE";
            // 
            // numScore
            // 
            this.numScore.Location = new System.Drawing.Point(99, 336);
            this.numScore.Name = "numScore";
            this.numScore.Size = new System.Drawing.Size(51, 23);
            this.numScore.TabIndex = 8;
            this.numScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numScore.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnHide);
            this.panel1.Controls.Add(this.picConvertImage);
            this.panel1.Location = new System.Drawing.Point(305, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 179);
            this.panel1.TabIndex = 17;
            this.panel1.Visible = false;
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(10, 143);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(184, 28);
            this.btnHide.TabIndex = 13;
            this.btnHide.Text = "HIDE";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // picConvertImage
            // 
            this.picConvertImage.DRAWING = false;
            this.picConvertImage.IMAGE = null;
            this.picConvertImage.Location = new System.Drawing.Point(10, 8);
            this.picConvertImage.Name = "picConvertImage";
            this.picConvertImage.Size = new System.Drawing.Size(184, 129);
            this.picConvertImage.TabIndex = 11;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(7, 37);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(188, 28);
            this.btnConvert.TabIndex = 16;
            this.btnConvert.Text = "CONVERT";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "ConvertImage";
            // 
            // cboConvertImage
            // 
            this.cboConvertImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConvertImage.FormattingEnabled = true;
            this.cboConvertImage.Location = new System.Drawing.Point(96, 9);
            this.cboConvertImage.Name = "cboConvertImage";
            this.cboConvertImage.Size = new System.Drawing.Size(99, 23);
            this.cboConvertImage.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboConvertImage);
            this.panel2.Controls.Add(this.btnConvert);
            this.panel2.Location = new System.Drawing.Point(48, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 76);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnSetTemplate);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.picTemplate);
            this.panel3.Location = new System.Drawing.Point(48, 149);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(205, 172);
            this.panel3.TabIndex = 19;
            // 
            // btnSetTemplate
            // 
            this.btnSetTemplate.Location = new System.Drawing.Point(12, 135);
            this.btnSetTemplate.Name = "btnSetTemplate";
            this.btnSetTemplate.Size = new System.Drawing.Size(178, 27);
            this.btnSetTemplate.TabIndex = 17;
            this.btnSetTemplate.Text = "SET TEMPLATE";
            this.btnSetTemplate.UseVisualStyleBackColor = true;
            this.btnSetTemplate.Click += new System.EventHandler(this.btnSetTemplate_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(198, 340);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(47, 15);
            this.lblResult.TabIndex = 20;
            this.lblResult.Text = "RESULT";
            // 
            // MatchingTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numScore);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnSearchArea);
            this.Name = "MatchingTool";
            this.Size = new System.Drawing.Size(300, 450);
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchArea;
        private System.Windows.Forms.Button btnRun;
        private Controls.MyPicturebox picTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numScore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHide;
        private Controls.MyPicturebox picConvertImage;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboConvertImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSetTemplate;
        private System.Windows.Forms.Label lblResult;
    }
}

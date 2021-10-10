
namespace ImageInspector.Tools
{
    partial class HistogramTool
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
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSearchArea = new System.Windows.Forms.Button();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboConvertImage = new System.Windows.Forms.ComboBox();
            this.myPicturebox1 = new ImageInspector.Controls.MyPicturebox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(49, 393);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(205, 37);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
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
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(165, 67);
            this.numMin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(89, 23);
            this.numMin.TabIndex = 5;
            this.numMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "MIN";
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(165, 97);
            this.numMax.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(89, 23);
            this.numMax.TabIndex = 5;
            this.numMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMax.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "MAX";
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(197, 125);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(53, 23);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "000";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "RESULT";
            // 
            // cboConvertImage
            // 
            this.cboConvertImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConvertImage.FormattingEnabled = true;
            this.cboConvertImage.Location = new System.Drawing.Point(97, 15);
            this.cboConvertImage.Name = "cboConvertImage";
            this.cboConvertImage.Size = new System.Drawing.Size(97, 23);
            this.cboConvertImage.TabIndex = 9;
            // 
            // myPicturebox1
            // 
            this.myPicturebox1.DRAWING = false;
            this.myPicturebox1.IMAGE = null;
            this.myPicturebox1.Location = new System.Drawing.Point(10, 85);
            this.myPicturebox1.Name = "myPicturebox1";
            this.myPicturebox1.Size = new System.Drawing.Size(184, 129);
            this.myPicturebox1.TabIndex = 11;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(10, 46);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(184, 28);
            this.btnConvert.TabIndex = 12;
            this.btnConvert.Text = "CONVERT";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.myPicturebox1);
            this.panel1.Controls.Add(this.btnConvert);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboConvertImage);
            this.panel1.Location = new System.Drawing.Point(49, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 224);
            this.panel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "ConvertImage";
            // 
            // HistogramTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMax);
            this.Controls.Add(this.numMin);
            this.Controls.Add(this.btnSearchArea);
            this.Controls.Add(this.btnRun);
            this.Name = "HistogramTool";
            this.Size = new System.Drawing.Size(300, 450);
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnSearchArea;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboConvertImage;
        private Controls.MyPicturebox myPicturebox1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}

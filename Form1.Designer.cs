namespace SimplePaint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblAppName = new Label();
            groupBox1 = new GroupBox();
            btnCircle = new Button();
            btnRectangle = new Button();
            btnLine = new Button();
            groupBox2 = new GroupBox();
            cmbColor = new ComboBox();
            groupBox3 = new GroupBox();
            trbLineWidth = new TrackBar();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            picCanvas = new PictureBox();
            panel1 = new Panel();
            trbZoom = new TrackBar();
            groupBox4 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbZoom).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = Color.CadetBlue;
            lblAppName.Location = new Point(23, 22);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(367, 74);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Simple Paint";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCircle);
            groupBox1.Controls.Add(btnRectangle);
            groupBox1.Controls.Add(btnLine);
            groupBox1.Location = new Point(23, 108);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(350, 139);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "도형 선텍";
            // 
            // btnCircle
            // 
            btnCircle.Image = (Image)resources.GetObject("btnCircle.Image");
            btnCircle.ImageAlign = ContentAlignment.TopCenter;
            btnCircle.Location = new Point(239, 34);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(92, 78);
            btnCircle.TabIndex = 2;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.UseVisualStyleBackColor = true;
            // 
            // btnRectangle
            // 
            btnRectangle.Image = (Image)resources.GetObject("btnRectangle.Image");
            btnRectangle.ImageAlign = ContentAlignment.TopCenter;
            btnRectangle.Location = new Point(125, 34);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(92, 78);
            btnRectangle.TabIndex = 1;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;
            btnRectangle.UseVisualStyleBackColor = true;
            // 
            // btnLine
            // 
            btnLine.Image = (Image)resources.GetObject("btnLine.Image");
            btnLine.ImageAlign = ContentAlignment.TopCenter;
            btnLine.Location = new Point(6, 34);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(92, 78);
            btnLine.TabIndex = 0;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbColor);
            groupBox2.Location = new Point(391, 108);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(225, 139);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "색 선텍";
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Black 검정", "Red 빨강", "Blue 파랑", "Green 녹색" });
            cmbColor.Location = new Point(6, 53);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(213, 38);
            cmbColor.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(trbLineWidth);
            groupBox3.Location = new Point(636, 108);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(276, 139);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "굵기 선텍";
            // 
            // trbLineWidth
            // 
            trbLineWidth.Location = new Point(6, 53);
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(264, 80);
            trbLineWidth.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.Beige;
            btnOpenFile.Font = new Font("맑은 고딕", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnOpenFile.Location = new Point(938, 22);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(143, 80);
            btnOpenFile.TabIndex = 3;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.CornflowerBlue;
            btnSaveFile.Font = new Font("맑은 고딕", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnSaveFile.Location = new Point(1099, 22);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(141, 80);
            btnSaveFile.TabIndex = 5;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // picCanvas
            // 
            picCanvas.BackColor = Color.White;
            picCanvas.Location = new Point(3, 3);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(1214, 522);
            picCanvas.SizeMode = PictureBoxSizeMode.StretchImage;
            picCanvas.TabIndex = 6;
            picCanvas.TabStop = false;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(picCanvas);
            panel1.Location = new Point(23, 253);
            panel1.Name = "panel1";
            panel1.Size = new Size(1229, 525);
            panel1.TabIndex = 7;
            // 
            // trbZoom
            // 
            trbZoom.Location = new Point(20, 53);
            trbZoom.Maximum = 500;
            trbZoom.Minimum = 10;
            trbZoom.Name = "trbZoom";
            trbZoom.Size = new Size(296, 80);
            trbZoom.TabIndex = 8;
            trbZoom.TickFrequency = 50;
            trbZoom.Value = 100;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(trbZoom);
            groupBox4.Location = new Point(918, 108);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(322, 139);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "크기 조절";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 813);
            Controls.Add(groupBox4);
            Controls.Add(panel1);
            Controls.Add(btnSaveFile);
            Controls.Add(btnOpenFile);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblAppName);
            Name = "Form1";
            Text = "Simple Paint v1.0";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trbZoom).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private GroupBox groupBox1;
        private Button btnCircle;
        private Button btnRectangle;
        private Button btnLine;
        private GroupBox groupBox2;
        private ComboBox cmbColor;
        private GroupBox groupBox3;
        private TrackBar trbLineWidth;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private PictureBox picCanvas;
        private Panel panel1;
        private TrackBar trbZoom;
        private GroupBox groupBox4;
    }
}

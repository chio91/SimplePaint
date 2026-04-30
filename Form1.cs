namespace SimplePaint
{

    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {

        enum ToolType { Line, Rectangle, Circle }  // 사용할 도형 타입
        private Bitmap canvasBitmap;          // 실제 그림이 저장되는 비트맵
        private Graphics canvasGraphics;      // 비트맵 위에 그리기 위한 객체
        private bool isDrawing = false;       // 현재 드래그 중인지 여부
        private Point startPoint;             // 드래그 시작점
        private Point endPoint;               // 드래그 끝점
        private ToolType currentTool = ToolType.Line;  // 현재 선택된 도형
        private Color currentColor = Color.Black;      // 현재 색상
        private int currentLineWidth = 2;              // 현재 선 두께

        // [추가할 변수] 현재 확대/축소 비율 (1.0 = 100%)
        private float zoomFactor = 1.0f;

        // [추가할 헬퍼 메서드] 화면에 줌인/줌아웃된 좌표를 실제 비트맵의 좌표로 변환
        private Point GetRealCoordinates(Point pt)
        {
            return new Point((int)(pt.X / zoomFactor), (int)(pt.Y / zoomFactor));
        }

        // [추가할 메서드] 줌 비율에 맞춰 캔버스(PictureBox)의 크기를 조절
        private void UpdateCanvasSize()
        {
            if (canvasBitmap != null)
            {
                picCanvas.Width = (int)(canvasBitmap.Width * zoomFactor);
                picCanvas.Height = (int)(canvasBitmap.Height * zoomFactor);
            }
        }

        public Form1()
        {
            InitializeComponent();

            // 캔버스초기화
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);   // 캔버스를 흰색으로 초기화

            picCanvas.Image = canvasBitmap;   // 그린 그림을 화면(PictureBox)에 표시

            // 마우스이벤트연결
            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;

            // picCanvas가다시그려질때PicCanvas_Paint함수를실행하도록연결
            picCanvas.Paint += PicCanvas_Paint;

            // 도형선택버튼이벤트연결
            btnLine.Click += btnLine_Click;
            btnRectangle.Click += btnRectangle_Click;
            btnCircle.Click += btnCircle_Click;

            // 색상콤보박스이벤트연결
            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            cmbColor.SelectedIndex = 0;  // 기본값: Black

            // 선두께트랙바이벤트연결
            trbLineWidth.Minimum = 1;    // 최소값
            trbLineWidth.Maximum = 10;   // 최대값
            trbLineWidth.Value = 5;

            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;
            btnSaveFile.Click += btnSaveFile_Click;
            btnOpenFile.Click += btnOpenFile_Click;

            trbZoom.ValueChanged += trbZoom_ValueChanged;
            picCanvas.MouseWheel += Zoom_MouseWheel;
            panel1.MouseWheel += Zoom_MouseWheel;
        }

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = GetRealCoordinates(e.Location); // [수정] 실제 좌표로 변환
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;
            endPoint = GetRealCoordinates(e.Location);   // [수정] 실제 좌표로 변환
            picCanvas.Invalidate();
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;
            isDrawing = false;
            endPoint = GetRealCoordinates(e.Location);   // [수정] 실제 좌표로 변환

            using (Pen pen = new Pen(currentColor, currentLineWidth))
            {
                DrawShape(canvasGraphics, pen, startPoint, endPoint);
            }
            picCanvas.Invalidate();
        }

        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawing) return;

            // [추가] 그려질 화면(Graphics) 자체를 줌 비율만큼 확대/축소시킵니다.
            e.Graphics.ScaleTransform(zoomFactor, zoomFactor);

            using (Pen previewPen = new Pen(currentColor, currentLineWidth))
            {
                previewPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                DrawShape(e.Graphics, previewPen, startPoint, endPoint);
            }
        }

        private void DrawShape(Graphics g, Pen pen, Point p1, Point p2)
        {
            Rectangle rect = GetRectangle(p1, p2); 
            switch (currentTool) 
            { 
                case ToolType.Line: 
                    g.DrawLine(pen, p1, p2); 
                    break; 
                case ToolType.Rectangle: 
                    g.DrawRectangle(pen, rect); 
                    break; 
                case ToolType.Circle: 
                    g.DrawEllipse(pen, rect); 
                    break; 
            } 
        }

        private Rectangle GetRectangle(Point p1, Point p2) 
        { 
            return new Rectangle(
                Math.Min(p1.X, p2.X), 
                Math.Min(p1.Y, p2.Y), 
                Math.Abs(p1.X - p2.X), 
                Math.Abs(p1.Y - p2.Y)
                );
        }

        private void btnLine_Click(object sender, EventArgs e) 
        { 
            currentTool = ToolType.Line;
        }
        private void btnRectangle_Click(object sender, EventArgs e) 
        { 
            currentTool = ToolType.Rectangle; 
        }
        private void btnCircle_Click(object sender, EventArgs e) 
        { 
            currentTool = ToolType.Circle; 
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0: // Black 검정
                        currentColor= Color.Black;
                    break;
                case 1: // Red 빨강
                        currentColor= Color.Red;
                    break;
                case 2: // Blue 파랑
                        currentColor= Color.Blue;
                    break;
                case 3: // Green 녹색
                        currentColor= Color.Green;
                    break;
                default:
                    currentColor= Color.Black;
                    break;
            }
        }

        private void trbLineWidth_ValueChanged(object sender, EventArgs e) 
        { 
            currentLineWidth = trbLineWidth.Value; 
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            // SaveFileDialog 객체 생성 (사용 후 자동 해제를 위해 using 블록 사용)
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "그림 저장하기";
                // 파일 형식 필터 설정 (PNG, JPG, BMP)
                sfd.Filter = "PNG 이미지 (*.png)|*.png|JPEG 이미지 (*.jpg)|*.jpg|비트맵 이미지 (*.bmp)|*.bmp";
                sfd.DefaultExt = "png";      // 기본 확장자
                sfd.AddExtension = true;     // 사용자가 확장자를 안 써도 자동으로 붙여줌

                // 사용자가 '저장' 버튼을 눌렀을 경우
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 선택한 파일의 확장자를 가져와서 소문자로 변환
                        string extension = System.IO.Path.GetExtension(sfd.FileName).ToLower();

                        // 저장할 이미지 포맷 결정 (기본값 PNG)
                        ImageFormat format = ImageFormat.Png;

                        switch (extension)
                        {
                            case ".jpg":
                            case ".jpeg":
                                format = ImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                format = ImageFormat.Bmp;
                                break;
                            case ".png":
                            default:
                                format = ImageFormat.Png;
                                break;
                        }

                        // 현재 그려진 비트맵(canvasBitmap)을 지정한 경로와 포맷으로 저장
                        canvasBitmap.Save(sfd.FileName, format);
                    }
                    catch (Exception ex)
                    {
                        // 저장 권한 없음, 디스크 용량 부족 등의 에러 처리
                        MessageBox.Show("파일을 저장하는 중 오류가 발생했습니다.\n" + ex.Message, "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "이미지 불러오기";
                ofd.Filter = "이미지 파일 (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|모든 파일 (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Image.FromFile로 바로 열면 파일 잠금(Lock) 현상이 발생해 
                        // 나중에 덮어쓰기 저장이 안 될 수 있으므로 복사본을 만들어 사용합니다.
                        using (Image tempImage = Image.FromFile(ofd.FileName))
                        {
                            // 1. 기존에 사용하던 캔버스 자원(메모리) 해제
                            if (canvasGraphics != null) canvasGraphics.Dispose();
                            if (canvasBitmap != null) canvasBitmap.Dispose();

                            // 2. 불러온 이미지와 똑같은 크기의 새 비트맵 생성 및 이미지 복사
                            canvasBitmap = new Bitmap(tempImage);

                            // 3. 캔버스(PictureBox)의 크기를 불러온 이미지의 크기에 맞춤
                            // (이미지가 크면 Panel의 AutoScroll 덕분에 자동으로 스크롤바가 생기고, 
                            //  작으면 PictureBox 크기가 이미지 크기만큼 줄어듭니다.)
                            UpdateCanvasSize();

                            // 4. 새로 만든 비트맵에 다시 그림을 그릴 수 있도록 Graphics 객체 재할당
                            canvasGraphics = Graphics.FromImage(canvasBitmap);

                            // 5. PictureBox에 새 비트맵 연결
                            picCanvas.Image = canvasBitmap;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("이미지를 불러오는 중 오류가 발생했습니다.\n" + ex.Message, "불러오기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void trbZoom_ValueChanged(object sender, EventArgs e)
        {
            // 트랙바의 값(10~500)을 백분율(0.1 ~ 5.0)로 변환
            zoomFactor = trbZoom.Value / 100f;
            UpdateCanvasSize();
        }

        private void Zoom_MouseWheel(object sender, MouseEventArgs e)
        {
            // 컨트롤(Ctrl) 키가 눌려있는지 확인
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                // 휠을 위로 굴리면 10씩 증가, 아래로 굴리면 10씩 감소
                int zoomChange = e.Delta > 0 ? 10 : -10;
                int newZoom = trbZoom.Value + zoomChange;

                // 트랙바의 최소/최대치를 넘지 않도록 제한
                if (newZoom < trbZoom.Minimum) newZoom = trbZoom.Minimum;
                if (newZoom > trbZoom.Maximum) newZoom = trbZoom.Maximum;

                trbZoom.Value = newZoom; // 값이 바뀌면 자동으로 UpdateCanvasSize()가 실행됨

                // [스크롤 방지 핵심 코드]
                // 이벤트 인자가 HandledMouseEventArgs로 변환 가능한지 확인 후,
                // Handled를 true로 설정하여 패널의 기본 스크롤 동작을 완벽히 차단합니다.
                if (e is HandledMouseEventArgs hme)
                {
                    hme.Handled = true;
                }
            }
        }
    }
}

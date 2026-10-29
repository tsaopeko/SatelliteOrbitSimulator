namespace SatelliteOrbitSimulator.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            btnMinimize = new Button();
            btnMaximize = new Button();
            btnClose = new Button();
            lbAppSubtitle = new Label();
            lbAppTitle = new Label();
            tlpMainLayout = new TableLayoutPanel();
            pnlSettings = new Panel();
            trkTimeScale = new TrackBar();
            lbTimeScaleSetting = new Label();
            btnCoordinateView = new Button();
            btnSpaceView = new Button();
            btnReset = new Button();
            btnPause = new Button();
            btnStart = new Button();
            nudInitialAngle = new NumericUpDown();
            lbInitialAngle = new Label();
            nudInitialVelocity = new NumericUpDown();
            lbInitialVelocity = new Label();
            nudAltitude = new NumericUpDown();
            lbAltitude = new Label();
            lbSettingsSubtitle = new Label();
            lbSettingsTitle = new Label();
            pnlSimulation = new Panel();
            picOrbitCanvas = new PictureBox();
            pnlSimulationToolbar = new Panel();
            lbSimulationStatus = new Label();
            lbSimulationTitle = new Label();
            pnlTelemetry = new Panel();
            lbTimeScale = new Label();
            lbCurrentView = new Label();
            lbTheoreticalPeriodValue = new Label();
            lbTheoreticalPeriodTitle = new Label();
            lbTheoreticalSpeedValue = new Label();
            lbTheoreticalSpeedTitle = new Label();
            lbElapsedTimeValue = new Label();
            lbElapsedTimeTitle = new Label();
            lbCenterDistanceValue = new Label();
            lbCenterDistanceTitle = new Label();
            lbCurrentSpeedValue = new Label();
            lbCurrentSpeedTitle = new Label();
            lbCurrentAltitudeValue = new Label();
            lbCurrentAltitudeTitle = new Label();
            lbTelemetrySubtitle = new Label();
            lbTelemetryTitle = new Label();
            pnlHeader.SuspendLayout();
            tlpMainLayout.SuspendLayout();
            pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkTimeScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudInitialAngle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudInitialVelocity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAltitude).BeginInit();
            pnlSimulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOrbitCanvas).BeginInit();
            pnlSimulationToolbar.SuspendLayout();
            pnlTelemetry.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(16, 28, 43);
            pnlHeader.Controls.Add(btnMinimize);
            pnlHeader.Controls.Add(btnMaximize);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lbAppSubtitle);
            pnlHeader.Controls.Add(lbAppTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(16, 0, 8, 0);
            pnlHeader.Size = new Size(1424, 50);
            pnlHeader.TabIndex = 0;
            pnlHeader.MouseDown += Header_MouseDown;
            // 
            // btnMinimize
            // 
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseDownBackColor = Color.FromArgb(53, 75, 99);
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 56, 77);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.FromArgb(214, 228, 240);
            btnMinimize.Location = new Point(1266, 0);
            btnMinimize.Margin = new Padding(0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(50, 50);
            btnMinimize.TabIndex = 4;
            btnMinimize.Text = "−";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnMaximize
            // 
            btnMaximize.Dock = DockStyle.Right;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatAppearance.MouseDownBackColor = Color.FromArgb(53, 75, 99);
            btnMaximize.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 56, 77);
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMaximize.ForeColor = Color.FromArgb(214, 228, 240);
            btnMaximize.Location = new Point(1316, 0);
            btnMaximize.Margin = new Padding(0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(50, 50);
            btnMaximize.TabIndex = 3;
            btnMaximize.Text = "□";
            btnMaximize.UseVisualStyleBackColor = true;
            btnMaximize.Click += btnMaximize_Click;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(143, 29, 42);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(196, 43, 59);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1366, 0);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(50, 50);
            btnClose.TabIndex = 1;
            btnClose.Text = "×";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lbAppSubtitle
            // 
            lbAppSubtitle.AutoSize = true;
            lbAppSubtitle.Font = new Font("Segoe UI", 8F);
            lbAppSubtitle.ForeColor = Color.FromArgb(158, 180, 201);
            lbAppSubtitle.Location = new Point(16, 27);
            lbAppSubtitle.Name = "lbAppSubtitle";
            lbAppSubtitle.Size = new Size(150, 13);
            lbAppSubtitle.TabIndex = 2;
            lbAppSubtitle.Text = "人造衛星二維軌道模擬器";
            lbAppSubtitle.MouseDown += Header_MouseDown;
            // 
            // lbAppTitle
            // 
            lbAppTitle.AutoSize = true;
            lbAppTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbAppTitle.ForeColor = Color.FromArgb(230, 241, 255);
            lbAppTitle.Location = new Point(16, 4);
            lbAppTitle.Name = "lbAppTitle";
            lbAppTitle.Size = new Size(229, 21);
            lbAppTitle.TabIndex = 0;
            lbAppTitle.Text = "SATELLITE ORBIT SIMULATOR";
            lbAppTitle.TextAlign = ContentAlignment.MiddleLeft;
            lbAppTitle.MouseDown += Header_MouseDown;
            // 
            // tlpMainLayout
            // 
            tlpMainLayout.ColumnCount = 3;
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280F));
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280F));
            tlpMainLayout.Controls.Add(pnlSettings, 0, 0);
            tlpMainLayout.Controls.Add(pnlSimulation, 1, 0);
            tlpMainLayout.Controls.Add(pnlTelemetry, 2, 0);
            tlpMainLayout.Dock = DockStyle.Fill;
            tlpMainLayout.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpMainLayout.Location = new Point(0, 50);
            tlpMainLayout.Margin = new Padding(0);
            tlpMainLayout.Name = "tlpMainLayout";
            tlpMainLayout.RowCount = 1;
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMainLayout.Size = new Size(1424, 811);
            tlpMainLayout.TabIndex = 1;
            // 
            // pnlSettings
            // 
            pnlSettings.BackColor = Color.FromArgb(17, 29, 45);
            pnlSettings.Controls.Add(trkTimeScale);
            pnlSettings.Controls.Add(lbTimeScaleSetting);
            pnlSettings.Controls.Add(btnCoordinateView);
            pnlSettings.Controls.Add(btnSpaceView);
            pnlSettings.Controls.Add(btnReset);
            pnlSettings.Controls.Add(btnPause);
            pnlSettings.Controls.Add(btnStart);
            pnlSettings.Controls.Add(nudInitialAngle);
            pnlSettings.Controls.Add(lbInitialAngle);
            pnlSettings.Controls.Add(nudInitialVelocity);
            pnlSettings.Controls.Add(lbInitialVelocity);
            pnlSettings.Controls.Add(nudAltitude);
            pnlSettings.Controls.Add(lbAltitude);
            pnlSettings.Controls.Add(lbSettingsSubtitle);
            pnlSettings.Controls.Add(lbSettingsTitle);
            pnlSettings.Dock = DockStyle.Fill;
            pnlSettings.Location = new Point(0, 0);
            pnlSettings.Margin = new Padding(0);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Padding = new Padding(12);
            pnlSettings.Size = new Size(280, 811);
            pnlSettings.TabIndex = 0;
            // 
            // trkTimeScale
            // 
            trkTimeScale.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trkTimeScale.AutoSize = false;
            trkTimeScale.Location = new Point(12, 562);
            trkTimeScale.Margin = new Padding(0);
            trkTimeScale.Maximum = 20;
            trkTimeScale.Minimum = 1;
            trkTimeScale.Name = "trkTimeScale";
            trkTimeScale.Size = new Size(244, 40);
            trkTimeScale.TabIndex = 14;
            trkTimeScale.Value = 1;
            trkTimeScale.ValueChanged += trkTimeScale_ValueChanged;
            // 
            // lbTimeScaleSetting
            // 
            lbTimeScaleSetting.AutoSize = true;
            lbTimeScaleSetting.ForeColor = Color.FromArgb(158, 180, 201);
            lbTimeScaleSetting.Location = new Point(12, 540);
            lbTimeScaleSetting.Margin = new Padding(0);
            lbTimeScaleSetting.Name = "lbTimeScaleSetting";
            lbTimeScaleSetting.Size = new Size(85, 15);
            lbTimeScaleSetting.TabIndex = 13;
            lbTimeScaleSetting.Text = "模擬時間倍率";
            // 
            // btnCoordinateView
            // 
            btnCoordinateView.BackColor = Color.FromArgb(24, 40, 58);
            btnCoordinateView.FlatAppearance.MouseDownBackColor = Color.FromArgb(53, 75, 99);
            btnCoordinateView.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 56, 77);
            btnCoordinateView.FlatStyle = FlatStyle.Flat;
            btnCoordinateView.ForeColor = Color.FromArgb(230, 241, 255);
            btnCoordinateView.Location = new Point(136, 492);
            btnCoordinateView.Name = "btnCoordinateView";
            btnCoordinateView.Size = new Size(120, 36);
            btnCoordinateView.TabIndex = 12;
            btnCoordinateView.Text = "座標圖";
            btnCoordinateView.UseVisualStyleBackColor = false;
            btnCoordinateView.Click += btnCoordinateView_Click;
            // 
            // btnSpaceView
            // 
            btnSpaceView.BackColor = Color.FromArgb(86, 217, 245);
            btnSpaceView.FlatAppearance.MouseDownBackColor = Color.FromArgb(43, 187, 217);
            btnSpaceView.FlatAppearance.MouseOverBackColor = Color.FromArgb(131, 231, 248);
            btnSpaceView.FlatStyle = FlatStyle.Flat;
            btnSpaceView.ForeColor = Color.FromArgb(8, 20, 33);
            btnSpaceView.Location = new Point(12, 492);
            btnSpaceView.Name = "btnSpaceView";
            btnSpaceView.Size = new Size(120, 36);
            btnSpaceView.TabIndex = 11;
            btnSpaceView.Text = "太空視圖";
            btnSpaceView.UseVisualStyleBackColor = false;
            btnSpaceView.Click += btnSpaceView_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(24, 40, 58);
            btnReset.FlatAppearance.MouseDownBackColor = Color.FromArgb(53, 75, 99);
            btnReset.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 56, 77);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReset.ForeColor = Color.FromArgb(184, 201, 218);
            btnReset.Location = new Point(12, 420);
            btnReset.Margin = new Padding(0);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(244, 36);
            btnReset.TabIndex = 10;
            btnReset.Text = "↻ 重設";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnPause
            // 
            btnPause.BackColor = Color.FromArgb(24, 40, 58);
            btnPause.FlatAppearance.BorderSize = 0;
            btnPause.FlatAppearance.MouseDownBackColor = Color.FromArgb(53, 75, 99);
            btnPause.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 56, 77);
            btnPause.FlatStyle = FlatStyle.Flat;
            btnPause.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPause.ForeColor = Color.FromArgb(230, 241, 255);
            btnPause.Location = new Point(12, 376);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(244, 36);
            btnPause.TabIndex = 9;
            btnPause.Text = "Ⅱ 暫停";
            btnPause.UseVisualStyleBackColor = false;
            btnPause.Click += btnPause_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(86, 217, 245);
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatAppearance.MouseDownBackColor = Color.FromArgb(43, 187, 217);
            btnStart.FlatAppearance.MouseOverBackColor = Color.FromArgb(131, 231, 248);
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStart.ForeColor = Color.FromArgb(8, 20, 33);
            btnStart.Location = new Point(12, 332);
            btnStart.Margin = new Padding(0);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(244, 36);
            btnStart.TabIndex = 8;
            btnStart.Text = "▶ 開始";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // nudInitialAngle
            // 
            nudInitialAngle.BackColor = Color.FromArgb(24, 40, 58);
            nudInitialAngle.Font = new Font("Segoe UI", 10F);
            nudInitialAngle.ForeColor = Color.FromArgb(230, 241, 255);
            nudInitialAngle.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudInitialAngle.Location = new Point(12, 248);
            nudInitialAngle.Maximum = new decimal(new int[] { 359, 0, 0, 0 });
            nudInitialAngle.Name = "nudInitialAngle";
            nudInitialAngle.Size = new Size(244, 25);
            nudInitialAngle.TabIndex = 7;
            nudInitialAngle.TextAlign = HorizontalAlignment.Right;
            // 
            // lbInitialAngle
            // 
            lbInitialAngle.AutoSize = true;
            lbInitialAngle.ForeColor = Color.FromArgb(184, 201, 218);
            lbInitialAngle.Location = new Point(12, 226);
            lbInitialAngle.Name = "lbInitialAngle";
            lbInitialAngle.Size = new Size(90, 15);
            lbInitialAngle.TabIndex = 6;
            lbInitialAngle.Text = "初始角度（°）";
            // 
            // nudInitialVelocity
            // 
            nudInitialVelocity.BackColor = Color.FromArgb(24, 40, 58);
            nudInitialVelocity.DecimalPlaces = 2;
            nudInitialVelocity.Font = new Font("Segoe UI", 10F);
            nudInitialVelocity.ForeColor = Color.FromArgb(230, 241, 255);
            nudInitialVelocity.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudInitialVelocity.Location = new Point(12, 176);
            nudInitialVelocity.Margin = new Padding(0);
            nudInitialVelocity.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudInitialVelocity.Name = "nudInitialVelocity";
            nudInitialVelocity.Size = new Size(244, 25);
            nudInitialVelocity.TabIndex = 5;
            nudInitialVelocity.TextAlign = HorizontalAlignment.Right;
            nudInitialVelocity.Value = new decimal(new int[] { 767, 0, 0, 131072 });
            // 
            // lbInitialVelocity
            // 
            lbInitialVelocity.AutoSize = true;
            lbInitialVelocity.ForeColor = Color.FromArgb(184, 201, 218);
            lbInitialVelocity.Location = new Point(12, 154);
            lbInitialVelocity.Name = "lbInitialVelocity";
            lbInitialVelocity.Size = new Size(112, 15);
            lbInitialVelocity.TabIndex = 4;
            lbInitialVelocity.Text = "初始速度（km/s）";
            // 
            // nudAltitude
            // 
            nudAltitude.BackColor = Color.FromArgb(24, 40, 58);
            nudAltitude.Font = new Font("Segoe UI", 10F);
            nudAltitude.ForeColor = Color.FromArgb(230, 241, 255);
            nudAltitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            nudAltitude.Location = new Point(12, 104);
            nudAltitude.Margin = new Padding(0);
            nudAltitude.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudAltitude.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            nudAltitude.Name = "nudAltitude";
            nudAltitude.Size = new Size(244, 25);
            nudAltitude.TabIndex = 3;
            nudAltitude.TextAlign = HorizontalAlignment.Right;
            nudAltitude.Value = new decimal(new int[] { 400, 0, 0, 0 });
            nudAltitude.ValueChanged += nudAltitude_ValueChanged;
            // 
            // lbAltitude
            // 
            lbAltitude.AutoSize = true;
            lbAltitude.ForeColor = Color.FromArgb(184, 201, 218);
            lbAltitude.Location = new Point(12, 82);
            lbAltitude.Name = "lbAltitude";
            lbAltitude.Size = new Size(102, 15);
            lbAltitude.TabIndex = 2;
            lbAltitude.Text = "初始高度（km）";
            // 
            // lbSettingsSubtitle
            // 
            lbSettingsSubtitle.AutoSize = true;
            lbSettingsSubtitle.Font = new Font("Segoe UI", 8F);
            lbSettingsSubtitle.ForeColor = Color.FromArgb(130, 152, 174);
            lbSettingsSubtitle.Location = new Point(12, 39);
            lbSettingsSubtitle.Name = "lbSettingsSubtitle";
            lbSettingsSubtitle.Size = new Size(94, 13);
            lbSettingsSubtitle.TabIndex = 1;
            lbSettingsSubtitle.Text = "CONFIGURATION";
            // 
            // lbSettingsTitle
            // 
            lbSettingsTitle.AutoSize = true;
            lbSettingsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbSettingsTitle.ForeColor = Color.FromArgb(230, 241, 255);
            lbSettingsTitle.Location = new Point(12, 16);
            lbSettingsTitle.Margin = new Padding(0);
            lbSettingsTitle.Name = "lbSettingsTitle";
            lbSettingsTitle.Size = new Size(118, 21);
            lbSettingsTitle.TabIndex = 0;
            lbSettingsTitle.Text = "軌道參數設定";
            // 
            // pnlSimulation
            // 
            pnlSimulation.BackColor = Color.FromArgb(8, 20, 33);
            pnlSimulation.Controls.Add(picOrbitCanvas);
            pnlSimulation.Controls.Add(pnlSimulationToolbar);
            pnlSimulation.Dock = DockStyle.Fill;
            pnlSimulation.Location = new Point(280, 0);
            pnlSimulation.Margin = new Padding(0);
            pnlSimulation.Name = "pnlSimulation";
            pnlSimulation.Padding = new Padding(8);
            pnlSimulation.Size = new Size(864, 811);
            pnlSimulation.TabIndex = 1;
            // 
            // picOrbitCanvas
            // 
            picOrbitCanvas.Dock = DockStyle.Fill;
            picOrbitCanvas.Location = new Point(8, 52);
            picOrbitCanvas.Margin = new Padding(0);
            picOrbitCanvas.Name = "picOrbitCanvas";
            picOrbitCanvas.Size = new Size(848, 751);
            picOrbitCanvas.TabIndex = 1;
            picOrbitCanvas.TabStop = false;
            picOrbitCanvas.Paint += picOrbitCanvas_Paint;
            picOrbitCanvas.Resize += picOrbitCanvas_Resize;
            // 
            // pnlSimulationToolbar
            // 
            pnlSimulationToolbar.BackColor = Color.FromArgb(16, 28, 43);
            pnlSimulationToolbar.Controls.Add(lbSimulationStatus);
            pnlSimulationToolbar.Controls.Add(lbSimulationTitle);
            pnlSimulationToolbar.Dock = DockStyle.Top;
            pnlSimulationToolbar.Location = new Point(8, 8);
            pnlSimulationToolbar.Name = "pnlSimulationToolbar";
            pnlSimulationToolbar.Padding = new Padding(12, 0, 12, 0);
            pnlSimulationToolbar.Size = new Size(848, 44);
            pnlSimulationToolbar.TabIndex = 0;
            // 
            // lbSimulationStatus
            // 
            lbSimulationStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbSimulationStatus.AutoSize = true;
            lbSimulationStatus.ForeColor = Color.FromArgb(158, 180, 201);
            lbSimulationStatus.Location = new Point(774, 15);
            lbSimulationStatus.Margin = new Padding(0);
            lbSimulationStatus.Name = "lbSimulationStatus";
            lbSimulationStatus.Size = new Size(59, 15);
            lbSimulationStatus.TabIndex = 1;
            lbSimulationStatus.Text = "尚未開始";
            // 
            // lbSimulationTitle
            // 
            lbSimulationTitle.AutoSize = true;
            lbSimulationTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbSimulationTitle.ForeColor = Color.FromArgb(230, 241, 255);
            lbSimulationTitle.Location = new Point(12, 13);
            lbSimulationTitle.Margin = new Padding(0);
            lbSimulationTitle.Name = "lbSimulationTitle";
            lbSimulationTitle.Size = new Size(69, 19);
            lbSimulationTitle.TabIndex = 0;
            lbSimulationTitle.Text = "軌道模擬";
            // 
            // pnlTelemetry
            // 
            pnlTelemetry.BackColor = Color.FromArgb(17, 29, 45);
            pnlTelemetry.Controls.Add(lbTimeScale);
            pnlTelemetry.Controls.Add(lbCurrentView);
            pnlTelemetry.Controls.Add(lbTheoreticalPeriodValue);
            pnlTelemetry.Controls.Add(lbTheoreticalPeriodTitle);
            pnlTelemetry.Controls.Add(lbTheoreticalSpeedValue);
            pnlTelemetry.Controls.Add(lbTheoreticalSpeedTitle);
            pnlTelemetry.Controls.Add(lbElapsedTimeValue);
            pnlTelemetry.Controls.Add(lbElapsedTimeTitle);
            pnlTelemetry.Controls.Add(lbCenterDistanceValue);
            pnlTelemetry.Controls.Add(lbCenterDistanceTitle);
            pnlTelemetry.Controls.Add(lbCurrentSpeedValue);
            pnlTelemetry.Controls.Add(lbCurrentSpeedTitle);
            pnlTelemetry.Controls.Add(lbCurrentAltitudeValue);
            pnlTelemetry.Controls.Add(lbCurrentAltitudeTitle);
            pnlTelemetry.Controls.Add(lbTelemetrySubtitle);
            pnlTelemetry.Controls.Add(lbTelemetryTitle);
            pnlTelemetry.Dock = DockStyle.Fill;
            pnlTelemetry.Location = new Point(1144, 0);
            pnlTelemetry.Margin = new Padding(0);
            pnlTelemetry.Name = "pnlTelemetry";
            pnlTelemetry.Padding = new Padding(12);
            pnlTelemetry.Size = new Size(280, 811);
            pnlTelemetry.TabIndex = 2;
            // 
            // lbTimeScale
            // 
            lbTimeScale.AutoSize = true;
            lbTimeScale.ForeColor = Color.FromArgb(184, 201, 218);
            lbTimeScale.Location = new Point(12, 581);
            lbTimeScale.Name = "lbTimeScale";
            lbTimeScale.Size = new Size(86, 15);
            lbTimeScale.TabIndex = 15;
            lbTimeScale.Text = "時間倍率：1×";
            // 
            // lbCurrentView
            // 
            lbCurrentView.AutoSize = true;
            lbCurrentView.ForeColor = Color.FromArgb(184, 201, 218);
            lbCurrentView.Location = new Point(12, 555);
            lbCurrentView.Name = "lbCurrentView";
            lbCurrentView.Size = new Size(124, 15);
            lbCurrentView.TabIndex = 14;
            lbCurrentView.Text = "畫面模式：太空視圖";
            // 
            // lbTheoreticalPeriodValue
            // 
            lbTheoreticalPeriodValue.AutoSize = true;
            lbTheoreticalPeriodValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbTheoreticalPeriodValue.ForeColor = Color.FromArgb(167, 243, 208);
            lbTheoreticalPeriodValue.Location = new Point(12, 487);
            lbTheoreticalPeriodValue.Name = "lbTheoreticalPeriodValue";
            lbTheoreticalPeriodValue.Size = new Size(103, 21);
            lbTheoreticalPeriodValue.TabIndex = 13;
            lbTheoreticalPeriodValue.Text = "約 92.6 分鐘";
            // 
            // lbTheoreticalPeriodTitle
            // 
            lbTheoreticalPeriodTitle.AutoSize = true;
            lbTheoreticalPeriodTitle.ForeColor = Color.FromArgb(158, 180, 201);
            lbTheoreticalPeriodTitle.Location = new Point(12, 466);
            lbTheoreticalPeriodTitle.Name = "lbTheoreticalPeriodTitle";
            lbTheoreticalPeriodTitle.Size = new Size(85, 15);
            lbTheoreticalPeriodTitle.TabIndex = 12;
            lbTheoreticalPeriodTitle.Text = "理論軌道週期";
            // 
            // lbTheoreticalSpeedValue
            // 
            lbTheoreticalSpeedValue.AutoSize = true;
            lbTheoreticalSpeedValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbTheoreticalSpeedValue.ForeColor = Color.FromArgb(167, 243, 208);
            lbTheoreticalSpeedValue.Location = new Point(12, 426);
            lbTheoreticalSpeedValue.Name = "lbTheoreticalSpeedValue";
            lbTheoreticalSpeedValue.Size = new Size(83, 21);
            lbTheoreticalSpeedValue.TabIndex = 11;
            lbTheoreticalSpeedValue.Text = "7.67 km/s";
            // 
            // lbTheoreticalSpeedTitle
            // 
            lbTheoreticalSpeedTitle.AutoSize = true;
            lbTheoreticalSpeedTitle.ForeColor = Color.FromArgb(158, 180, 201);
            lbTheoreticalSpeedTitle.Location = new Point(12, 405);
            lbTheoreticalSpeedTitle.Name = "lbTheoreticalSpeedTitle";
            lbTheoreticalSpeedTitle.Size = new Size(85, 15);
            lbTheoreticalSpeedTitle.TabIndex = 10;
            lbTheoreticalSpeedTitle.Text = "理論軌道速度";
            // 
            // lbElapsedTimeValue
            // 
            lbElapsedTimeValue.AutoSize = true;
            lbElapsedTimeValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbElapsedTimeValue.ForeColor = Color.FromArgb(230, 241, 255);
            lbElapsedTimeValue.Location = new Point(12, 316);
            lbElapsedTimeValue.Name = "lbElapsedTimeValue";
            lbElapsedTimeValue.Size = new Size(94, 28);
            lbElapsedTimeValue.TabIndex = 9;
            lbElapsedTimeValue.Text = "00:00:00";
            // 
            // lbElapsedTimeTitle
            // 
            lbElapsedTimeTitle.AutoSize = true;
            lbElapsedTimeTitle.ForeColor = Color.FromArgb(158, 180, 201);
            lbElapsedTimeTitle.Location = new Point(12, 295);
            lbElapsedTimeTitle.Name = "lbElapsedTimeTitle";
            lbElapsedTimeTitle.Size = new Size(59, 15);
            lbElapsedTimeTitle.TabIndex = 8;
            lbElapsedTimeTitle.Text = "運行時間";
            // 
            // lbCenterDistanceValue
            // 
            lbCenterDistanceValue.AutoSize = true;
            lbCenterDistanceValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbCenterDistanceValue.ForeColor = Color.FromArgb(86, 217, 245);
            lbCenterDistanceValue.Location = new Point(12, 245);
            lbCenterDistanceValue.Name = "lbCenterDistanceValue";
            lbCenterDistanceValue.Size = new Size(124, 28);
            lbCenterDistanceValue.TabIndex = 7;
            lbCenterDistanceValue.Text = "6771.00 km";
            // 
            // lbCenterDistanceTitle
            // 
            lbCenterDistanceTitle.AutoSize = true;
            lbCenterDistanceTitle.ForeColor = Color.FromArgb(158, 180, 201);
            lbCenterDistanceTitle.Location = new Point(12, 224);
            lbCenterDistanceTitle.Name = "lbCenterDistanceTitle";
            lbCenterDistanceTitle.Size = new Size(59, 15);
            lbCenterDistanceTitle.TabIndex = 6;
            lbCenterDistanceTitle.Text = "地心距離";
            // 
            // lbCurrentSpeedValue
            // 
            lbCurrentSpeedValue.AutoSize = true;
            lbCurrentSpeedValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbCurrentSpeedValue.ForeColor = Color.FromArgb(86, 217, 245);
            lbCurrentSpeedValue.Location = new Point(12, 174);
            lbCurrentSpeedValue.Name = "lbCurrentSpeedValue";
            lbCurrentSpeedValue.Size = new Size(106, 28);
            lbCurrentSpeedValue.TabIndex = 5;
            lbCurrentSpeedValue.Text = "7.67 km/s";
            // 
            // lbCurrentSpeedTitle
            // 
            lbCurrentSpeedTitle.AutoSize = true;
            lbCurrentSpeedTitle.ForeColor = Color.FromArgb(158, 180, 201);
            lbCurrentSpeedTitle.Location = new Point(12, 153);
            lbCurrentSpeedTitle.Name = "lbCurrentSpeedTitle";
            lbCurrentSpeedTitle.Size = new Size(59, 15);
            lbCurrentSpeedTitle.TabIndex = 4;
            lbCurrentSpeedTitle.Text = "當前速度";
            // 
            // lbCurrentAltitudeValue
            // 
            lbCurrentAltitudeValue.AutoSize = true;
            lbCurrentAltitudeValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbCurrentAltitudeValue.ForeColor = Color.FromArgb(86, 217, 245);
            lbCurrentAltitudeValue.Location = new Point(12, 103);
            lbCurrentAltitudeValue.Name = "lbCurrentAltitudeValue";
            lbCurrentAltitudeValue.Size = new Size(112, 28);
            lbCurrentAltitudeValue.TabIndex = 3;
            lbCurrentAltitudeValue.Text = "400.00 km";
            // 
            // lbCurrentAltitudeTitle
            // 
            lbCurrentAltitudeTitle.AutoSize = true;
            lbCurrentAltitudeTitle.ForeColor = Color.FromArgb(158, 180, 201);
            lbCurrentAltitudeTitle.Location = new Point(12, 82);
            lbCurrentAltitudeTitle.Name = "lbCurrentAltitudeTitle";
            lbCurrentAltitudeTitle.Size = new Size(59, 15);
            lbCurrentAltitudeTitle.TabIndex = 2;
            lbCurrentAltitudeTitle.Text = "當前高度";
            // 
            // lbTelemetrySubtitle
            // 
            lbTelemetrySubtitle.AutoSize = true;
            lbTelemetrySubtitle.Font = new Font("Segoe UI", 8F);
            lbTelemetrySubtitle.ForeColor = Color.FromArgb(130, 152, 174);
            lbTelemetrySubtitle.Location = new Point(12, 39);
            lbTelemetrySubtitle.Name = "lbTelemetrySubtitle";
            lbTelemetrySubtitle.Size = new Size(62, 13);
            lbTelemetrySubtitle.TabIndex = 1;
            lbTelemetrySubtitle.Text = "TELEMETRY";
            // 
            // lbTelemetryTitle
            // 
            lbTelemetryTitle.AutoSize = true;
            lbTelemetryTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbTelemetryTitle.ForeColor = Color.FromArgb(230, 241, 255);
            lbTelemetryTitle.Location = new Point(12, 16);
            lbTelemetryTitle.Margin = new Padding(0);
            lbTelemetryTitle.Name = "lbTelemetryTitle";
            lbTelemetryTitle.Size = new Size(118, 21);
            lbTelemetryTitle.TabIndex = 0;
            lbTelemetryTitle.Text = "衛星即時數據";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(11, 18, 32);
            ClientSize = new Size(1424, 861);
            Controls.Add(tlpMainLayout);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MinimumSize = new Size(1100, 700);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "人造衛星二維軌道模擬器";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpMainLayout.ResumeLayout(false);
            pnlSettings.ResumeLayout(false);
            pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkTimeScale).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudInitialAngle).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudInitialVelocity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAltitude).EndInit();
            pnlSimulation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOrbitCanvas).EndInit();
            pnlSimulationToolbar.ResumeLayout(false);
            pnlSimulationToolbar.PerformLayout();
            pnlTelemetry.ResumeLayout(false);
            pnlTelemetry.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lbAppTitle;
        private Button btnClose;
        private Button btnMaximize;
        private Label lbAppSubtitle;
        private Button btnMinimize;
        private TableLayoutPanel tlpMainLayout;
        private Panel pnlSettings;
        private Panel pnlSimulation;
        private Panel pnlTelemetry;
        private Label lbSettingsTitle;
        private Label lbSettingsSubtitle;
        private Label lbAltitude;
        private NumericUpDown nudInitialVelocity;
        private Label lbInitialVelocity;
        private NumericUpDown nudAltitude;
        private Button btnStart;
        private NumericUpDown nudInitialAngle;
        private Label lbInitialAngle;
        private Button btnReset;
        private Button btnPause;
        private Button btnCoordinateView;
        private Button btnSpaceView;
        private Panel pnlSimulationToolbar;
        private PictureBox picOrbitCanvas;
        private Label lbSimulationStatus;
        private Label lbSimulationTitle;
        private Label lbTelemetryTitle;
        private Label lbCurrentAltitudeValue;
        private Label lbCurrentAltitudeTitle;
        private Label lbTelemetrySubtitle;
        private Label lbCurrentSpeedTitle;
        private Label lbElapsedTimeValue;
        private Label lbElapsedTimeTitle;
        private Label lbCenterDistanceValue;
        private Label lbCenterDistanceTitle;
        private Label lbCurrentSpeedValue;
        private Label lbTheoreticalSpeedValue;
        private Label lbTheoreticalSpeedTitle;
        private Label lbTheoreticalPeriodValue;
        private Label lbTheoreticalPeriodTitle;
        private Label lbTimeScale;
        private Label lbCurrentView;
        private Label lbTimeScaleSetting;
        private TrackBar trkTimeScale;
    }
}
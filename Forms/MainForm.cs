using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SatelliteOrbitSimulator.Forms
{
    public partial class MainForm : Form
    {
        private const int WM_NCLBUTTONDOWN = 0x00A1;    // 讓windows將目前視窗視為標題列拖移操作
        private const int HTCAPTION = 0x0002;   // 表示視窗標題列的命中區域
        private readonly OrbitSimulator _simulator = new OrbitSimulator();  // 負責計算衛星的軌道運動
        private readonly System.Windows.Forms.Timer _simulationTimer = new System.Windows.Forms.Timer();    // 控制軌道模擬更新頻率的計時器
        private bool _isRunning; // 紀錄模擬是否正在執行
        private readonly OrbitRenderer _orbitRenderer = new OrbitRenderer();    // 負責繪製地球, 軌道與衛星
        private OrbitViewMode _currentViewMode = OrbitViewMode.Space;   // 目前使用的軌道顯示模式
        private double _initiaOrbitRadiusKm;    // 初始軌道半徑, 單位為公里
        private double _viewRadiusKm;   // 畫面可顯示的最大地心距離, 單位為公里
        private readonly Stopwatch _realTimeStopwatch = Stopwatch.StartNew();   // 紀錄實際經過的時間
        private double _lastTickTimeSeconds;    // 上一次計時器更新時的實際時間, 單位為秒
        private const double MaxSimulationStepSeconds = 0.05;   // 每次物理計算允許推進的最大模擬時間, 單位為秒
        private double _nextTrajectorySampleTimeSeconds = OrbitRenderer.TrajectoryIntervalSeconds;  // 下一次應該記錄衛星軌跡的模擬時間
        // 傳送Windows視窗訊息
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        // 傳送指定訊息給視窗
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public MainForm()
        {
            InitializeComponent();

            _simulationTimer.Interval = 16; // 設定模擬計時器
            _simulationTimer.Tick += SimulationTimer_Tick;  // 設定計時器觸發時執行的方法
            ResetSimulation();  // 初始化模擬狀態
        }

        /// <summary>
        /// 開始或繼續衛星軌道模擬
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_simulator.HasImpactedEarth)
            {
                lbSimulationStatus.Text = "衛星已撞擊地球, 請重設模擬";
                return;
            }

            if (_isRunning)
            {
                return;
            }

            _isRunning = true;

            _lastTickTimeSeconds = _realTimeStopwatch.Elapsed.TotalSeconds; // 紀錄開始或繼續執行時的實際時間

            _simulationTimer.Start();

            lbSimulationStatus.Text = "模擬中";
        }

        /// <summary>
        /// 暫停衛星軌道模擬
        /// </summary>
        private void btnPause_Click(object sender, EventArgs e)
        {
            _simulationTimer.Stop();

            _isRunning = false;

            if (_simulator.HasImpactedEarth)
            {
                lbSimulationStatus.Text = "衛星已撞擊地球";
            }
            else
            {
                lbSimulationStatus.Text = "已暫停";
            }
        }

        /// <summary>
        /// 重設衛星軌道模擬
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetSimulation();
        }

        /// <summary>
        /// 將模擬恢復至目前設定的初始狀態
        /// </summary>
        private void ResetSimulation()
        {
            _simulationTimer.Stop();    // 停止計時器

            _isRunning = false;

            // 讀取介面上的初始參數
            OrbitSettings settings = new OrbitSettings
            {
                InitialAltitudeKm = Convert.ToDouble(nudAltitude.Value),
                InitialVelocityKmPerSecond = Convert.ToDouble(nudInitialVelocity.Value),
                InitialAngleDegrees = Convert.ToDouble(nudInitialAngle.Value)
            };

            _simulator.Initialize(settings);    // 重新初始化衛星狀態

            RefreshTelemetry();

            _initiaOrbitRadiusKm = OrbitPhysics.EarthRadiusKm + settings.InitialAltitudeKm; // 計算初始軌道半徑

            _viewRadiusKm = Math.Max(_initiaOrbitRadiusKm * 1.15, OrbitPhysics.EarthRadiusKm * 1.2);    // 設定畫面的顯示範圍

            _orbitRenderer.ResetTrajectory();   // 清除舊軌跡, 並記錄衛星的初始位置

            _nextTrajectorySampleTimeSeconds = OrbitRenderer.TrajectoryIntervalSeconds; // 設定下一次軌跡取樣時間

            _orbitRenderer.AddTrajectoryPoint(_simulator.CurrentState); // 紀錄衛星的初始位置

            picOrbitCanvas.Invalidate();    // 要求畫布重新繪圖

            // 更新介面顯示
            lbSimulationStatus.Text = "尚未開始";
            lbElapsedTimeValue.Text = "00:00:00";
            lbTimeScale.Text = $"時間倍率 : {trkTimeScale.Value}×";
        }

        /// <summary>
        /// 定期更新衛星的模擬狀態
        /// </summary>
        private void SimulationTimer_Tick(object? sender, EventArgs e)
        {
            if (_isRunning == false)
            {
                return;
            }

            double currentTimeSeconds = _realTimeStopwatch.Elapsed.TotalSeconds;    // 取得目前的實際時間

            double elapsedRealSeconds = currentTimeSeconds - _lastTickTimeSeconds;  // 計算距離上一次更新經過了多少實際的時間

            _lastTickTimeSeconds = currentTimeSeconds;

            elapsedRealSeconds = Math.Clamp(elapsedRealSeconds, 0.0, 0.1);  // 避免視窗卡頓後, 一次推進過多模擬時間

            double remainingSimulationSeconds = elapsedRealSeconds * trkTimeScale.Value;    // 根據使用者選擇的倍率, 計算要推進的模擬時間

            // 將模擬時間拆成較小的步長
            while (remainingSimulationSeconds > 1e-9 && _simulator.HasImpactedEarth == false)
            {
                double currentSimulationTime = _simulator.CurrentState.ElapsedTimeSeconds;

                double timeUntilNextSample = _nextTrajectorySampleTimeSeconds - currentSimulationTime;  // 計算距離下一次軌跡取樣還有多少模擬時間

                if (timeUntilNextSample <= 1e-9)
                {
                    _orbitRenderer.AddTrajectoryPoint(_simulator.CurrentState);
                    _nextTrajectorySampleTimeSeconds = OrbitRenderer.TrajectoryIntervalSeconds;
                    continue;
                }

                // 一次更新最多推進MaxSimulationStepSeconds, 同時不能跨過下一個取樣時間
                double stepSeconds = Math.Min(remainingSimulationSeconds, MaxSimulationStepSeconds);

                _simulator.Update(stepSeconds);

                remainingSimulationSeconds = Math.Max(0.0, remainingSimulationSeconds - stepSeconds);

                // 到達取樣時間時, 紀錄該時刻的衛星狀態
                if (_simulator.CurrentState.ElapsedTimeSeconds + 1e-9 >= _nextTrajectorySampleTimeSeconds)
                {
                    _orbitRenderer.AddTrajectoryPoint(_simulator.CurrentState);
                    _nextTrajectorySampleTimeSeconds += OrbitRenderer.TrajectoryIntervalSeconds;
                }
            }

            _orbitRenderer.AddTrajectoryPoint(_simulator.CurrentState); // 紀錄衛星目前的位置

            RefreshTelemetry();

            picOrbitCanvas.Invalidate();    // 要求pictureBox重新繪圖

            lbTimeScale.Text = $"時間倍率 : {trkTimeScale.Value}×";

            TimeSpan elapsedTime = TimeSpan.FromSeconds(_simulator.CurrentState.ElapsedTimeSeconds);    // 經過時間轉換成時分秒

            lbElapsedTimeValue.Text = $"{(int)elapsedTime.TotalHours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}";

            // 判斷衛星是否撞擊地球
            if (_simulator.HasImpactedEarth)
            {
                _simulationTimer.Stop();

                _isRunning = false;

                lbSimulationStatus.Text = "衛星已撞擊地球";
            }
        }

        /// <summary>
        /// 繪製目前的衛星軌道畫面
        /// </summary>
        private void picOrbitCanvas_Paint(object sender, PaintEventArgs e)
        {
            _orbitRenderer.Draw(e.Graphics, picOrbitCanvas.ClientSize, _simulator.CurrentState, _initiaOrbitRadiusKm, _viewRadiusKm, _currentViewMode);
        }

        /// <summary>
        /// 更新右側即時數據面板
        /// </summary>
        private void RefreshTelemetry()
        {
            SatelliteState state = _simulator.CurrentState;

            double distanceKm = OrbitPhysics.GetDistanceFromEarthCenterKm(state);   // 計算衛星與地心的距離

            double altitudeKm = distanceKm - OrbitPhysics.EarthRadiusKm;    // 計算衛星目前的高度

            double speedKmPerSecond = Math.Sqrt(Math.Pow(state.VelocityXKmPerSecond, 2) + Math.Pow(state.VelocityYKmPerSecond, 2)); // 計算衛星目前的速度大小

            // 更新即時數據
            lbCurrentAltitudeValue.Text = $"{altitudeKm:N2} km";
            lbCurrentSpeedValue.Text = $"{speedKmPerSecond:N3} km/s";
            lbCenterDistanceValue.Text = $"{distanceKm:N2} km";

            TimeSpan elapsedTime = TimeSpan.FromSeconds(state.ElapsedTimeSeconds);  // 更新模擬經過時間

            lbElapsedTimeValue.Text = $"{(int)elapsedTime.TotalHours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}";

            // 更新理論圓軌道速度
            double theoreticalSpeed = OrbitPhysics.GetCircularOrbitVelocityKmPerSecond(Convert.ToDouble(nudAltitude.Value));
            lbTheoreticalSpeedValue.Text = $"{theoreticalSpeed:N3} km/s";

            // 更新理論圓軌道週期
            double theoreticalPeriodSeconds = OrbitPhysics.GetCircularOrbitPeriodSeconds(Convert.ToDouble(nudAltitude.Value));
            TimeSpan theoreticalPeriod = TimeSpan.FromSeconds(theoreticalPeriodSeconds);
            lbTheoreticalPeriodValue.Text = $"{(int)theoreticalPeriod.TotalMinutes}分 {theoreticalPeriod.Seconds}秒";
        }

        /// <summary>
        /// 初始高度變更時更新理論軌道數據
        /// </summary>
        private void nudAltitude_ValueChanged(object sender, EventArgs e)
        {
            double altitudeKm = Convert.ToDouble(nudAltitude.Value);

            double theoreticalSpeed = OrbitPhysics.GetCircularOrbitVelocityKmPerSecond(altitudeKm);

            double theoretiaclPeriodSeconds = OrbitPhysics.GetCircularOrbitPeriodSeconds(altitudeKm);

            TimeSpan period = TimeSpan.FromSeconds(theoretiaclPeriodSeconds);

            lbTheoreticalSpeedValue.Text = $"{theoreticalSpeed:N3} km/s";
            lbTheoreticalPeriodValue.Text = $"{(int)period.TotalMinutes}分 {period.Seconds}秒";
        }

        private void trkTimeScale_ValueChanged(object sender, EventArgs e)
        {
            lbTimeScale.Text = $"時間倍率 : {trkTimeScale.Value}×";
        }

        /// <summary>
        /// 切換至太空風格視圖
        /// </summary>
        private void btnSpaceView_Click(object sender, EventArgs e)
        {
            _currentViewMode = OrbitViewMode.Space;

            lbCurrentView.Text = "目前視圖 : 太空視圖";

            UpdateViewButtons();

            picOrbitCanvas.Invalidate();
        }

        /// <summary>
        /// 切換至科學座標圖視圖
        /// </summary>
        private void btnCoordinateView_Click(object sender, EventArgs e)
        {
            _currentViewMode = OrbitViewMode.Coordinate;

            lbCurrentView.Text = "目前視圖 : 座標圖";

            UpdateViewButtons();

            picOrbitCanvas.Invalidate();
        }

        /// <summary>
        /// 更新視圖切換按鈕的選取外觀
        /// </summary>
        private void UpdateViewButtons()
        {
            Color selectedBackColor = Color.FromArgb(86, 217, 245);
            Color normalBackColor = Color.FromArgb(24, 40, 58);

            Color selectedForeColor = Color.FromArgb(8, 20, 33);
            Color normalForeColor = Color.FromArgb(230, 241, 255);

            bool isSpaceView = _currentViewMode == OrbitViewMode.Space;

            btnSpaceView.BackColor = isSpaceView ? selectedBackColor : normalBackColor;
            btnSpaceView.ForeColor = isSpaceView ? selectedForeColor : normalForeColor;

            btnCoordinateView.BackColor = isSpaceView ? normalBackColor : selectedBackColor;
            btnCoordinateView.ForeColor = isSpaceView ? normalForeColor : selectedForeColor;
        }

        /// <summary>
        /// 將主視窗最小化
        /// </summary>
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 切換主視窗的最大化與還原狀態
        /// </summary>
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        /// <summary>
        /// 關閉主視窗
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 執行自訂標題列的拖曳操作
        /// </summary>
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            // 最大化時不執行拖移, 避免視窗移動異常
            if (WindowState == FormWindowState.Maximized)
            {
                return;
            }

            ReleaseCapture();

            SendMessage(Handle, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero);
        }

        /// <summary>
        /// 當中央軌道畫布尺寸改變時, 重新繪製模擬畫面
        /// </summary>
        private void picOrbitCanvas_Resize(object sender, EventArgs e)
        {
            picOrbitCanvas.Invalidate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.CodeDom;

namespace SatelliteOrbitSimulator
{
    /// <summary>
    /// 軌道模擬的顯示模式
    /// </summary>
    public enum OrbitViewMode
    {
        Space,  // 太空風格視圖
        Coordinate  // 科學座標圖視圖
    }
    /// <summary>
    /// 負責在繪圖畫布上呈現地球, 軌道與衛星
    /// </summary>
    public class OrbitRenderer
    {
        private readonly List<PointF> _trajectory = new List<PointF>(); // 儲存衛星經過的位置, 座標單位為公里
        private const int MaxTrajectoryPoints = 3000;   // 軌跡最多保留的點數
        public const double TrajectoryIntervalSeconds = 0.1;   // 軌跡紀錄的模擬時間間隔, 單位為秒
        private double _lastTrajectoryTimeSeconds = double.NegativeInfinity;    // 上一次記錄軌跡時的模擬時間
        
        // 清除先前的軌跡
        public void ResetTrajectory()
        {
            _trajectory.Clear();

            _lastTrajectoryTimeSeconds = double.NegativeInfinity;
        }

        /// <summary>
        /// 將衛星目前的位置加入軌跡
        /// </summary>
        public void AddTrajectoryPoint(SatelliteState state)
        {
            if(state == null)
            {
                return;
            }

            if(_trajectory.Count == 0)
            {
                _trajectory.Add(new PointF(
                                (float)state.PositionXKm,
                                (float)state.PositionYKm
                                ));
                _lastTrajectoryTimeSeconds = state.ElapsedTimeSeconds;

                return;
            }
            
            if(state.ElapsedTimeSeconds - _lastTrajectoryTimeSeconds < TrajectoryIntervalSeconds - 1e-9)
            {
                return;
            }

            _trajectory.Add(new PointF(
                                (float)state.PositionXKm,
                                (float)state.PositionYKm
                                ));
            _lastTrajectoryTimeSeconds = state.ElapsedTimeSeconds;

            if (_trajectory.Count > MaxTrajectoryPoints)
            {
                _trajectory.RemoveAt(0);
            }
        }

        /// <summary>
        /// 根據指定的視圖模式繪製衛星軌道
        /// </summary>
        /// <param name="graphics">負責繪圖的Graphics物件</param>
        /// <param name="canvasSize">繪圖畫布大小</param>
        /// <param name="state">衛星目前的狀態</param>
        /// <param name="initiaOrbitRadiusKm">初始軌道半徑, 單位為公里</param>
        /// <param name="viewRadiusKm">畫面顯示範圍的半徑, 單位為公里</param>
        /// <param name="viewMode">目前使用的顯示模式</param>
        public void Draw(Graphics graphics, Size canvasSize, SatelliteState state, double initiaOrbitRadiusKm, double viewRadiusKm, OrbitViewMode viewMode)
        {
            if(graphics == null || state == null || canvasSize.Width <= 0 || canvasSize.Height <= 0)
            {
                return;
            }

            if(viewMode == OrbitViewMode.Coordinate)
            {
                DrawCoordinateView(graphics, canvasSize, state, viewRadiusKm);
                return;
            }

            DrawSpaceView(graphics, canvasSize, state, initiaOrbitRadiusKm, viewRadiusKm);
        }

        /// <summary>
        /// 繪製背景網格與座標軸
        /// </summary>
        private static void DrawGrid(Graphics graphics, Size canvasSize, float centerX, float centerY)
        {
            using (Pen gridPen = new Pen(Color.FromArgb(22, 158, 180, 201), 1.0f))
            {
                const int gridSpacing = 40;

                for(int x = 0; x < canvasSize.Width; x += gridSpacing)
                {
                    graphics.DrawLine(gridPen, x, 0, x, canvasSize.Height);
                }

                for(int y = 0; y < canvasSize.Height; y += gridSpacing)
                {
                    graphics.DrawLine(gridPen, 0, y, canvasSize.Width, y);
                }
            }

            using (Pen axisPen = new Pen(Color.FromArgb(55, 158, 180, 201), 1.0f))
            {
                graphics.DrawLine(axisPen, 0, centerY, canvasSize.Width, centerY);
                graphics.DrawLine(axisPen, centerX, 0, centerX, canvasSize.Height);
            }
        }

        /// <summary>
        /// 繪製簡化地球
        /// </summary>
        private static void DrawEarth(Graphics graphics, float centerX, float centerY, float radius)
        {
            if(radius <= 0)
            {
                return;
            }

            RectangleF earthBounds = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);

            // 地球外圍光暈
            using (Pen glowPen = new Pen(Color.FromArgb(45, 86, 217, 245), 8.0f))
            {
                graphics.DrawEllipse(glowPen, earthBounds.X - 3, earthBounds.Y - 3, earthBounds.Width + 6, earthBounds.Height + 6);
            }

            // 地球本體
            using (SolidBrush earthBrush = new SolidBrush(Color.FromArgb(24, 76, 125)))
            {
                graphics.FillEllipse(earthBrush, earthBounds);
            }

            // 地球外框
            using (Pen outlinePen = new Pen(Color.FromArgb(86, 217, 245), 1.5f))
            {
                graphics.DrawEllipse(outlinePen, earthBounds);
            }

            // 簡化的地表線條, 僅作視覺示意
            using (Pen surfacePen = new Pen(Color.FromArgb(90, 86, 217, 180), 2.0f))
            {
                RectangleF upperCurve = new RectangleF(centerX - radius * 0.65f, centerY - radius * 0.45f, radius * 1.2f, radius * 0.7f);

                graphics.DrawArc(surfacePen, upperCurve, 200, 140);

                RectangleF lowerCurve = new RectangleF(centerX - radius * 0.7f, centerY - radius * 0.05f, radius * 1.25f, radius * 0.7f);

                graphics.DrawArc(surfacePen, lowerCurve, 20, 140);
            }
        }

        /// <summary>
        /// 繪製衛星經過的軌跡
        /// </summary>
        private void DrawTrajectory(Graphics graphics, float centerX, float centerY, float scale)
        {
            if(_trajectory.Count < 2)
            {
                return;
            }
            using (Pen trajectoryPen = new Pen(Color.FromArgb(220, 86, 217, 245), 2.0f))
            {
                PointF previousPoint = new PointF(
                    centerX + _trajectory[0].X * scale,
                    centerY - _trajectory[0].Y * scale
                    );

                for(int i = 1; i < _trajectory.Count; i++)
                {
                    PointF currentPoint = new PointF(
                        centerX + _trajectory[i].X * scale,
                        centerY - _trajectory[i].Y * scale
                        );
                    graphics.DrawLine(trajectoryPen, previousPoint, currentPoint);

                    previousPoint = currentPoint;
                }
            }
        }

        /// <summary>
        /// 繪製衛星圖示
        /// </summary>
        private static void DrawSatellite(Graphics graphics, float x, float y)
        {
            const float satelliteSize = 7.0f;

            // 外圍光暈
            using (SolidBrush glowBrush = new SolidBrush(Color.FromArgb(45, 86, 217, 245)))
            {
                graphics.FillEllipse(glowBrush, x - 12, y - 12, 24, 24);
            }

            // 衛星主題
            using (SolidBrush satelliteBrush = new SolidBrush(Color.FromArgb(230, 245, 255)))
            {
                graphics.FillEllipse(satelliteBrush, x - satelliteSize, y - satelliteSize, satelliteSize * 2, satelliteSize * 2);
            }

            // 衛星外框
            using (Pen outlinePen = new Pen(Color.FromArgb(86, 217, 245), 1.5f))
            {
                graphics.DrawEllipse(outlinePen, x - satelliteSize, y - satelliteSize, satelliteSize * 2, satelliteSize * 2);
            }
        }

        /// <summary>
        /// 繪製太空風格視圖
        /// </summary>
        private void DrawSpaceView(Graphics graphics, Size canvasSize, SatelliteState state, double initiaOrbitRadiusKm, double viewRadiusKm)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.FromArgb(8, 20, 33));

            float centerX = canvasSize.Width / 2.0f;
            float centerY = canvasSize.Height / 2.0f;

            // 保留畫布邊緣空間
            double availableRadius = Math.Min(canvasSize.Width, canvasSize.Height) * 0.44;
            double safeViewRadius = Math.Max(viewRadiusKm, 1.0);

            float scale = (float)(availableRadius / safeViewRadius);

            DrawGrid(graphics, canvasSize, centerX, centerY);   // 繪製網格

            float earthRadiusPixels = (float)(OrbitPhysics.EarthRadiusKm * scale);

            DrawEarth(graphics, centerX, centerY, earthRadiusPixels);   // 繪製地球

            // 繪製初始軌道參考圓
            float orbitRadiusPixels = (float)(initiaOrbitRadiusKm * scale);

            using (Pen orbitPen = new Pen(Color.FromArgb(90, 86, 217, 245), 1.5f))
            {
                orbitPen.DashStyle = DashStyle.Dash;

                graphics.DrawEllipse(orbitPen, centerX - orbitRadiusPixels, centerY - orbitRadiusPixels, orbitRadiusPixels * 2, orbitRadiusPixels * 2);
            }

            DrawTrajectory(graphics, centerX, centerY, scale);  // 繪製軌道的歷史軌跡

            float satelliteX = centerX + (float)(state.PositionXKm * scale);    // 將衛星的物理座標轉換成畫面座標
            float satelliteY = centerY - (float)(state.PositionYKm * scale);    // 畫面Y軸向下, 與數學坐標系相反

            DrawSatellite(graphics, satelliteX, satelliteY);

            // 標記地心
            using (Pen centerPen = new Pen(Color.FromArgb(130, 158, 180, 201), 1.0f))
            {
                graphics.DrawLine(centerPen, centerX - 7, centerY, centerX + 7, centerY);

                graphics.DrawLine(centerPen, centerX, centerY - 7, centerX, centerY + 7);
            }
        }

        /// <summary>
        /// 繪製科學座標圖視圖
        /// </summary>
        private void DrawCoordinateView(Graphics graphics, Size canvasSize, SatelliteState state, double viewRadiusKm)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.FromArgb(11, 18, 32));

            // 保留座標刻度與標籤的空間
            const float leftMargin = 65.0f;
            const float rightMargin = 20.0f;
            const float topMargin = 30.0f;
            const float bottomMargin = 35.0f;

            double availableWidth = Math.Max(1.0, canvasSize.Width - leftMargin - rightMargin);
            double availableHeight = Math.Max(1.0, canvasSize.Height - topMargin - bottomMargin);

            float centerX = leftMargin + (float)(availableWidth / 2.0);
            float centerY = topMargin + (float)(availableHeight / 2.0);

            double availableRadius = Math.Min(availableWidth, availableHeight) / 2.0;

            double safeViewRadius = Math.Max(viewRadiusKm, 1.0);

            float scale = (float)(availableRadius / safeViewRadius);

            // 計算座標網格間隔, 讓刻度隨顯示範圍調整
            double gridIntervalKm = GetCoordinateGridInterval(viewRadiusKm);

            DrawCoordinateGrid(graphics, canvasSize, centerX, centerY, scale, gridIntervalKm, viewRadiusKm);

            // 繪製地球, 地球中心位於座標原點
            float earthRadiusPixels = (float)(OrbitPhysics.EarthRadiusKm * scale);
            DrawEarth(graphics, centerX, centerY, earthRadiusPixels);

            DrawTrajectory(graphics, centerX, centerY, scale);  // 繪製衛星歷史軌跡

            // 繪製目前的衛星位置
            float satelliteX = centerX + (float)(state.PositionXKm * scale);
            float satelliteY = centerY - (float)(state.PositionYKm * scale);

            DrawSatellite(graphics, satelliteX, satelliteY);

            // 顯示衛星目前的X, Y座標
            using (Font infoFont = new Font("Segoe UI", 10.0f, FontStyle.Regular))
            using (SolidBrush infoBrush = new SolidBrush(Color.FromArgb(230, 241, 255)))
            {
                string coordinateText = $"X : {state.PositionXKm:N1} km\r\nY : {state.PositionYKm:N1} km";
                graphics.DrawString(coordinateText, infoFont, infoBrush, 14, 14);
            }
        }

        /// <summary>
        /// 根據畫面顯示範圍, 計算合適的座標網格間隔
        /// </summary>
        /// <param name="viewRadiusKm">畫面顯示範圍半徑, 單位為公里</param>
        /// <returns>座標網格間隔, 單位為公里</returns>
        private static double GetCoordinateGridInterval(double viewRadiusKm)
        {
            double targetInterval = Math.Max(viewRadiusKm / 4.0, 1.0);

            double magnitude = Math.Pow(10.0, Math.Floor(Math.Log10(targetInterval)));

            double normalizedInterval = targetInterval / magnitude;

            double niceInterval;

            if(normalizedInterval <= 1.0)
            {
                niceInterval = 1.0;
            }
            else if(normalizedInterval <= 2.0)
            {
                niceInterval = 2.0;
            }
            else if(normalizedInterval <= 5.0)
            {
                niceInterval = 5.0;
            }
            else
            {
                niceInterval = 10.0;
            }

            return niceInterval * magnitude;
        }

        /// <summary>
        /// 繪製科學座標圖的網格, 座標軸及刻度標籤
        /// </summary>
        private static void DrawCoordinateGrid(Graphics graphics, Size canvasSize, float centerX, float centerY, float scale, double gridIntervalKm, double viewRadiusKm)
        {
            if(scale <= 0 || gridIntervalKm <= 0)
            {
                return;
            }

            using (Pen gridPen = new Pen(Color.FromArgb(35, 158, 180, 201), 1.0f))
            using (Pen axisPen = new Pen(Color.FromArgb(150, 86, 217, 245), 1.2f))
            using (Pen tickPen = new Pen(Color.FromArgb(130, 158, 180, 201), 1.0f))
            using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(180, 158, 180, 201)))
            using (Font labelFont = new Font("Segoe UI", 8.0f, FontStyle.Regular))
            {
                // 計算畫布可顯示的座標範圍
                double halfWidthKm = canvasSize.Width / (2.0 * scale);
                double halfHeightKm = canvasSize.Height / (2.0 * scale);

                double maxXKm = Math.Max(halfWidthKm, viewRadiusKm);
                double maxYKm = Math.Max(halfHeightKm, viewRadiusKm);

                // 繪製垂直網格線及X座標刻度
                double firstX = Math.Ceiling(-maxXKm / gridIntervalKm) * gridIntervalKm;

                for(double xKm = firstX; xKm <= maxXKm; xKm += gridIntervalKm)
                {
                    float screenX = centerX + (float)(xKm * scale);

                    if(screenX < 0 || screenX > canvasSize.Width)
                    {
                        continue;
                    }

                    graphics.DrawLine(gridPen, screenX, 0, screenX, canvasSize.Height);

                    if(Math.Abs(xKm) > 0.001)
                    {
                        graphics.DrawLine(tickPen, screenX, centerY - 5, screenX, centerY + 5);
                        graphics.DrawString(xKm.ToString("#,##0"), labelFont, textBrush, screenX + 3, centerY + 10);
                    }
                }

                // 繪製水平網格線及Y座標刻度
                double firstY = Math.Ceiling(-maxYKm / gridIntervalKm) * gridIntervalKm;

                for(double yKm = firstY; yKm < maxYKm; yKm += gridIntervalKm)
                {
                    float screenY = centerY - (float)(yKm * scale);

                    if(screenY < 0 || screenY > canvasSize.Height)
                    {
                        continue;
                    }

                    graphics.DrawLine(gridPen, 0, screenY, canvasSize.Width, screenY);

                    if(Math.Abs(yKm) > 0.001)
                    {
                        graphics.DrawLine(tickPen, centerX - 4, screenY, centerX + 4, screenY);
                        graphics.DrawString(yKm.ToString("#,##0"), labelFont, textBrush, centerX + 6, screenY + 2);
                    }
                }

                // 繪製主要座標軸
                graphics.DrawLine(axisPen, 0, centerY, canvasSize.Width, centerY);
                graphics.DrawLine(axisPen, centerX, 0, centerX, canvasSize.Height);

                // 標示座標軸名稱
                graphics.DrawString("X (km)", labelFont, textBrush, canvasSize.Width - 55, centerY - 22);
                graphics.DrawString("Y (km)", labelFont, textBrush, centerX + 8, 4);

                // 標示座標原點
                graphics.DrawString("O", labelFont, textBrush, centerX + 6, centerY + 6);
            }
        }
    }
}

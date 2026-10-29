using System;
using System.Collections.Generic;
using System.Text;

namespace SatelliteOrbitSimulator
{
    /// <summary>
    /// 負責模擬衛星在地球重力作用下的運動, 使用四階 Runge-Kutta（RK4）方法計算衛星狀態
    /// </summary>
    public class OrbitSimulator
    {
        public SatelliteState CurrentState { get; private set; } = new SatelliteState();    // 衛星目前的即時狀態
        public bool HasImpactedEarth { get; private set; }  // 判斷衛星是否已經撞擊地球

        // 儲存位置與速度的變化率
        private struct Derivative
        {
            public double Dx;
            public double Dy;
            public double DVx;
            public double DVy;
        }

        /// <summary>
        /// 根據初始設定初始化衛星的位置與速度
        /// </summary>
        /// <param name="settings">衛星的初始軌道設定</param>
        public void Initialize(OrbitSettings settings)
        {
            if(settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if(double.IsFinite(settings.InitialAltitudeKm) == false || settings.InitialAltitudeKm < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(settings.InitialAltitudeKm), "初始高度必須是大於或等於0的有限數值");
            }

            if(double.IsFinite(settings.InitialVelocityKmPerSecond) == false || settings.InitialVelocityKmPerSecond < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(settings.InitialVelocityKmPerSecond), "初始速度必須是大於或等於0的有限數值");
            }

            if(double.IsFinite(settings.InitialAngleDegrees) == false)
            {
                throw new ArgumentOutOfRangeException(nameof(settings.InitialAngleDegrees), "初始角度必須是有限數值");
            }

            double radiusKm = OrbitPhysics.EarthRadiusKm + settings.InitialAltitudeKm;  // 計算衛星距離地心的初始距離
            double angleRadians = settings.InitialAngleDegrees * Math.PI / 180.0;   // 將角度由度數轉換為弧度

            // 計算衛星的初始位置
            double x = radiusKm * Math.Cos(angleRadians);
            double y = radiusKm * Math.Sin(angleRadians);

            double speed = settings.InitialVelocityKmPerSecond; // 初始速度設定為切線方向

            double vx = -speed * Math.Sin(angleRadians);
            double vy = speed * Math.Cos(angleRadians);

            CurrentState = new SatelliteState
            {
                PositionXKm = x,
                PositionYKm = y,
                VelocityXKmPerSecond = vx,
                VelocityYKmPerSecond = vy,
                ElapsedTimeSeconds = 0.0

            };

            HasImpactedEarth = false;
        }

        /// <summary>
        /// 將模擬時間向前推進指定秒數
        /// </summary>
        /// <param name="deltaTimeSeconds">本次推進的模擬時間, 單位為秒</param>
        public void Update(double deltaTimeSeconds)
        {
            if(double.IsFinite(deltaTimeSeconds) == false || deltaTimeSeconds <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deltaTimeSeconds), "模擬時間必須是大於0的有限數值");
            }

            if(HasImpactedEarth)
            {
                return;
            }

            double x = CurrentState.PositionXKm;
            double y = CurrentState.PositionYKm;
            double vx = CurrentState.VelocityXKmPerSecond;
            double vy = CurrentState.VelocityYKmPerSecond;

            // RK4計算四個階段的狀態變化率
            Derivative k1 = CalculateDerivative(x, y, vx, vy);
            Derivative k2 = CalculateDerivative(x + k1.Dx * deltaTimeSeconds / 2.0, y + k1.Dy * deltaTimeSeconds / 2.0
                , vx + k1.DVx * deltaTimeSeconds / 2.0, vy + k1.DVy * deltaTimeSeconds / 2.0);
            Derivative k3 = CalculateDerivative(x + k2.Dx * deltaTimeSeconds / 2.0, y + k2.Dy * deltaTimeSeconds / 2.0
                , vx + k2.DVx * deltaTimeSeconds / 2.0, vy + k2.DVy * deltaTimeSeconds / 2.0);
            Derivative k4 = CalculateDerivative(x + k3.Dx * deltaTimeSeconds, y + k3.Dy * deltaTimeSeconds
                , vx + k3.DVx * deltaTimeSeconds, vy + k3.DVy * deltaTimeSeconds);

            // 加權平均四個階段的變化量, 更新衛星狀態
            CurrentState.PositionXKm = x + deltaTimeSeconds / 6.0 * (k1.Dx + 2.0 * k2.Dx + 2.0 * k3.Dx + k4.Dx);
            CurrentState.PositionYKm = y + deltaTimeSeconds / 6.0 * (k1.Dy + 2.0 * k2.Dy + 2.0 * k3.Dy + k4.Dy);
            CurrentState.VelocityXKmPerSecond = vx + deltaTimeSeconds / 6.0 * (k1.DVx + 2.0 * k2.DVx + 2.0 * k3.DVx + k4.DVx);
            CurrentState.VelocityYKmPerSecond = vy + deltaTimeSeconds / 6.0 * (k1.DVy + 2.0 * k2.DVy + 2.0 * k3.DVy + k4.DVy);

            CurrentState.ElapsedTimeSeconds += deltaTimeSeconds;

            // 判斷衛星是否已經到達或進入地球內部
            double distanceKm = OrbitPhysics.GetDistanceFromEarthCenterKm(CurrentState);

            if(distanceKm <= OrbitPhysics.EarthRadiusKm)
            {
                HasImpactedEarth = true;
            }
        }

        /// <summary>
        /// 根據目前的位置與速度計算各項狀態的變化率
        /// </summary>
        private static Derivative CalculateDerivative(double x, double y, double vx, double vy)
        {
            double radiusSquared = x * x + y * y;
            double radius = Math.Sqrt(radiusSquared);

            if(radius == 0.0)
            {
                throw new InvalidOperationException("衛星位置不能位於地球中心");
            }

            // 牛頓萬有引力所產生的重力加速度
            double accelerationFactor = -OrbitPhysics.EarthGravitationalParameter / (radiusSquared * radius);

            double ax = accelerationFactor * x;
            double ay = accelerationFactor * y;

            return new Derivative
            { Dx = vx, Dy = vy, DVx = ax, DVy = ay };
        }
    }
}

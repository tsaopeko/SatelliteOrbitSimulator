using System;
using System.Collections.Generic;
using System.Text;

namespace SatelliteOrbitSimulator
{
    /// <summary>
    /// 表示軌道設定的組態資訊。
    /// </summary>
    public class OrbitSettings
    {
        public double InitialAltitudeKm { get; set; } = 400.0;   // 衛星距離地球表面的初始高度, 單位為公里
        public double InitialVelocityKmPerSecond { get; set; } = 7.67;  // 衛星的初始速度大小, 單位為公里每秒
        public double InitialAngleDegrees { get; set; } = 0.0;  // 衛星的初始位置角度, 單位為度
    }
}

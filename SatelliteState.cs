using System;
using System.Collections.Generic;
using System.Text;

namespace SatelliteOrbitSimulator
{
    /// <summary>
    /// 儲存衛星在軌道模擬過程中的即時狀態
    /// </summary>
    public class SatelliteState
    {
        // 座標原點位於地球中心
        public double PositionXKm { get; set; } // 衛星目前的X座標, 單位為公里
        public double PositionYKm { get; set; } // 衛星目前的Y座標, 單位為公里
        public double VelocityXKmPerSecond { get; set; }    // 衛星目前在X方向的速度, 單位為公里每秒
        public double VelocityYKmPerSecond { get; set; }    // 衛星目前在Y方向的速度, 單位為公里每秒
        public double ElapsedTimeSeconds { get; set; }  // 模擬開始後經過的時間, 單位為秒
    }
}

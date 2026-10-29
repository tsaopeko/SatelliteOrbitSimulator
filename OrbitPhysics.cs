using System;
using System.Collections.Generic;
using System.Text;

namespace SatelliteOrbitSimulator
{
    /// <summary>
    /// 提供衛星軌道相關的物理計算
    /// </summary>
    public static class OrbitPhysics
    {
        public const double EarthRadiusKm = 6371.0; // 地球平均半徑, 單位為公里
        public const double EarthGravitationalParameter = 398600.4418;  // 地球標準重力參數, 單位為立方公里每平方秒

        /// <summary>
        /// 計算衛星距離地心的距離
        /// </summary>
        /// <param name="state">衛星目前的狀態</param>
        /// <returns>衛星距離地心的距離, 單位為公里</returns>
        public static double GetDistanceFromEarthCenterKm(SatelliteState state)
        {
            if(state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            return Math.Sqrt(Math.Pow(state.PositionXKm, 2) + Math.Pow(state.PositionYKm, 2));
        }

        /// <summary>
        /// 根據衛星高度計算圓軌道理論速度
        /// </summary>
        /// <param name="altitudeKm">衛星距離地表的高度, 單位為公里</param>
        /// <returns>圓軌道理論速度, 單位為公里每秒</returns>
        public static double GetCircularOrbitVelocityKmPerSecond(double altitudeKm)
        {
            if(double.IsFinite(altitudeKm) == false || altitudeKm < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(altitudeKm), "衛星高度必須是大於或等於0的有限數值");
            }

            double radiusKm = EarthRadiusKm + altitudeKm;

            return Math.Sqrt(EarthGravitationalParameter / radiusKm);
        }

        /// <summary>
        /// 根據衛星高度計算圓軌道理論週期
        /// </summary>
        /// <param name="altitudeKm">衛星距離地表的高度, 單位為公里</param>
        /// <returns>圓軌道理論週期, 單位為秒</returns>
        public static double GetCircularOrbitPeriodSeconds(double altitudeKm)
        {
            if(double.IsFinite(altitudeKm) == false || altitudeKm < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(altitudeKm), "衛星高度必須是大於或等於0的有限數值");
            }

            double radiusKm = EarthRadiusKm + altitudeKm;

            return 2.0 * Math.PI * Math.Sqrt(Math.Pow(radiusKm, 3) / EarthGravitationalParameter);
        }
    }
}

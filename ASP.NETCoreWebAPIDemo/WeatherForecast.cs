using System;

namespace ASP.NETCoreWebAPIDemo
{
    /// <summary>
    /// 天气预报
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// 日期时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 温度
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// 温度F
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// 概要
        /// </summary>
        public string Summary { get; set; }
    }
}

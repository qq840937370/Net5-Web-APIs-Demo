using System;

namespace ASP.NETCoreWebAPIDemo
{
    /// <summary>
    /// ����Ԥ��
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// �¶�
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// �¶�F
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// ��Ҫ
        /// </summary>
        public string Summary { get; set; }
    }
}

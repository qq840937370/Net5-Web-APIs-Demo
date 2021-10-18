using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreWebAPI.Controllers
{
    /// <summary>
    /// 天气预报API类
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// 摘要
        /// </summary>
        private static readonly string[] Summaries = new[]
        {
            "极冷", "寒冷", "冷", "有点冷", "适宜", "有点热", "热", "炎热", "酷热"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// 天气预报API
        /// </summary>
        /// <param name="logger"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get示例-天气状况
        /// curl -X GET "https://localhost:44344/WeatherForecast" -H  "accept: application/json"
        /// https://localhost:44344/WeatherForecast
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),  // 日期
                TemperatureC = rng.Next(-20, 55),    // 温度
                Summary = Summaries[rng.Next(Summaries.Length)]  // 天气
            })
            .ToArray();
        }

        /// <summary>
        /// Post示例
        /// curl -X POST "https://localhost:44344/WeatherForecast" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"date\":\"2021-10-18T07:25:56.203Z\",\"temperatureC\":4,\"summary\":\"string\"}"
        /// curl -X POST "https://localhost:44344/WeatherForecast" -H  "accept: */*" -H  "Content-Type: text/json" -d "{\"date\":\"2021-10-18T07:25:56.203Z\",\"temperatureC\":4,\"summary\":\"string\"}"
        /// https://localhost:44344/WeatherForecast
        /// </summary>
        /// <param name="weatherForecast"></param>
        [HttpPost]
        public void Post([FromBody]WeatherForecast weatherForecast)
        {

        }

        /// <summary>
        /// put示例
        /// curl -X PUT "https://localhost:44344/WeatherForecast/id?id=3" -H  "accept: */*" -H  "Content-Type: text/json" -d "{\"date\":\"2021-10-18T07:33:23.378Z\",\"temperatureC\":0,\"summary\":\"string\"}"
        /// https://localhost:44344/WeatherForecast/id?id=3
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("id")]
        public void Put(int id,[FromBody] WeatherForecast value)
        {

        }

        /// <summary>
        /// Delete示例
        /// curl -X DELETE "https://localhost:44344/WeatherForecast/41" -H  "accept: */*"
        /// https://localhost:44344/WeatherForecast/41
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }

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

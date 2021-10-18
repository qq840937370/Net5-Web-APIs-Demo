using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreWebAPI.Controllers
{
    /// <summary>
    /// 第一个案例
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesTestController : ControllerBase
    {
        /// <summary>
        /// 获取文本
        /// https://localhost:44344/api/ValuesTest/Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello World!这是Get方法测试";
        }

        /// <summary>
        /// 两数相加
        /// http://localhost:30202/api/ValuesTest/Sum?num1=1&num2=3
        /// </summary>
        /// <param name="num1">第一个数</param>
        /// <param name="num2">第二个数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<int> Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        /// <summary>
        /// 两数相减
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<int> Subtract(Param param)
        {
            int result = param.num1 - param.num2;
            return result;
        }
    }

    /// <summary>
    /// 参数
    /// </summary>
    public class Param
    {
        /// <summary>
        /// 第一个数
        /// </summary>
        public int num1 { get; set; }
        /// <summary>
        /// 第二个数
        /// </summary>
        public int num2 { get; set; }
    }
}

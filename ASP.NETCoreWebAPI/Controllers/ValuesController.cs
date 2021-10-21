/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：WebAPI Demo
*│  Get     ：只是用来查询一下数据，不会修改、增加数据，不会影响资源的内容。
*│  Post    ：该请求会改变数据的种类等资源，就像数据库的insert操作一样。几乎目前所有的提交操作都是用POST请求的。
*│  Put     ：该请求就像数据库的update操作一样，用来修改数据的内容，但是不会增加数据的种类等
*│  Delete  ：用来删除某一个资源的，该请求就像数据库的delete操作。
*│　作    者：执笔小白                                              
*│　版    本：1.0                                       
*│　创建时间：2021-10-20 15:40:56                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: ASP.NETCoreWebAPI.Controllers                             
*│　类    名：ValuesTestController                                     
*└──────────────────────────────────────────────────────────────┘
*/
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
        /// http://localhost:30202/api/ValuesTest/Subtract
        /// { "num1": 4,  "num2": 3}
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<int> Subtract(Param param)
        {
            int result = param.num1 - param.num2;
            return result;
        }

        /// <summary>
        /// id*(p.num1*p.num2)
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<string> PutUser(int id, Param param)
        {
            int result = id * (param.num1 + param.num2);
            return result.ToString();
        }

        /// <summary>
        /// id*(p.num1-p.num2)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<string> DeleteUser(int id, Param param)
        {
            int result = id * (param.num1 - param.num2);
            return result.ToString();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod(Description = "欢迎界面")]
        public string HelloWorld()
        {
            return "Hello World！我是执笔小白";
        }

        [WebMethod(Description = "求和方法")]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [WebMethod(Description = "求差方法")]
        public int Sub(Tc1 tc1)
        {
            return tc1.num1 - tc1.num2;
        }

    }

    public class Tc1
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

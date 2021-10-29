using System;
using System.Collections.Generic;
using System.Data;
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
        // 无参
        [WebMethod(Description = "欢迎界面")]
        public string HelloWorld()
        {
            return "Hello World！我是执笔小白";
        }

        // 多参数
        [WebMethod(Description = "求和方法")]
        public int Add(int a, int b)
        {
            return a + b;
        }

        // 参数是实体类-要使用http协议请把参数和返回值都设置成int或string等常见类型，多参数用字节流实现。
        [WebMethod(Description = "求差方法")]
        public int Sub(Tc1 tc1)
        {
            return tc1.num1 - tc1.num2;
        }

        // 参数DataSet、返回结果参数DataSet(WebService不能返回DataTable)
        [WebMethod(Description = "DataSet测试")]
        public DataSetTB1 DataSetTest(DataSetTB1 tc1)
        {
            DataSetTB1 dsTB1 = new DataSetTB1();

            dsTB1 = tc1;

            foreach(DataRow dr in dsTB1.DTTest1.Rows)  // 把每条学生的数据都改成一班
            {
                dr["Class"] = "一班"; 
            }
            return dsTB1;
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

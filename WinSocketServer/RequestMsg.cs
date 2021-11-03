using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSocketServer
{
   public class RequestMsg
    {
        /// <summary>
        /// 以dictionary将数据的键值对匹配
        /// </summary>
        /// <param name="valueA">a的值</param>
        /// <param name="valueB">b的值</param>
        /// <returns></returns>
        public static string SerializeJson(string valueA, string valueB)
        {
            if (valueA.Length == 0) { valueA = "-"; }
            if (valueB.Length == 0) { valueB = "-"; }
            //以dictionary将数据的键值对匹配，然后json序列化
            Dictionary<string, string> dic = new Dictionary<string, string>(){
                { "a",valueA },
                { "b",valueB }
            };
            string Jsondata = JsonConvert.SerializeObject(dic);
            return Jsondata;
        }
    }

    //用于json反序列化获取实体
    public class TestValue
    {
        public string a { get; set; }
        public string b { get; set; }
    }
}

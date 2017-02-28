using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public   class SerializeHelper
    {
        /// <summary>
        /// 对数据进行序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeToString(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
        /// <summary>
        /// 反序列化操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeserializeToObject<T>(string str)
        {
          
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace ProxyPool
{
     public  class Pool
    {
        /// <summary>
        /// 获取一个随机代理
        /// </summary>
        /// <returns>代理</returns>
         public static Proxy GetProxy()
         {
             Proxy proxy=new Proxy();
             try
             {
                 using (RedisClient client = new RedisClient("127.0.0.1", 6379))
                 {
                     string temp = Encoding.UTF8.GetString(client.LPop("ProxyPool"));
                     int index = temp.IndexOf(",");
                     if (index > 0)
                     {
                         proxy.Adress = temp.Substring(0, index);
                         proxy.port = int.Parse(temp.Substring(index + 1, temp.Length - index - 1));
                     }
                 }
             }
             catch { 
             }
             return proxy;
         }
        /// <summary>
        /// 根据代理值删除代理
        /// </summary>
        /// <param name="proxy">代理</param>
         public static void  PushProxy(Proxy proxy)
         {
             using (RedisClient client = new RedisClient("127.0.0.1", 6379))
              {
                  client.RPush("ProxyPool", Encoding.UTF8.GetBytes(proxy.Adress + "," + proxy.port.ToString()));
              }
         }
    }
}

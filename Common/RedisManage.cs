using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public  class RedisManage
    {
        public static void AddUrltoken(string urltoken)
        {
            int type = Math.Abs(urltoken.GetHashCode()) % 3 + 3;
            if (RedisCore.InsetIntoHash( "urltokenhash", urltoken, "存在"))
            {
                RedisCore.PushIntoList( "urltoken", urltoken);

            }
        }
        public static string GetUrltoken()
        {
            return RedisCore.PopFromList( "urltoken");
        }
        public static void AddNextUrl(string next)
        {
            RedisCore.PushIntoList( "nexturl",next); 
        }
        public static string GetNextUrl()
        {
            return RedisCore.PopFromList("nexturl");
        }
        public static void PushUserInfo(string UserInfo)
        {
            RedisCore.PushIntoList("User", UserInfo);
        }
        public static string  GetUserInfo()
        {
            return   RedisCore.PopFromList("User");
        }
    }
}

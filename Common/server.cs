using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Common
{
     public    class server
    {
      
       /// <summary>
       /// 将队列中的用户信息持久化
       /// </summary>
         public void SaveUser()
         {
             using (ZhihuEntity Entity = new ZhihuEntity())
             {
              
                     string json = RedisManage.GetUserInfo();
                     User user=  SerializeHelper.DeserializeToObject<User>(json);
                     Entity.user.Add(user);
                     try
                     {
                         Entity.SaveChanges();
                     }
                     catch (Exception ex)
                     {

                         Console.WriteLine(ex.ToString());
                     }
             }
              
         }
    }
}

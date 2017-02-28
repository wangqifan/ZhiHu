using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;
using System.Threading;

namespace ZhiHu
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisManage.AddUrltoken("excited-vczh");//添加种子数据  因为有hsah标志  不必担心重复加入
            for (int i = 0; i < 5; i++)//开启5个线程共同爬取  如果超过5个 而且没有挂代理的话会出现429
            {
                ThreadPool.QueueUserWorkItem(GetUser);
            }
            ThreadPool.QueueUserWorkItem(SaveUserInfor);
            Console.ReadLine();
        }
        private static void GetUser(object data)//开启爬取用户主页信息工作
        {

            while (true)
            {
                string url_token = RedisManage.GetUrltoken();
                Console.WriteLine("分析"+url_token);
                if (!string.IsNullOrEmpty(url_token))
                {
                    UserManage manage = new UserManage(url_token);
                    manage.analyse();
                }
                else
                {
                    GetNexturl();
                }
            }
              
        }
        private static void GetNexturl()//开启爬取关注列表工作
        {
            string nexturl = RedisManage.GetNextUrl();
            if (!string.IsNullOrEmpty(nexturl))
            {
                UrlTask task = new UrlTask(nexturl);
                task.Analyse();
            }
        }
        private static void SaveUserInfor(object data)
        {
            server ser = new server();
            ser.SaveUser();
        }//开启用户信息持久化工作
      
    }
}


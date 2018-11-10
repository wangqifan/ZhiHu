using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Diagnostics;

namespace Common
{
    public   class UserManage
    {
        /// <summary>
        /// 用户主页的html代码
        /// </summary>
        private string html;
        /// <summary>
        /// 用户的urltokken  每个用户都不一样
        /// </summary>
        private string url_token;
      
        public UserManage(string urltoken)
         {
             url_token = urltoken;
      
         }  
         //获取json中的用户信息  
        private void  GetUserInformation(string json)
        {  
            JObject obj = JObject.Parse(json);
            //string xpath = "['" + url_token + "']";
            JToken tocken = obj.SelectToken("initialState.entities.users.['"+ url_token + "']");
            //tocken = tocken.SelectToken(xpath);
          
            RedisManage.PushUserInfo(tocken.ToString());
              
        } 
          //获取用户关注列表的url
        private void  GetUserFlowerandNext()
        {
                 string foollowed = "https://www.zhihu.com/api/v4/members/" + url_token + "/followers?include=data%5B*%5D.answer_count%2Carticles_count%2Cfollower_count%2Cis_followed%2Cis_following%2Cbadge%5B%3F(type%3Dbest_answerer)%5D.topics&offset=0&limit=20";
                 string following = "https://www.zhihu.com/api/v4/members/" + url_token + "/followees?include=data%5B%2A%5D.answer_count%2Carticles_count%2Cfollower_count%2Cis_followed%2Cis_following%2Cbadge%5B%3F%28type%3Dbest_answerer%29%5D.topics&limit=20&offset=0";
           
                 RedisManage.AddNextUrl(following);
                 RedisManage.AddNextUrl(foollowed);
        }
        /// <summary>
        /// 获取主页html代码
        /// </summary>
        /// <returns></returns>
        private bool GetHtml()
        {                 
            string url="https://www.zhihu.com/people/"+url_token+"/following";
            html = HttpHelp.DownLoadString(url);
            return  !string.IsNullOrEmpty(html);
        }
        /// <summary>
        /// 分析json
        /// </summary>
        public  void  analyse()
        {
                if (GetHtml())
                {
                    try
                    {
                        Stopwatch watch = new Stopwatch();
                        watch.Start();
                        HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(html);
                        HtmlNode node = doc.GetElementbyId("js-initialData");
                        StringBuilder stringbuilder =new StringBuilder(node.InnerText);
                       // stringbuilder.Replace("&quot;", "'");           
                       // stringbuilder.Replace("&lt;", "<");
                       // stringbuilder.Replace("&gt;", ">");

                        GetUserInformation(stringbuilder.ToString());
                        GetUserFlowerandNext();
                        watch.Stop();
                        Console.WriteLine("分析Html用了{0}毫秒", watch.ElapsedMilliseconds.ToString());
                       
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            
            }    
        }
    
}

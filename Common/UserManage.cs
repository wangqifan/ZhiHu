using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Text;

namespace Common
{
    public class UserManage
    {
        /// <summary>
        /// 用户的urltokken  每个用户都不一样
        /// </summary>
        private string url_token;

        public UserManage(string urltoken)
        {
            url_token = urltoken;
        }

        /// <summary>
        /// 获取json中的用户信息
        /// </summary>
        /// <param name="json"></param>
        private void GetUserInformation(string json)
        {
            JObject obj = JObject.Parse(json);
            JToken tocken = obj.SelectToken("initialState.entities.users.['" + url_token + "']");
            RedisManage.PushUserInfo(tocken.ToString());
        }

        /// <summary>
        /// 将用户关注的人的URL存放到nexturl中
        /// </summary>
        /// <param name="offset"></param>
        private void GetUserfollowing()
        {
            string following = CommonConstant.ZHMembersRoot + url_token + "/followees?include=data%5B%2A%5D.answer_count%2Carticles_count%2Cfollower_count%2Cis_followed%2Cis_following%2Cbadge%5B%3F%28type%3Dbest_answerer%29%5D.topics&limit=20&offset=0";
            RedisManage.AddNextUrl(following);
        }

        /// <summary>
        /// 将关注用户的人的URL存放到nexturl中
        /// </summary>
        /// <param name="currentPageIndex"></param>
        private void GetUserFollowers()
        {
            string foollowed = CommonConstant.ZHMembersRoot + url_token + "/followers?include=data%5B*%5D.answer_count%2Carticles_count%2Cfollower_count%2Cis_followed%2Cis_following%2Cbadge%5B%3F(type%3Dbest_answerer)%5D.topics&offset=0&limit=20";
            RedisManage.AddNextUrl(foollowed);
        }

        /// <summary>
        /// 根据想要获取的数据类型来获得HTML内容
        /// </summary>
        /// <returns></returns>
        private string GetHtml(ZHUrlPoolType type)
        {
            string html;
            string url = CommonConstant.ZHRoot + url_token + "/" + Enum.GetName(typeof(ZHUrlPoolType), type).ToLower();
            html = HttpHelp.DownLoadString(url);
            return html;
        }

        /// <summary>
        /// 分析用户关注者列表
        /// </summary>
        /// <param name="followingContent"></param>
        public void AnalyseHTML(string htmlContent, Action getUserUrls, bool isGetUserInfo = false)
        {
            if (string.IsNullOrEmpty(htmlContent))
                return;

            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                HtmlNode node = doc.GetElementbyId("js-initialData");
                StringBuilder stringbuilder = new StringBuilder(node.InnerText);

                //ext: 获取用户个人信息
                if (isGetUserInfo)
                    GetUserInformation(stringbuilder.ToString());

                getUserUrls();

                watch.Stop();
                Console.WriteLine("分析用户{0}用了{1}毫秒", url_token, watch.ElapsedMilliseconds.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 分析json
        /// </summary>
        public void analyse()
        {
            AnalyseHTML(GetHtml(ZHUrlPoolType.Following), () => { GetUserfollowing(); }, true);
            AnalyseHTML(GetHtml(ZHUrlPoolType.Followers), () => { GetUserFollowers(); });
        }
    }
}
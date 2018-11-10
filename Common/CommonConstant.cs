using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 公用常量类
    /// </summary>
    internal class CommonConstant
    {
        public const int CountPerPage = 20;                         //每页数据的常量
        public const string ZHRoot = "https://www.zhihu.com/people/";      //知乎个人信息主页Root
        public const string ZHMembersRoot = "https://www.zhihu.com/api/v4/members/";        //知乎用户数据Root
    }

    /// <summary>
    /// 知乎取URL的leix
    /// </summary>
    enum ZHUrlPoolType
    {
        Following,//关注者列表 following
        Followers//被关注者列表 followers
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   

    public  class follower
    {
         public bool is_followed { get; set; }
         public string avatar_url_template { get; set; }
         public string name { get; set; }
         public string url_token { get; set; }
         public string user_type { get; set; }
         public int answer_count { get;set; }
         public bool is_advertiser { get; set; }
         public string avatar_url { get; set; }
         public bool is_following { get; set; }
         public bool is_org { get; set; }
         public string headline { get; set; }
         public string follower_count { get; set; }
         public string type { get; set; }
         public string id { get; set; }
         public int articles_count { get; set; }
    }
}

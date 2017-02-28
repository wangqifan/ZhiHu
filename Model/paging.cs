using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
      //"is_end": false,
      //  "next": "https://www.zhihu.com/api/v4/members/excited-vczh/followers?include=data%5B%2A%5D.answer_count%2Carticles_count%2Cfollower_count%2Cis_followed%2Cis_following%2Cbadge%5B%3F%28type%3Dbest_answerer%29%5D.topics&limit=10&offset=20",
      //  "previous": "https://www.zhihu.com/api/v4/members/excited-vczh/followers?include=data%5B%2A%5D.answer_count%2Carticles_count%2Cfollower_count%2Cis_followed%2Cis_following%2Cbadge%5B%3F%28type%3Dbest_answerer%29%5D.topics&limit=10&offset=0",
      //  "is_start": false,
      //  "totals": 469826

    public class paging
    {
        public bool is_end { get; set; }
        public string  next { get; set; }
        public string previous { get; set; }
        public bool is_start { get; set; }
        public int totals { get; set; }
    }
}

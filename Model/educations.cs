using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class educations
    {
         [Key]
        public int id { get;set;}
         //public int schoolid { get; set; }
         //public int majorid { get; set; }
        public virtual school school { get; set; }
        public virtual major major { get; set; }
        public virtual ICollection<User> user { get; set; }
    }
}

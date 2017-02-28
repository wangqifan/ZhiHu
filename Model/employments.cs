using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class employments
    {
        [Key]
        public int id { get; set; }
        public virtual job job { get; set; }
        public virtual company company { get; set; }
        public virtual ICollection<User> user { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ZhihuEntity : DbContext
    {
        public ZhihuEntity()
            : base("name=ZhihuEntity")
        {
          //  Database.SetInitializer<ZhihuEntity>(null);
        }
     
        public DbSet<User> user { get; set; }
        public DbSet<business> business { get; set; }
        public DbSet<employments> employments { get; set; }
        public DbSet<company> company { get; set; }
        public DbSet<job> job { get; set; }
        public DbSet<locations> locations { get; set; }
        public DbSet<educations> educations { get; set; }
        public DbSet<school> school { get; set; }
        public DbSet<major> major { get; set; }
        public DbSet<UserTemp> UserTemp { get; set; }
        public DbSet<nexturl> nexturl { get; set; }

    }
    public class TempEntity : DbContext
    {
        public TempEntity()
            : base("name=TempEntity")
        {
         
        }
        public   DbSet<UserTemp> user { get; set; } 
    }
}

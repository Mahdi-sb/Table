using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Models.DBcontext
{
    public class AppDBcontext :DbContext
    {
        public AppDBcontext(DbContextOptions dbContextOptions)

            : base(dbContextOptions)
        {

        }

        public DbSet<Tables> Tables { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<CreateTime>  CreateTimes { get; set; }
    }
}

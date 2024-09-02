using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchWithCQRSandMediator.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchWithCQRSandMediator.Infra.Data
{
    public class BlogDbContext : DbContext
    {
        /* public BlogDbContext()
         *   :base("name=BlogDbContext") 
         */
        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
        //create dbset
        public DbSet<Blog> Blogs { get; set; }

    }
}


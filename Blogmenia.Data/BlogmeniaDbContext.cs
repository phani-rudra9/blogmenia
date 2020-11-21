using Blogmenia.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogmenia.Data
{
    public class BlogmeniaDbContext : DbContext
    {
        public BlogmeniaDbContext(DbContextOptions<BlogmeniaDbContext> options)   : base(options)
        {

        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Demos> Demos { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Postcategory> Postcategory { get; set; }
        public virtual DbSet<Subscriber> Subscriber { get; set; }

        public virtual DbSet<Sitemaping> Sitemaping { get; set; }
        
    }
}

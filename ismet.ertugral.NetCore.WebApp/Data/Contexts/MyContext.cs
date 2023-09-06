using WebApp.Data.Configurations;
using WebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Data.Contexts
{
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=ISMETERTUGRALNB\\SQLEXPRESS;database=EfCore;" +
        //        "integrated security=true;TrustServerCertificate=True;");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            //modelBuilder.Entity<Blog>().HasMany(x => x.Comments).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId);
            //modelBuilder.Entity<Comment>().HasOne(x => x.Blog).WithMany(x => x.Comments).HasForeignKey(x => x.BlogId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

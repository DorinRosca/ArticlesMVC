using ArticleApp.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.EntityFramework.Context
{
     public class DataContext :DbContext
     {
          private readonly DbContextOptions _options;
          public DataContext(DbContextOptions options) : base(options)
          {
               _options = options;
          }
          public virtual DbSet<Article> Articles { get; set; }
          public virtual DbSet<Payment> Payments { get; set; }
          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {

               base.OnModelCreating(modelBuilder);
          }
     }
}

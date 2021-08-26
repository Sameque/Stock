using Entities.Stock;
using Microsoft.EntityFrameworkCore;

namespace RepositoryEF.Data
{
    public class RepositoryEFContext : DbContext
    {
        public RepositoryEFContext() { }
        public RepositoryEFContext(DbContextOptions<RepositoryEFContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=primesolucoes.dyndns.biz,14331;Initial Catalog=dbTest;Persist Security Info=True;User ID=dev;Password=d3senvolvimento-+123");
            //base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Product> Products { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}

using Microsoft.EntityFrameworkCore;

namespace TreeApp.Data
{
    public class BranchDataContext : DbContext
    {
        public BranchDataContext(DbContextOptions<BranchDataContext> options):
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Branch> Branches{ get; set; }
    }
}

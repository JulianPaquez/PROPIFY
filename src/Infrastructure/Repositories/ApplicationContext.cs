using domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<SysAdmin> SysAdmins { get; set; }
        public DbSet<Addresses> Addresses { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Property>()
        .HasOne(p => p.Owner)
        .WithMany()
        .HasForeignKey(p => p.OwnerId)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Owner>().ToTable("Owner");
    modelBuilder.Entity<SysAdmin>().ToTable("SysAdmin");

    base.OnModelCreating(modelBuilder);
}
    }


}
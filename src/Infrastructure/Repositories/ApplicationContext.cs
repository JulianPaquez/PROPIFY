using domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<SysAdmin> SysAdmins { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Taxes> Taxes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Booking> Bookings{ get; set; }

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

        modelBuilder.Entity<User>()
            .ToTable("Users")
            .HasDiscriminator<string>("UserType")
            .HasValue<SysAdmin>("sysAdmin")
            .HasValue<Owner>("owner")
            .HasValue<Client>("client");
            
        modelBuilder.Entity<Review>().ToTable("Reviews");

    base.OnModelCreating(modelBuilder);
}
    }


}
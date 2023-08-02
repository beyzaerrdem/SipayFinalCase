using Api.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DataAccess;

public class SipayApiDbContext : DbContext
{
    public SipayApiDbContext(DbContextOptions<SipayApiDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    public DbSet<Apartment> Apartments { get; set; }

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<Invoice> Invoices { get; set; }

    public DbSet<UserLogin> UserLogin { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new UserLoginConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

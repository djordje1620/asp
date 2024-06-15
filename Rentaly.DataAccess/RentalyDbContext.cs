using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccess.Extensions;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess;
public class RentalyDbContext : DbContext
{

    public RentalyDbContext(DbContextOptions<RentalyDbContext> options) : base(options)
    {
    }

    public RentalyDbContext() : base()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyCustomConfiguration();
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connString = @"Data Source=DESKTOP-F1A92T2\SQLEXPRESS;Initial Catalog=rentaly;Integrated Security=True;Trust Server Certificate=True";

        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connString);
        }
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Specification> Specifications { get; set; }
    public DbSet<CarSpecification> CarSpecifications { get; set; }
    public DbSet<CarType> CarTypes { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<CarAccessory> CarAccessories { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<BookingCarAccessories> BookingCarAccessories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<CarService> CarServices { get; set; }
    public DbSet<RoleUseCases> RoleUseCases { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
}

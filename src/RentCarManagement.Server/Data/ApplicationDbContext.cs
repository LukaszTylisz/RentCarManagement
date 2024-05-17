using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RentCarManagement.Models;
using Shared.Domain;

namespace RentCarManagement.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) :
        base(options, operationalStoreOptions)
    {
    }
    
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Colour> Colours { get; set; }
    public DbSet<Make> Makes { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    }
}
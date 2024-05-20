using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RentCarManagement.Server.Configurations.Entities;
using RentCarManagement.Server.Models;
using Shared.Domain;

namespace RentCarManagement.Server.Data;

public class ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
    : ApiAuthorizationDbContext<ApplicationUser>(options, operationalStoreOptions)
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Colour> Colours { get; set; }
    public DbSet<Make> Makes { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ColourSeedConfiguration());
        builder.ApplyConfiguration(new MakeSeedConfiguration());
        builder.ApplyConfiguration(new ModelSeedConfiguration());
        builder.ApplyConfiguration(new RoleSeedConfiguration());
        builder.ApplyConfiguration(new UserSeedConfiguration());
        builder.ApplyConfiguration(new UserRoleSeedConfiguration());
    }
}
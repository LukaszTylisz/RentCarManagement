using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentCarManagement.Server.Data;
using RentCarManagement.Server.IRepository;
using RentCarManagement.Server.Models;
using Shared.Domain;

namespace RentCarManagement.Server.Repository;

public class UnitOfWork(
    ApplicationDbContext dbContext,
    UserManager<ApplicationUser> userManager,
    IGenericRepository<Make> makes,
    IGenericRepository<Model> models,
    IGenericRepository<Colour> colours,
    IGenericRepository<Booking> bookings,
    IGenericRepository<Customer> customers,
    IGenericRepository<Vehicle> vehicles) : IUnitWork
{
    public void Dispose()
    {
        dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public IGenericRepository<Make> Makes
        => makes ??= new GenericRepository<Make>(dbContext);

    public IGenericRepository<Model> Models
        => models ??= new GenericRepository<Model>(dbContext);

    public IGenericRepository<Colour> Colours
        => colours ??= new GenericRepository<Colour>(dbContext);

    public IGenericRepository<Vehicle> Vehicles
        => vehicles ??= new GenericRepository<Vehicle>(dbContext);

    public IGenericRepository<Booking> Bookings
        => bookings ??= new GenericRepository<Booking>(dbContext);

    public IGenericRepository<Customer> Customers
        => customers ??= new GenericRepository<Customer>(dbContext);

    public async Task Save(HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var user = await userManager.FindByIdAsync(userId);

        var entries = dbContext.ChangeTracker.Entries()
            .Where(q => q.State == EntityState.Modified ||
                        q.State == EntityState.Added);

        foreach (var entry in entries)
        {
            ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
            ((BaseDomainModel)entry.Entity).UpdatedBy = user.UserName;
            if (entry.State == EntityState.Added)
            {
                ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).CreatedBy = user.UserName;
            }
        }

        await dbContext.SaveChangesAsync();
    }
}
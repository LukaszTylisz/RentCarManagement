using Microsoft.AspNetCore.Identity;
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
    private IGenericRepository<Make> _makes = makes;
    private IGenericRepository<Model> _models = models;
    private IGenericRepository<Colour> _colours = colours;
    private IGenericRepository<Booking> _bookings = bookings;
    private IGenericRepository<Customer> _customers = customers;
    private IGenericRepository<Vehicle> _vehicles = vehicles;

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
    
    public Task Save(HttpContext httpContext)
    {
        throw new NotImplementedException();
    }

    public IGenericRepository<Make> Make { get; }
}
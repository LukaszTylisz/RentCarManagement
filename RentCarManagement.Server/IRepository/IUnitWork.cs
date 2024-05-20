using Shared.Domain;

namespace RentCarManagement.Server.IRepository;

public interface IUnitWork : IDisposable
{
    Task Save(HttpContext httpContext);
    IGenericRepository<Make> Makes { get; }
    IGenericRepository<Model> Models { get; }
    IGenericRepository<Vehicle> Vehicles { get; }
    IGenericRepository<Colour> Colours { get; }
    IGenericRepository<Booking> Bookings { get; }
    IGenericRepository<Customer> Customers { get; }
}
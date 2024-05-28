using Client.Contracts;
using Client.Static;
using Microsoft.AspNetCore.Components;
using Shared.Domain;

namespace RentCarManagement.Client.Pages.Bookings;
public partial class Create
{
    [Inject] IHttpRepository<Booking> _client { get; set; }
    [Inject] NavigationManager _navigationManager { get; set; }

    Booking booking = new Booking
    {
        DateOut = DateTime.Now.Date
    };

    private async Task CreateBooking()
    {
        await _client.Create(Endpoints.BookingsEndpoint, booking);
        _navigationManager.NavigateTo("/bookings/");
    }
}
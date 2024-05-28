using Client.Contracts;
using Client.Static;
using Microsoft.AspNetCore.Components;
using Shared.Domain;

namespace RentCarManagement.Client.Pages.Bookings;
public partial class Edit
{
    [Inject] IHttpRepository<Booking> _client { get; set; }
    [Inject] NavigationManager _navigationManager { get; set; }
    [Parameter] public int id { get; set; }
    Booking booking = new Booking();

    protected async override Task OnParametersSetAsync()
    {
        booking = await _client.Get(Endpoints.BookingsEndpoint, id);
    }

    async Task EditBooking()
    {
        await _client.Update(Endpoints.BookingsEndpoint, booking, id);
        _navigationManager.NavigateTo("/bookings/");
    }
}
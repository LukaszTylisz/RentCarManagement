using Client.Contracts;
using Client.Static;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shared.Domain;

namespace RentCarManagement.Client.Pages.Bookings;

public partial class View
{
    [Parameter] public int id { get; set; }
    [Inject] IHttpRepository<Booking> _client { get; set; }

    Booking booking = new Booking();

    protected async override Task OnParametersSetAsync()
    {
        booking = await _client.Get(Endpoints.BookingsEndpoint, id);
    }
}
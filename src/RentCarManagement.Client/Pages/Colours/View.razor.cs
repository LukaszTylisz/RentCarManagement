using Client.Contracts;
using Client.Static;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shared.Domain;

namespace RentCarManagement.Client.Pages.Colours;

public partial class View
{
    [Inject] private IHttpRepository<Colour> _client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    [Parameter] public int id { get; set; }
    private Colour colour = new Colour();

    protected async override Task OnParametersSetAsync()
    {
        colour = await _client.Get(Endpoints.ColoursEndpoint, id);
    }
}
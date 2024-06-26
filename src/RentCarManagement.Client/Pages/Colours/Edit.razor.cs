﻿using Client.Contracts;
using Client.Static;
using Microsoft.AspNetCore.Components;
using Shared.Domain;

namespace RentCarManagement.Client.Pages.Colours;

public partial class Edit
{
    [Inject] private IHttpRepository<Colour> _client { get; set; }
    [Inject] private NavigationManager _navManager { get; set; }
    [Parameter] public int id { get; set; }
    private Colour colour = new Colour();

    protected async override Task OnParametersSetAsync()
    {
        colour = await _client.Get(Endpoints.ColoursEndpoint, id);
    }

    private async Task EditColour()
    {
        await _client.Update(Endpoints.ColoursEndpoint, colour, id);
        _navManager.NavigateTo("/colours");
    }
}
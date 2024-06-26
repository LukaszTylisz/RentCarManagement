﻿using Client.Contracts;
using Client.Static;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shared.Domain;

namespace RentCarManagement.Client.Pages.Colours;

public partial class Index
{
    [Inject] private IHttpRepository<Colour> _client { get; set; }
    [Inject] private IJSRuntime js { get; set; }
    private IList<Colour> Colours;

    protected async override Task OnInitializedAsync()
    {
        Colours = await _client.GetAll(Endpoints.ColoursEndpoint);
    }

    private async Task Delete(int colourId)
    {
        var colour = Colours.First(q => q.Id == colourId);
        var confirm = await js.InvokeAsync<bool>("confirm", $"Do you want to delete {colour.Name}?");
        if (confirm)
        {
            await _client.Delete(Endpoints.ColoursEndpoint, colourId);
            await OnInitializedAsync();
        }
    }
}
using Client.Contracts;
using Client.Static;
using Microsoft.AspNetCore.Components;
using Shared.Domain;

namespace RentCarManagement.Client.Pages.Bookings;
public partial class FormComponent
{
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public Booking booking { get; set; }
    [Parameter] public string ButtonText { get; set; } = "Save";
    [Parameter] public EventCallback OnValidSubmit { get; set; }
    [Inject] IHttpRepository<Vehicle> _clientVehicle { get; set; }
    [Inject] IHttpRepository<Customer> _clientCustomer { get; set; }

    private List<Vehicle> Vehicles;
    private List<Customer> Customers;

    protected async override Task OnInitializedAsync()
    {
        Customers = await _clientCustomer.GetAll(Endpoints.CustomersEndpoint);
        Vehicles = await _clientVehicle.GetAll(Endpoints.VehiclesEndpoint);
    }
}
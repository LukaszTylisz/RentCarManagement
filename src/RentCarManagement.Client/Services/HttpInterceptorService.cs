using System.Net;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor;

namespace Client.Services;

public class HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager)
{
    public void MonitorEvent() => interceptor.AfterSend += InterceptResponse;

    private void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
    {
        string message = string.Empty;

        if (e.Response.IsSuccessStatusCode)
        {
            var responseCode = e.Response.StatusCode;

            switch (responseCode)
            {
                case HttpStatusCode.NotFound:
                    navManager.NavigateTo("/404");
                    message = "The requested resource not found";
                    break;
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                    navManager.NavigateTo("/unauthorized");
                    message = "You are not authorized to access this resource";
                    break;
                default:
                    navManager.NavigateTo("/500");
                    message = "Something went wrong, please contact with Administrator";
                    break;
            }

            throw new HttpRequestException(message);
        }
    }

    public void DisposeEvent() => interceptor.AfterSend -= InterceptResponse;
}
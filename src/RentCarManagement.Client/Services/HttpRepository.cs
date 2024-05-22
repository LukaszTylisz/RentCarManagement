using System.Net.Http.Json;
using Client.Contracts;

namespace Client.Services;

public class HttpRepository<T>(HttpClient client, HttpInterceptorService interceptor) : IDisposable, IHttpRepository<T>
    where T : class
{
    public void Dispose()
    {
      interceptor.DisposeEvent();
    }
    
    public async Task<T> Get(string url, int id)
    {
        interceptor.MonitorEvent();
        return await client.GetFromJsonAsync<T>($"{url}/{id}");
    }

    public async Task<T> GetDetails(string url, int id)
    {
       interceptor.MonitorEvent();
       return await client.GetFromJsonAsync<T>($"{url}/{id}/details");
    }

    public async Task<List<T>> GetAll(string url)
    {
        interceptor.MonitorEvent();
        return await client.GetFromJsonAsync<List<T>>($"{url}");
    }

    public async Task Create(string url, T obj)
    {
        interceptor.MonitorEvent();
        await client.PostAsJsonAsync(url, obj);
    }

    public async Task Update(string url, T obj, int id)
    {
        interceptor.MonitorEvent();
        await client.PutAsJsonAsync($"{url}/{id}", obj);
    }

    public async Task Delete(string url, int id)
    {
        interceptor.MonitorEvent();
        await client.DeleteAsync($"{url}/{id}");
    }
}
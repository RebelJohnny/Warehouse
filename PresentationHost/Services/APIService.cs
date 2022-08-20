using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PresentationHost.Services
{
    public interface IAPIService
    {
        Task<HttpResponseMessage> ForCreating(string url, StringContent data);
        Task<HttpResponseMessage> ForDeleting(string url);
        Task<string> ForGetting(string url);
        Task<HttpResponseMessage> ForUpdating(string url, StringContent data);
    }

    public class APIService : IAPIService
    {
        HttpClient client = new HttpClient();

        public Task<HttpResponseMessage> ForCreating(string url, StringContent data)
        {
            return client.PostAsync(url, data);
        }
        public Task<String> ForGetting(string url)
        {
            return client.GetStringAsync(url);
        }
        public Task<HttpResponseMessage> ForUpdating(string url, StringContent data)
        {
            return client.PutAsync(url, data);
        }
        public Task<HttpResponseMessage> ForDeleting(string url)
        {
            return client.DeleteAsync(url);
        }
    }
}

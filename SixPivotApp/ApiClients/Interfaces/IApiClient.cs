using System.Collections.Generic;
using System.Threading.Tasks;

namespace SixPivotApp.ApiClients.Interfaces
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string uri);

        Task PostAsync(string uri, object request, IDictionary<string, string> headers = null);

        Task<T> PostAsync<T>(string uri, object request, IDictionary<string, string> headers = null);
    }
}
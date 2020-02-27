using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SixPivotApp.ApiClients.Interfaces;
using SixPivotApp.Common;
using SixPivotApp.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SixPivotApp.ApiClients
{
    public class ApiClient : IApiClient
    {
        public ApiClient(IOptions<VendorApiSettings> vendorApiSettings, IJsonSerializer jsonSerializer)
        {
            _vendorApiSettings = vendorApiSettings;
            _jsonSerializer = jsonSerializer;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient() 
            {
                BaseAddress = new Uri(_vendorApiSettings.Value.Host) 
            })
            {
                SetApiKey(httpClient);

                HttpResponseMessage response = await httpClient.GetAsync(uri);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    string message = $"Error during GET request for {_vendorApiSettings.Value.Host}{uri}. Response Content: {responseContent}";
                    throw new Exception(message);
                }

                T responseData = _jsonSerializer.Deserialize<T>(responseContent);

                return responseData;
            }
        }

        private void SetApiKey(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("api-key", _vendorApiSettings.Value.Key);
        }
        public async Task PostAsync(string uri, object request, IDictionary<string, string> headers = null)
        {
            await PostBaseAsync(uri, request, headers: headers);
        }

        public async Task<T> PostAsync<T>(string uri, object request, IDictionary<string, string> headers = null)
        {
            string responseContent = await PostBaseAsync(uri, request, headers: headers);
            T responseData = _jsonSerializer.Deserialize<T>(responseContent);

            return responseData;
        }

        private async Task<string> PostBaseAsync(string uri, object request, IDictionary<string, string> headers = null)
        {
            using (HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_vendorApiSettings.Value.Host),
            })
            {
                SetApiKey(httpClient);

                if (headers != null)
                    foreach (KeyValuePair<string, string> header in headers)
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

                string requestJson = _jsonSerializer.Serialize(request);
                StringContent requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(uri, requestContent);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    string message = $"Error during POST request for {_vendorApiSettings.Value.Host}{uri}. Response Content: {responseContent}";
                    throw new Exception(message);
                }

                return responseContent;
            }
        }

        private readonly IOptions<VendorApiSettings>  _vendorApiSettings;
        private readonly IJsonSerializer _jsonSerializer;
    }
}
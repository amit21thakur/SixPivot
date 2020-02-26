using SixPivotApp.ApiClients.Interfaces;
using SixPivotApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixPivotApp.ApiClients
{
    public class ProductsApiClient : ApiClientBase, IProductsApiClient
    {
        public ProductsApiClient(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            return await apiClient.GetAsync<IEnumerable<Product>>("api/Products");
        }
    }
}

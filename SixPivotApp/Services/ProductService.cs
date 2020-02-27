using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixPivotApp.ApiClients.Interfaces;
using SixPivotApp.Common;
using SixPivotApp.Models;

namespace SixPivotApp.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IProductsApiClient productsApiClient) => _productsApiClient = productsApiClient;

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _productsApiClient.GetProductAsync();
            foreach(var product in products)
            {
                product.UnitPrice *= Constants.MarginFactor;
            }
            return products;
        }

        private readonly IProductsApiClient _productsApiClient;
    }
}

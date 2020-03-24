using Xunit;
using Moq;
using System.Collections.Generic;
using SixPivotApp.Models;
using System;
using SixPivotApp.ApiClients.Interfaces;
using SixPivotApp.Services.Interfaces;
using SixPivotApp.Services;
using System.Threading.Tasks;

namespace SixPivotApp.UnitTest
{
    public class ProductServiceTest
    {
        [Fact]
        public void TestPriceMarkUp()
        {
            var mock = new Mock<IProductsApiClient>();
            var baseProducts = new List<Product>()
                {
                    new Product{ Description = "Desc ABC", MaximumQuantity = null, Name = "A-One", ProductId = "A1", UnitPrice = 100.0d },
                    new Product{ Description = "Desc DEF", MaximumQuantity = null, Name = "D-One", ProductId = "D1", UnitPrice = 10 },
                    new Product{ Description = "Desc GHI", MaximumQuantity = null, Name = "G-One", ProductId = "G1", UnitPrice = 50 },
                    new Product{ Description = "Desc JKL", MaximumQuantity = null, Name = "J-One", ProductId = "J1", UnitPrice = 100000 }
                };
            
            mock.Setup(productSrv => productSrv.GetProductAsync()).Returns(Task.FromResult((IEnumerable<Product>)baseProducts));

            IProductService productService = new ProductService(mock.Object);
            var  products = (List<Product>) productService.GetAllProductsAsync().Result;

            Assert.Equal(products.Count, baseProducts.Count);

            Assert.Equal(120, products[0].UnitPrice);
            Assert.Equal(12, products[1].UnitPrice);
            Assert.Equal(60, products[2].UnitPrice);
            Assert.Equal(120000, products[3].UnitPrice);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SixPivotApp.Services;
using SixPivotApp.Services.Interfaces;

namespace SixPivotApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _logger = Log.ForContext(typeof(ProductsController));
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "Failed to get the product details.");
                return StatusCode(500);
            }
        }
    }
}

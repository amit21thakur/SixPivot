using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SixPivotApp.Models;
using SixPivotApp.Services;
using SixPivotApp.Services.Interfaces;

namespace SixPivotApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IOrdersService _ordersService;


        public OrdersController(IOrdersService ordersService)
        {
            _logger = Log.ForContext(typeof(OrdersController));
            _ordersService = ordersService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Order order)
        {
            try
            {
                await _ordersService.SubmitOrderAsync(order);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "Failed to submit the order.");
                return StatusCode(500);
            }
        }
    }
}

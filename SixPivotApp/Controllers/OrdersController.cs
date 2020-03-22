using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SixPivotApp.Models;
using SixPivotApp.Services;
using SixPivotApp.Services.Interfaces;

namespace SixPivotApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrdersService _ordersService;

        public OrdersController(ILogger<OrdersController> logger, IOrdersService ordersService)
        {
            _logger = logger;
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
                //TODO: add proper logging
                //_logger.LogError(ex, "Failed to ")
                return StatusCode(500);
            }
        }
    }
}

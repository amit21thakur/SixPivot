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
    public class RatesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IFxRatesService _ratesService;

        public RatesController(IFxRatesService ratesService)
        {
            _logger = Log.ForContext(typeof(RatesController));
            _ratesService = ratesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var rates = await _ratesService.GetAllRatesAsync();
                return Ok(rates);
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "Failed to get the exchange rates.");
                return StatusCode(500);
            }
        }
    }
}

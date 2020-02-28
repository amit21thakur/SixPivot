using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SixPivotApp.Services;
using SixPivotApp.Services.Interfaces;

namespace SixPivotApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatesController : ControllerBase
    {
        private readonly ILogger<RatesController> _logger;
        private readonly IFxRatesService _ratesService;

        public RatesController(ILogger<RatesController> logger, IFxRatesService ratesService)
        {
            _logger = logger;
            _ratesService = ratesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rates = await _ratesService.GetAllRatesAsync();
            return Ok(rates);
        }
    }
}

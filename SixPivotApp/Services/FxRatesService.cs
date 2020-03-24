using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixPivotApp.ApiClients.Interfaces;
using SixPivotApp.Common;
using SixPivotApp.Models;
using SixPivotApp.Services.Interfaces;

namespace SixPivotApp.Services
{
    public class FxRatesService : IFxRatesService
    {
        public FxRatesService(IFxRatesApiClient ratesApiClient) => _ratesApiClient = ratesApiClient;

        public async Task<IEnumerable<FxRate>> GetAllRatesAsync()
        {
            return await _ratesApiClient.GetRatesAsync();
        }

        private readonly IFxRatesApiClient _ratesApiClient;
    }
}

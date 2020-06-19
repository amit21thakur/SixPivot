using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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
        private readonly ICacheService _cacheService;
        private readonly IConfiguration _config;

        public async Task<IEnumerable<FxRate>> GatCachedRates(FxRate request)
        {
            return await ProcessAsync(async () =>
            {
                return await _ratesApiClient.GetRatesAsync();
            }, request, 600);
        }


        private async Task<TResult> ProcessAsync<TResult, TK>(Func<Task<TResult>> action, TK key, int timeToLive) where TResult : class
        {
            if (_config.GetSection("EnableCaching").Get<bool>())
            {
                var result = await _cacheService.GetCachedDataAsync<TResult, TK>(key);
                if (result != null)
                    return result;

                result = await action();

                _cacheService.CacheDataAsync<TResult, TK>(key, result, timeToLive);
                return result;
            }
            return await action();
        }

    }
}

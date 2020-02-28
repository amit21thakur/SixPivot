using SixPivotApp.ApiClients.Interfaces;
using SixPivotApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixPivotApp.ApiClients
{
    public class FxRatesApiClient : ApiClientBase, IFxRatesApiClient
    {
        public FxRatesApiClient(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<IEnumerable<FxRate>> GetRatesAsync()
        {
            return await apiClient.GetAsync<IEnumerable<FxRate>>("api/fx-rates");
        }
    }
}

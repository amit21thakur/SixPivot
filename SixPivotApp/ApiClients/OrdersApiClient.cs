using SixPivotApp.ApiClients.Interfaces;
using SixPivotApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixPivotApp.ApiClients
{
    public class OrdersApiClient : ApiClientBase, IOrdersApiClient
    {
        public OrdersApiClient(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task SubmitOrderAsync(Order order)
        {
            await apiClient.PostAsync("api/Orders", order);
        }
    }
}
